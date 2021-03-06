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
        public PlayersCountComponent playersCount { get { return (PlayersCountComponent)GetComponent(ComponentIds.PlayersCount); } }

        public bool hasPlayersCount { get { return HasComponent(ComponentIds.PlayersCount); } }

        public Entity AddPlayersCount(int newCount) {
            var component = CreateComponent<PlayersCountComponent>(ComponentIds.PlayersCount);
            component.Count = newCount;
            return AddComponent(ComponentIds.PlayersCount, component);
        }

        public Entity ReplacePlayersCount(int newCount) {
            var component = CreateComponent<PlayersCountComponent>(ComponentIds.PlayersCount);
            component.Count = newCount;
            ReplaceComponent(ComponentIds.PlayersCount, component);
            return this;
        }

        public Entity RemovePlayersCount() {
            return RemoveComponent(ComponentIds.PlayersCount);
        }
    }

    public partial class Pool {
        public Entity playersCountEntity { get { return GetGroup(Matcher.PlayersCount).GetSingleEntity(); } }

        public PlayersCountComponent playersCount { get { return playersCountEntity.playersCount; } }

        public bool hasPlayersCount { get { return playersCountEntity != null; } }

        public Entity SetPlayersCount(int newCount) {
            if (hasPlayersCount) {
                throw new EntitasException("Could not set playersCount!\n" + this + " already has an entity with PlayersCountComponent!",
                    "You should check if the pool already has a playersCountEntity before setting it or use pool.ReplacePlayersCount().");
            }
            var entity = CreateEntity();
            entity.AddPlayersCount(newCount);
            return entity;
        }

        public Entity ReplacePlayersCount(int newCount) {
            var entity = playersCountEntity;
            if (entity == null) {
                entity = SetPlayersCount(newCount);
            } else {
                entity.ReplacePlayersCount(newCount);
            }

            return entity;
        }

        public void RemovePlayersCount() {
            DestroyEntity(playersCountEntity);
        }
    }

    public partial class Matcher {
        static IMatcher _matcherPlayersCount;

        public static IMatcher PlayersCount {
            get {
                if (_matcherPlayersCount == null) {
                    var matcher = (Matcher)Matcher.AllOf(ComponentIds.PlayersCount);
                    matcher.componentNames = ComponentIds.componentNames;
                    _matcherPlayersCount = matcher;
                }

                return _matcherPlayersCount;
            }
        }
    }
}
