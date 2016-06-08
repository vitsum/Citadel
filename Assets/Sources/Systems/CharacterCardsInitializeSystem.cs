using System;
using Entitas;

public class CharacterCardsInitializeSystem : IInitializeSystem, ISetPool
{
    private Pool _pool;

    public void Initialize()
    {
        _pool.CreateEntity().AddCharacter(Character.Assassin, 1);
        _pool.CreateEntity().AddCharacter(Character.Thief, 2);
        _pool.CreateEntity().AddCharacter(Character.Magician, 3);
        _pool.CreateEntity().AddCharacter(Character.King, 4);
        _pool.CreateEntity().AddCharacter(Character.Bishop, 5);
        _pool.CreateEntity().AddCharacter(Character.Merchant, 6);
        _pool.CreateEntity().AddCharacter(Character.Architect, 7);
        _pool.CreateEntity().AddCharacter(Character.Warlord, 8);

        //expansion characters
        _pool.CreateEntity().AddCharacter(Character.Witch, 1).IsExpansion(true);
        _pool.CreateEntity().AddCharacter(Character.TaxCollector, 2).IsExpansion(true);
        _pool.CreateEntity().AddCharacter(Character.Wizard, 3).IsExpansion(true);
        _pool.CreateEntity().AddCharacter(Character.Emperor, 4).IsExpansion(true);
        _pool.CreateEntity().AddCharacter(Character.Abbot, 5).IsExpansion(true);
        _pool.CreateEntity().AddCharacter(Character.Alchemist, 6).IsExpansion(true);
        _pool.CreateEntity().AddCharacter(Character.Navigator, 7).IsExpansion(true);
        _pool.CreateEntity().AddCharacter(Character.Diplomat, 8).IsExpansion(true);
        _pool.CreateEntity().AddCharacter(Character.Artist, 9).IsExpansion(true);
        _pool.CreateEntity().AddCharacter(Character.Queen, 9).IsExpansion(true);
    }

    public void SetPool(Pool pool)
    {
        _pool = pool;
    }
}
