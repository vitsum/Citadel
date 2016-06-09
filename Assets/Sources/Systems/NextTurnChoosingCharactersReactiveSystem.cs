using System;
using System.Collections.Generic;
using Entitas;
using UnityEngine;

public class NextTurnChoosingCharacterReactiveSystem : IReactiveSystem, ISetPool
{
    private Pool _pool;

    public TriggerOnEvent trigger
    {
        get
        {
            return Matcher.AllOf(Matcher.CurrentTurn, Matcher.ChoosingCharacters).OnEntityAdded();
        }
    }

    public void Execute(List<Entity> entities)
    {
        var currentTurn = _pool.GetEntities(Matcher.CurrentTurn).SingleEntity();
        currentTurn.IsCharacterChosen(false);

        var available = _pool.GetEntities(Matcher.AvailableCharacter);
    }

    public void SetPool(Pool pool)
    {
        _pool = pool;
    }
}