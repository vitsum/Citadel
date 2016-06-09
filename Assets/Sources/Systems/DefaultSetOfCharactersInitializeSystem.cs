using System.Linq;
using Entitas;

public class DefaultSetOfCharactersInitializeSystem : IInitializeSystem, ISetPool
{
    private Pool _pool;

    public void Initialize()
    {
        var notExpansionCharacters = _pool.GetEntities(Matcher.Character).Where(e => !e.isExpansion);
        foreach(var entity in notExpansionCharacters)
        {
            entity.IsAvailableCharacter(true);
        }
    }

    public void SetPool(Pool pool)
    {
        _pool = pool;
    }
}
