using UnityEngine;
using System.Collections;
using Entitas;
using Entitas.Unity.VisualDebugging;

public class GameController : MonoBehaviour {

    Systems _systems;
    
	void Start () {
        _systems = CreateSystems(Pools.pool);
	}
	
	void Update () {
        _systems.Execute();
	}

    Systems CreateSystems(Pool pool)
    {
#if (UNITY_EDITOR)
        return new DebugSystems();
#else
        return new Systems()
#endif
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
