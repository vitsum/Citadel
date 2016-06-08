using UnityEngine;
using System.Collections;

public class CityBaseView : MonoBehaviour {

    public Transform[] buildingPlaces = new Transform[CountInRow * CountInRow];

    private const float Spacing = 0.3f;
    private const float Elevation = 0.5f;
    private const int CountInRow = 3;

    void Awake()
    {
        for(int j=0; j<CountInRow; j++)
        {
            for(int i=0; i<CountInRow; i++)
            {
                var x = -Spacing + i * Spacing;
                var z = Spacing - j * Spacing;
                var pos = new Vector3(x, Elevation, z);
                var place = new GameObject(i + ":" + j).transform;
                place.SetParent(transform, false);
                place.localPosition = pos;
                buildingPlaces[j * CountInRow + i] = place;
            }
        }
    }

    public Transform GetFirstAvailablePlace()
    {
        for(int i=0;i<buildingPlaces.Length; i++)
        {
            if(buildingPlaces[i].childCount == 0)
            {
                return buildingPlaces[i];
            }
        }
        Debug.LogError("No available places!");
        return null;
    }
}
