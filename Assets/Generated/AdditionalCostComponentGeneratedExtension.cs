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
        public AdditionalCostComponent additionalCost { get { return (AdditionalCostComponent)GetComponent(ComponentIds.AdditionalCost); } }

        public bool hasAdditionalCost { get { return HasComponent(ComponentIds.AdditionalCost); } }

        public Entity AddAdditionalCost(int newValue) {
            var component = CreateComponent<AdditionalCostComponent>(ComponentIds.AdditionalCost);
            component.Value = newValue;
            return AddComponent(ComponentIds.AdditionalCost, component);
        }

        public Entity ReplaceAdditionalCost(int newValue) {
            var component = CreateComponent<AdditionalCostComponent>(ComponentIds.AdditionalCost);
            component.Value = newValue;
            ReplaceComponent(ComponentIds.AdditionalCost, component);
            return this;
        }

        public Entity RemoveAdditionalCost() {
            return RemoveComponent(ComponentIds.AdditionalCost);
        }
    }

    public partial class Matcher {
        static IMatcher _matcherAdditionalCost;

        public static IMatcher AdditionalCost {
            get {
                if (_matcherAdditionalCost == null) {
                    var matcher = (Matcher)Matcher.AllOf(ComponentIds.AdditionalCost);
                    matcher.componentNames = ComponentIds.componentNames;
                    _matcherAdditionalCost = matcher;
                }

                return _matcherAdditionalCost;
            }
        }
    }
}
