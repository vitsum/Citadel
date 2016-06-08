using UnityEngine;
using System.Linq;
using Entitas;

public class TestPanel : MonoBehaviour {

	public void OnBuildClick()
    {
        var playerId = GetCurrentPlayerId();
        District district;
        if (TryGetRandomDistrict(playerId, out district)) {
            Pools.pool.CreateEntity().AddBuildDistrictOrder(district).AddOwner(playerId);
        }
    }

    public void OnTakeCoinsClick()
    {
        var playerId = GetCurrentPlayerId();
        Pools.pool.CreateEntity().IsTakeCoinsFromBankAction(true).AddOwner(playerId);
    }

    public void OnTakeCardsClick()
    {
        var playerId = GetCurrentPlayerId();
        Pools.pool.CreateEntity().IsTakeDistrictCardFromDeckAction(true).AddOwner(playerId);
    }

    public void OnFinishTurnClick()
    {

    }

    private int GetCurrentPlayerId()
    {
        var playerId = Pools.pool.GetEntities(Matcher.CurrentTurn).SingleEntity().currentTurn.CurrentPlayerId;
        return playerId;
    }

    private bool TryGetRandomDistrict(int playerId, out District district)
    {
        var gold = Pools.pool.GetEntities(Matcher.Player).FirstOrDefault(e => e.player.Id == playerId).gold.Count;
        var playerCards = Pools.pool.GetEntities(Matcher.AllOf(Matcher.DistrictCard, Matcher.Owner))
            .Where(c => c.owner.OwnerId == playerId && !c.hasBuilt && c.cost.Price <= gold);
        var count = playerCards.Count();
        if(count > 0)
        {
            district = playerCards.ElementAt(Random.Range(0, count)).districtCard.Type;
            return true;
        }

        district = District.Tavern;
        return false;
    }
}
