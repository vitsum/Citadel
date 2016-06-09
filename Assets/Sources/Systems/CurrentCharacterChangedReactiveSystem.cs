using System;
using System.Collections.Generic;
using Entitas;
public class CurrentCharacterChangedReactiveSystem : IReactiveSystem, ISetPool
{
    private Pool _pool;
    public TriggerOnEvent trigger
    {
        get
        {
            return Matcher.CurrentCharacter.OnEntityAdded();
        }
    }

    public void Execute(List<Entity> entities)
    {
        foreach(var entity in entities)
        {
            if (entity.hasOwner)
            {
                _pool.ReplaceCurrentTurn(entity.owner.OwnerId);
            }
            else
            {
                _pool.CreateEntity().IsKingCallsNextEvent(true); //nobody has this character so we ask the king to call new character
            }
        }
    }

    public void SetPool(Pool pool)
    {
        _pool = pool;
    }
}
