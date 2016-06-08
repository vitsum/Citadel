using System;
using System.Collections.Generic;
using System.Linq;
using Entitas;
using UnityEngine;

public class BuildingSystem : MonoBehaviour, IReactiveSystem, ISetPool
{
    private Pool _pool;

    public GameObject TavernPrefab;
    public GameObject MarketPrefab;
    public GameObject TradingPostPrefab;
    public GameObject DocksPrefab;
    public GameObject HarborPrefab;
    public GameObject TownHallPrefab;

    public GameObject TemplePrefab;
    public GameObject ChurchPrefab;
    public GameObject MonasteryPrefab;
    public GameObject CathedralPrefab;

    public GameObject WatchTowerPrefab;
    public GameObject PrisonPrefab;
    public GameObject BattlefieldPrefab;
    public GameObject FortressPrefab;

    public GameObject ManorPrefab;
    public GameObject CastlePrefab;
    public GameObject PalacePrefab;

    public GameObject HauntedCityPrefab;
    public GameObject KeepPrefab;
    public GameObject LaboratoryPrefab;
    public GameObject SmithyPrefab;
    public GameObject GraveyardPrefab;
    public GameObject ObservatoryPrefab;
    public GameObject SchoolOfMagicPrefab;
    public GameObject LibraryPrefab;
    public GameObject GreatWallPrefab; 
    public GameObject UniversityPrefab;
    public GameObject DragonGatePrefab;

    private Dictionary<District, GameObject> districts;

    public TriggerOnEvent trigger
    {
        get
        {
            return Matcher.AllOf(Matcher.BuildDistrictOrder, Matcher.Owner).OnEntityAdded();
        }
    }

    void Awake()
    {
        districts = new Dictionary<District, GameObject>();
        districts.Add(District.Tavern, TavernPrefab);
        districts.Add(District.Market, MarketPrefab);
        districts.Add(District.TradingPost,TradingPostPrefab);
        districts.Add(District.Docks, DocksPrefab);
        districts.Add(District.Harbor, HarborPrefab);
        districts.Add(District.TownHall, TownHallPrefab);

        districts.Add(District.Temple, TemplePrefab);
        districts.Add(District.Church, ChurchPrefab);
        districts.Add(District.Monastery, MonasteryPrefab);
        districts.Add(District.Cathedral, CathedralPrefab);

        districts.Add(District.Watchtower, WatchTowerPrefab);
        districts.Add(District.Prison, PrisonPrefab);
        districts.Add(District.Battlefield, BattlefieldPrefab);
        districts.Add(District.Fortress, FortressPrefab);

        districts.Add(District.Manor, ManorPrefab);
        districts.Add(District.Castle, CastlePrefab);
        districts.Add(District.Palace, PalacePrefab);

        districts.Add(District.HauntedCity, HauntedCityPrefab);
        districts.Add(District.Keep, KeepPrefab);
        districts.Add(District.Laboratory, LaboratoryPrefab);
        districts.Add(District.Smithy, SmithyPrefab);
        districts.Add(District.Graveyard, GraveyardPrefab);
        districts.Add(District.Observatory, ObservatoryPrefab);
        districts.Add(District.SchoolOfMagic, SchoolOfMagicPrefab);
        districts.Add(District.Library, LibraryPrefab);
        districts.Add(District.GreatWall, GreatWallPrefab);
        districts.Add(District.University, UniversityPrefab);
        districts.Add(District.DragonGate, DragonGatePrefab);
    }


    public void Execute(List<Entity> entities)
    {
        foreach(var entity in entities)
        {
            var ownerId = entity.owner.OwnerId;
            var player = _pool.GetEntities(Matcher.Player).FirstOrDefault(e => e.player.Id == ownerId);
            var currentTurn = _pool.GetEntities(Matcher.CurrentTurn).SingleEntity();

            if(currentTurn.buildCount.Count == 0)
            {
                Debug.LogError("Can't build in this turn anymore");
                _pool.DestroyEntity(entity);
                continue;
            }

            var districtType = entity.buildDistrictOrder.Type;
            var cards = _pool.GetEntities(Matcher.AllOf(Matcher.DistrictCard, Matcher.Owner));
            var availableCards = cards.Where(c => !c.hasBuilt && c.owner.OwnerId == ownerId);
            var targetCard = availableCards.FirstOrDefault(c => c.districtCard.Type == districtType);

            if (targetCard == null)
            {
                Debug.LogError("Player doesn't have such card");
                _pool.DestroyEntity(entity);
                continue;
            }

            if (targetCard.cost.Price > player.gold.Count)
            {
                Debug.LogError("Not enough gold");
                _pool.DestroyEntity(entity);
                continue;
            }
            
            var cityEntity = _pool.GetEntities(Matcher.City).Where(c => c.owner.OwnerId == ownerId).FirstOrDefault();
            var place = cityEntity.city.City.GetFirstAvailablePlace();
            if (place == null)
            {
                Debug.LogError("No place to build");
                _pool.DestroyEntity(entity);
                continue;
            }
            
            var district = Instantiate(districts[districtType], place.position, place.rotation) as GameObject;
            district.transform.SetParent(place);
            targetCard.AddBuilt(district);

            player.ReplaceGold(player.gold.Count - targetCard.cost.Price);
            currentTurn.ReplaceBuildCount(currentTurn.buildCount.Count - 1);

            _pool.DestroyEntity(entity);
        }
    }

    public void SetPool(Pool pool)
    {
        _pool = pool;
    }
}
