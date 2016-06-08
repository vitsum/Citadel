using System;
using Entitas;
using UnityEngine;

class CityPlacerSystem : MonoBehaviour, IInitializeSystem, ISetPool
{
    private Pool _pool;
    [SerializeField]
    private Transform _board;
    [SerializeField]
    private float _radius = 2f;
    [SerializeField]
    private GameObject _basePrefab;
    [SerializeField]
    private Color[] _colors = new Color[]
    {
        Color.red,
        Color.white,
        Color.green,
        Color.yellow,
        Color.blue,
        Color.gray,
        Color.cyan,
        Color.magenta
    };

    public void Initialize()
    {
        if(null == _board)
        {
            throw new NullReferenceException("CityPlacerSystem missing _board reference");
        }

        int playersCount = _pool.playersCountEntity.playersCount.Count;
        Debug.Log(playersCount);
        for(int i=0; i<playersCount; i++)
        {
            var cityBase = Instantiate(_basePrefab) as GameObject;
            cityBase.transform.position = _board.transform.position;
            cityBase.transform.Rotate(Vector3.up, i * 360f / playersCount);
            var theCityBase = cityBase.transform.GetChild(0).GetComponent<CityBaseView>();
            theCityBase.GetComponent<Renderer>().material.color = GetColor(i);

            _pool.CreateEntity().AddCity(theCityBase).AddOwner(i);
            _pool.CreateEntity().AddPlayer(i, "test " + i, GetColor(i));
        }
    }

    public void SetPool(Pool pool)
    {
        _pool = pool;
    }

    private Color GetColor(int i)
    {
        return _colors[i];
    }
}