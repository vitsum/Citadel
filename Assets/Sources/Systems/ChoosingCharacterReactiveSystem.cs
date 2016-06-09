using System;
using System.Collections.Generic;
using Entitas;
using System.Linq;
using UnityEngine;

public class ChoosingCharacterReactiveSystem : IReactiveSystem, ISetPool
{
    private Pool _pool;

    public TriggerOnEvent trigger
    {
        get
        {
            return Matcher.ChooseCharacterIntent.OnEntityAdded();
        }
    }

    public void Execute(List<Entity> entities)
    {
        foreach(var entity in entities)
        {
            var characterCard = GetRequestedCardFromTheDeck(entity);

            if(characterCard == null)
            {
                Debug.LogWarning("Player tryied to take character which isn't in the deck");
                _pool.DestroyEntity(entity);
                continue;
            }

            OkGiveHimThisCard(characterCard, entity.owner);

            _pool.currentTurnEntity.IsCharacterChosen(true);
            
            if (CharactersWithOwnersCount() < CharacterCountAllPlayerShouldHave())
            {
                NextTurn();
            } else
            {
                PutRemainingCardsFaceDown();
                _pool.DestroyEntity(_pool.currentTurnEntity);
                _pool.CreateEntity().AddCurrentTurn(0).IsPlaying(true).AddBuildCount(1);
                _pool.CreateEntity().IsKingCallsNextEvent(true);
            }

            _pool.DestroyEntity(entity);
        }
    }

    private Entity GetRequestedCardFromTheDeck(Entity entity)
    {
        var type = entity.chooseCharacterIntent.Type;
        return _pool.GetEntities(
            Matcher.AllOf(
                Matcher.Character,
                Matcher.AvailableCharacter,
                Matcher.InTheDeck))
            .FirstOrDefault(e => e.character.Type == type);
    }

    private void OkGiveHimThisCard(Entity card, OwnerComponent owner)
    {
        card.IsInTheDeck(false).ReplaceOwner(owner.OwnerId);
    }

    private void NextTurn()
    {
        _pool.ReplaceCurrentTurn((_pool.currentTurn.CurrentPlayerId + 1) % _pool.playersCount.Count);
    }

    private int CharactersWithOwnersCount()
    {
        return _pool.GetEntities(
            Matcher.AllOf(
                Matcher.Character,
                Matcher.AvailableCharacter,
                Matcher.Owner))
                .Count();
    }

    private int CharacterCountAllPlayerShouldHave()
    {
        return _pool.playersCount.Count > 3 ? _pool.playersCount.Count : _pool.playersCount.Count * 2;
    }

    private void PutRemainingCardsFaceDown()
    {
        var remainingCards = _pool.GetEntities(
            Matcher.AllOf(
                Matcher.Character,
                Matcher.AvailableCharacter,
                Matcher.InTheDeck));
        foreach (var card in remainingCards)
        {
            card.IsInTheDeck(false).IsFaceDown(true);
        }
    }

    public void SetPool(Pool pool)
    {
        _pool = pool;
    }
}
