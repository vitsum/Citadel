//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGenerator.ComponentExtensionsGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
namespace Entitas {
    public partial class Entity {
        public CurrentTurnComponent currentTurn { get { return (CurrentTurnComponent)GetComponent(ComponentIds.CurrentTurn); } }

        public bool hasCurrentTurn { get { return HasComponent(ComponentIds.CurrentTurn); } }

        public Entity AddCurrentTurn(int newCurrentPlayerId) {
            var component = CreateComponent<CurrentTurnComponent>(ComponentIds.CurrentTurn);
            component.CurrentPlayerId = newCurrentPlayerId;
            return AddComponent(ComponentIds.CurrentTurn, component);
        }

        public Entity ReplaceCurrentTurn(int newCurrentPlayerId) {
            var component = CreateComponent<CurrentTurnComponent>(ComponentIds.CurrentTurn);
            component.CurrentPlayerId = newCurrentPlayerId;
            ReplaceComponent(ComponentIds.CurrentTurn, component);
            return this;
        }

        public Entity RemoveCurrentTurn() {
            return RemoveComponent(ComponentIds.CurrentTurn);
        }
    }

    public partial class Pool {
        public Entity currentTurnEntity { get { return GetGroup(Matcher.CurrentTurn).GetSingleEntity(); } }

        public CurrentTurnComponent currentTurn { get { return currentTurnEntity.currentTurn; } }

        public bool hasCurrentTurn { get { return currentTurnEntity != null; } }

        public Entity SetCurrentTurn(int newCurrentPlayerId) {
            if (hasCurrentTurn) {
                throw new EntitasException("Could not set currentTurn!\n" + this + " already has an entity with CurrentTurnComponent!",
                    "You should check if the pool already has a currentTurnEntity before setting it or use pool.ReplaceCurrentTurn().");
            }
            var entity = CreateEntity();
            entity.AddCurrentTurn(newCurrentPlayerId);
            return entity;
        }

        public Entity ReplaceCurrentTurn(int newCurrentPlayerId) {
            var entity = currentTurnEntity;
            if (entity == null) {
                entity = SetCurrentTurn(newCurrentPlayerId);
            } else {
                entity.ReplaceCurrentTurn(newCurrentPlayerId);
            }

            return entity;
        }

        public void RemoveCurrentTurn() {
            DestroyEntity(currentTurnEntity);
        }
    }

    public partial class Matcher {
        static IMatcher _matcherCurrentTurn;

        public static IMatcher CurrentTurn {
            get {
                if (_matcherCurrentTurn == null) {
                    var matcher = (Matcher)Matcher.AllOf(ComponentIds.CurrentTurn);
                    matcher.componentNames = ComponentIds.componentNames;
                    _matcherCurrentTurn = matcher;
                }

                return _matcherCurrentTurn;
            }
        }
    }
}
