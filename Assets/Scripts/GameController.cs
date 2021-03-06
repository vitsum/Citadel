﻿using UnityEngine;
using System.Linq;
using Entitas;
using Entitas.Unity.VisualDebugging;

public class GameController : MonoBehaviour {

    Systems _systems;

    [SerializeField]
    CityPlacerSystem _cityPlacerSystem;
    [SerializeField]
    BuildingSystem _buildingSystem;

	void Start () {
        _systems = CreateSystems(Pools.pool);

        var playerCount = Random.Range(2, 9);
        Pools.pool.CreateEntity().AddPlayersCount(playerCount);

        _systems.Initialize();                
	}
	
	void Update () {
        _systems.Execute();
	}

    Systems CreateSystems(Pool pool)
    {
#if (UNITY_EDITOR)
        return new DebugSystems()
#else
        return new Systems()
#endif
        //initializers
        .Add(pool.CreateSystem(_cityPlacerSystem))
        .Add(pool.CreateSystem<FirstTurnSystem>())
        .Add(pool.CreateSystem<CharacterCardsInitializeSystem>())
        .Add(pool.CreateSystem<DefaultSetOfCharactersInitializeSystem>())
        .Add(pool.CreateSystem<DistrictCardsInitializeSystem>())
        .Add(pool.CreateSystem<CardDealingSystem>())
        .Add(pool.CreateSystem<GoldInitializeSystem>())

        .Add(pool.CreateSystem<PrepareTheDeckForChoosingCharactersSystem>())
        .Add(pool.CreateSystem<ChoosingCharacterReactiveSystem>())
        .Add(pool.CreateSystem<NextTurnChoosingCharacterReactiveSystem>())
        .Add(pool.CreateSystem<NextTurnPlayingReactiveSystem>())
        .Add(pool.CreateSystem<KingCallsNextReactiveSystem>())
        .Add(pool.CreateSystem<CurrentCharacterChangedReactiveSystem>())
        .Add(pool.CreateSystem<BankReactiveSystem>())
        .Add(pool.CreateSystem(_buildingSystem));
//            .Add(pool.CreateGameBoardSystem())
//            .Add(pool.CreateCreateGameBoardCacheSystem())
//            .Add(pool.CreateFallSystem())
//            .Add(pool.CreateFillSystem())
//
//            .Add(pool.CreateProcessInputSystem())
//
//            .Add(pool.CreateRemoveViewSystem())
//            .Add(pool.CreateAddViewSystem())
//            .Add(pool.CreateRenderPositionSystem())
//
//            //this will send the position of a soon to be destoyed entity
//            .Add(pool.CreateSendSystem())
//            .Add(pool.CreateDestroySystem())
//            .Add(pool.CreateScoreSystem());
    } 
}
