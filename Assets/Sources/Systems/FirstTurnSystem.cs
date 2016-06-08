using Entitas;
using UnityEngine;

class FirstTurnSystem : ISetPool, IInitializeSystem
{
    private Pool _pool;

    public void Initialize()
    {
        int playerCount = _pool.GetEntities(Matcher.PlayersCount).SingleEntity().playersCount.Count;
        _pool.CreateEntity().AddCurrentTurn(Random.Range(0, playerCount));
    }

    public void SetPool(Pool pool)
    {
        _pool = pool;
    }
}
