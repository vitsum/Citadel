using System.Linq;
using Entitas;
using UnityEngine;

public class CardDealingSystem : IInitializeSystem, ISetPool
{
    private Pool _pool;

    public void Initialize()
    {
        var players = _pool.GetEntities(Matcher.Player);
        foreach(var player in players)
        {
            for (int i = 0; i < 4; i++)
            {
                var id = player.player.Id;
                var randomCard = GetRandomCard();
                randomCard.IsInTheDeck(false);
                randomCard.AddOwner(id);
            }
        }
    }

    public void SetPool(Pool pool)
    {
        _pool = pool;
    }

    private Entity GetRandomCard()
    {
        var cards = _pool.GetEntities(Matcher.AllOf(Matcher.DistrictCard, Matcher.InTheDeck));
        var count = cards.Count();
        var index = Random.Range(0, count);
        var card = cards.ElementAt(index);
        return card;
    }
}
