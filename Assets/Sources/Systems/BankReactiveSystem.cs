using System.Linq;
using System.Collections.Generic;
using Entitas;
using UnityEngine;

public class BankReactiveSystem : IReactiveSystem, ISetPool
{
    private Pool _pool;

    public TriggerOnEvent trigger
    {
        get
        {
            return Matcher.TakeCoinsFromBankAction.OnEntityAdded();
        }
    }

    public void Execute(List<Entity> entities)
    {
        foreach(var entity in entities)
        {
            var currentTurn = _pool.GetEntities(Matcher.CurrentTurn).SingleEntity();

            if (!currentTurn.isActionDone)
            {
                var player = _pool.GetEntities(Matcher.Player).First(p => p.player.Id == entity.owner.OwnerId);
                player.ReplaceGold(player.gold.Count + 2);

                currentTurn.IsActionDone(true);
            } else
            {
                Debug.Log("Action already done");
            }
            _pool.DestroyEntity(entity);
        }
    }

    public void SetPool(Pool pool)
    {
        _pool = pool;
    }
}