using System;
using Entitas;
public class DistrictCardsInitializeSystem : IInitializeSystem, ISetPool
{
    private Pool _pool;
    public void Initialize()
    {
        //green
        Repeat(5, () => _pool.CreateEntity().AddDistrictCard(District.Tavern).AddCost(1).IsGreen(true).IsInTheDeck(true));
        Repeat(4, () => _pool.CreateEntity().AddDistrictCard(District.Market).AddCost(2).IsGreen(true).IsInTheDeck(true));
        Repeat(3, () => _pool.CreateEntity().AddDistrictCard(District.TradingPost).AddCost(2).IsGreen(true).IsInTheDeck(true));
        Repeat(3, () => _pool.CreateEntity().AddDistrictCard(District.Docks).AddCost(3).IsGreen(true).IsInTheDeck(true));
        Repeat(3, () => _pool.CreateEntity().AddDistrictCard(District.Harbor).AddCost(4).IsGreen(true).IsInTheDeck(true));
        Repeat(2, () => _pool.CreateEntity().AddDistrictCard(District.TownHall).AddCost(5).IsGreen(true).IsInTheDeck(true));

        //blue
        Repeat(3, () => _pool.CreateEntity().AddDistrictCard(District.Temple).AddCost(1).IsBlue(true).IsInTheDeck(true));
        Repeat(3, () => _pool.CreateEntity().AddDistrictCard(District.Church).AddCost(2).IsBlue(true).IsInTheDeck(true));
        Repeat(3, () => _pool.CreateEntity().AddDistrictCard(District.Monastery).AddCost(3).IsBlue(true).IsInTheDeck(true));
        Repeat(2, () => _pool.CreateEntity().AddDistrictCard(District.Cathedral).AddCost(5).IsBlue(true).IsInTheDeck(true));

        //red
        Repeat(3, () => _pool.CreateEntity().AddDistrictCard(District.Watchtower).AddCost(1).IsRed(true).IsInTheDeck(true));
        Repeat(3, () => _pool.CreateEntity().AddDistrictCard(District.Prison).AddCost(2).IsRed(true).IsInTheDeck(true));
        Repeat(3, () => _pool.CreateEntity().AddDistrictCard(District.Battlefield).AddCost(3).IsRed(true).IsInTheDeck(true));
        Repeat(2, () => _pool.CreateEntity().AddDistrictCard(District.Fortress).AddCost(5).IsRed(true).IsInTheDeck(true));

        //purple
        Repeat(1, () => _pool.CreateEntity().AddDistrictCard(District.HauntedCity).AddCost(2).IsPurple(true).IsInTheDeck(true));
        Repeat(2, () => _pool.CreateEntity().AddDistrictCard(District.Keep).AddCost(3).IsPurple(true).IsInTheDeck(true));
        Repeat(1, () => _pool.CreateEntity().AddDistrictCard(District.Laboratory).AddCost(5).IsPurple(true).IsInTheDeck(true));
        Repeat(1, () => _pool.CreateEntity().AddDistrictCard(District.Smithy).AddCost(5).IsPurple(true).IsInTheDeck(true));
        Repeat(1, () => _pool.CreateEntity().AddDistrictCard(District.Graveyard).AddCost(5).IsPurple(true).IsInTheDeck(true));
        Repeat(1, () => _pool.CreateEntity().AddDistrictCard(District.Observatory).AddCost(5).IsPurple(true).IsInTheDeck(true));
        Repeat(1, () => _pool.CreateEntity().AddDistrictCard(District.SchoolOfMagic).AddCost(6).IsPurple(true).IsInTheDeck(true));
        Repeat(1, () => _pool.CreateEntity().AddDistrictCard(District.Library).AddCost(6).IsPurple(true).IsInTheDeck(true));
        Repeat(1, () => _pool.CreateEntity().AddDistrictCard(District.GreatWall).AddCost(6).IsPurple(true).IsInTheDeck(true));
        Repeat(1, () => _pool.CreateEntity().AddDistrictCard(District.University).AddCost(6).AddAdditionalCost(2).IsPurple(true).IsInTheDeck(true));
        Repeat(1, () => _pool.CreateEntity().AddDistrictCard(District.DragonGate).AddCost(6).AddAdditionalCost(2).IsPurple(true).IsInTheDeck(true));
    }

    public void SetPool(Pool pool)
    {
        _pool = pool;
    }

    private void Repeat(int count, Action action)
    {
        for(int i=0; i< count; i++)
        {
            action();
        }
    }
}
