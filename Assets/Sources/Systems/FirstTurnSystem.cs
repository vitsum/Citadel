using Entitas;
using UnityEngine;
using System.Linq;

class FirstTurnSystem : ISetPool, IInitializeSystem
{
    private Pool _pool;

    public void Initialize()
    {
        int playerCount = _pool.GetEntities(Matcher.PlayersCount).SingleEntity().playersCount.Count;
        int playerId = Random.Range(0, playerCount);
        _pool.ReplaceCurrentTurn(playerId);
        var player = _pool.GetEntities(Matcher.Player).FirstOrDefault(e => e.player.Id == playerId);
        player.IsCrown(true);
        _pool.CreateEntity().IsStartChoosingCharactersEvent(true);
    }

    public void SetPool(Pool pool)
    {
        _pool = pool;
    }
}
