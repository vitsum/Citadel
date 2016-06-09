using System.Linq;
using System.Collections.Generic;
using Entitas;

public class KingCallsNextReactiveSystem : IReactiveSystem, ISetPool
{
    private Pool _pool;

    public TriggerOnEvent trigger
    {
        get
        {
            return Matcher.KingCallsNextEvent.OnEntityAdded();
        }
    }

    public void Execute(List<Entity> entities)
    {
        foreach(var entity in entities)
        {
            var currentCharacters = _pool.GetEntities(Matcher.CurrentCharacter);
            int index = 0;
            var availableCharacters = _pool.GetEntities(Matcher.AllOf(Matcher.AvailableCharacter));
            var charactersCount = availableCharacters.Count();

            var currentCharacter = currentCharacters.FirstOrDefault();
            if (currentCharacter != null)
            {
                currentCharacter.IsCurrentCharacter(false);
                index = currentCharacter.character.Index;
            }

            if(index < charactersCount)
            {
                index++;
                var nextCharacter = _pool.GetEntities(Matcher.AllOf(Matcher.AvailableCharacter)).First(e => e.character.Index == index);
                nextCharacter.IsCurrentCharacter(true);
            } else
            {
                _pool.CreateEntity().IsStartChoosingCharactersEvent(true);
            }            

            _pool.DestroyEntity(entity);
        }
    }

    public void SetPool(Pool pool)
    {
        _pool = pool;
    }
}

