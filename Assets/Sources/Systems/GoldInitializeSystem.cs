using System;
using Entitas;

public class GoldInitializeSystem : ISetPool, IInitializeSystem
{
    private Pool _pool;

    public void Initialize()
    {
        var players = _pool.GetEntities(Matcher.Player);
        foreach(var player in players)
        {
            player.AddGold(2);
        }
    }

    public void SetPool(Pool pool)
    {
        _pool = pool;
    }
}
