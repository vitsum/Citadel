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
        public BuiltComponent built { get { return (BuiltComponent)GetComponent(ComponentIds.Built); } }

        public bool hasBuilt { get { return HasComponent(ComponentIds.Built); } }

        public Entity AddBuilt(UnityEngine.GameObject newView) {
            var component = CreateComponent<BuiltComponent>(ComponentIds.Built);
            component.View = newView;
            return AddComponent(ComponentIds.Built, component);
        }

        public Entity ReplaceBuilt(UnityEngine.GameObject newView) {
            var component = CreateComponent<BuiltComponent>(ComponentIds.Built);
            component.View = newView;
            ReplaceComponent(ComponentIds.Built, component);
            return this;
        }

        public Entity RemoveBuilt() {
            return RemoveComponent(ComponentIds.Built);
        }
    }

    public partial class Matcher {
        static IMatcher _matcherBuilt;

        public static IMatcher Built {
            get {
                if (_matcherBuilt == null) {
                    var matcher = (Matcher)Matcher.AllOf(ComponentIds.Built);
                    matcher.componentNames = ComponentIds.componentNames;
                    _matcherBuilt = matcher;
                }

                return _matcherBuilt;
            }
        }
    }
}