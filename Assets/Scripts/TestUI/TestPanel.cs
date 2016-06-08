using UnityEngine;
using System.Linq;
using Entitas;

public class TestPanel : MonoBehaviour {

	public void OnBuildClick()
    {
        var playerId = Pools.pool.GetEntities(Matcher.CurrentTurn).SingleEntity().currentTurn.CurrentPlayerId;
        District district;
        if (TryGetRandomDistrict(playerId, out district)) {
            Pools.pool.CreateEntity().AddBuildDistrictOrder(district).AddOwner(playerId);
        }
    }

    public void FinishTurn()
    {

    }

    private bool TryGetRandomDistrict(int playerId, out District district)
    {
        var playerCards = Pools.pool.GetEntities(Matcher.AllOf(Matcher.DistrictCard, Matcher.Owner))
            .Where(c => c.owner.OwnerId == playerId && !c.hasBuilt);
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
