using System.Linq;
using System.Collections.Generic;
using Entitas;
using UnityEngine;

public class PrepareTheDeckForChoosingCharactersSystem : IReactiveSystem, ISetPool
{
    private Pool _pool;
    public TriggerOnEvent trigger
    {
        get
        {
            return Matcher.StartChoosingCharactersEvent.OnEntityAdded();
        }
    }

    public void Execute(List<Entity> entities)
    {
        foreach(var entity in entities)
        {
            var playerCount = _pool.playersCount.Count;

            var availableCards = _pool.GetEntities(Matcher.AvailableCharacter);
            foreach(var card in availableCards)
            {
                card.IsInTheDeck(true).IsFaceDown(false).IsFaceUp(false);
                if (card.hasOwner)
                {
                    card.RemoveOwner();
                }
            }

            var randomCard = GetRandomCardFromTheDeck();
            randomCard.IsInTheDeck(false);
            randomCard.IsFaceDown(true);

            if(playerCount >= 4 && playerCount <= 5)
            {
                var cardsFaceUpCount = 6 - playerCount; // 4 - 2, 5 - 1, 6/7 - 0
                for(int i=0; i<cardsFaceUpCount; i++)
                {
                    randomCard = GetRandomCardFromTheDeck();
                    if(randomCard.character.Type == Character.King || randomCard.character.Type == Character.Emperor)
                    {
                        i--;
                        continue;
                    }
                    randomCard.IsInTheDeck(false);
                    randomCard.IsFaceUp(true);
                }
            }

            var currentPlayerId = _pool.currentTurn.CurrentPlayerId;

            _pool.DestroyEntity(_pool.currentTurnEntity);
            _pool.CreateEntity().AddCurrentTurn(currentPlayerId).IsChoosingCharacters(true);

            _pool.DestroyEntity(entity);
        }
    }

    public void SetPool(Pool pool)
    {
        _pool = pool;
    }

    private Entity GetRandomCardFromTheDeck()
    {
        var cardsInTheDeck = _pool.GetEntities(Matcher.AllOf(Matcher.AvailableCharacter, Matcher.InTheDeck));
        return cardsInTheDeck.ElementAt(Random.Range(0, cardsInTheDeck.Count()));
    }
}
