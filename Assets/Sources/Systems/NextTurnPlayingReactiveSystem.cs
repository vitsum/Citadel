using System;
using System.Collections.Generic;
using Entitas;
using UnityEngine;

public class NextTurnPlayingReactiveSystem : IReactiveSystem, ISetPool
{
    private Pool _pool;

    public TriggerOnEvent trigger
    {
        get
        {
            return Matcher.AllOf(Matcher.CurrentTurn, Matcher.Playing).OnEntityAdded();
        }
    }

    public void Execute(List<Entity> entities)
    {
        var currentTurn = _pool.GetEntities(Matcher.CurrentTurn).SingleEntity();
        currentTurn.ReplaceBuildCount(1);
        currentTurn.IsActionDone(false);
    }

    public void SetPool(Pool pool)
    {
        _pool = pool;
    }
}
