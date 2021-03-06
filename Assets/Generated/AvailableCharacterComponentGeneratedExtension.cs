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
        static readonly AvailableCharacterComponent availableCharacterComponent = new AvailableCharacterComponent();

        public bool isAvailableCharacter {
            get { return HasComponent(ComponentIds.AvailableCharacter); }
            set {
                if (value != isAvailableCharacter) {
                    if (value) {
                        AddComponent(ComponentIds.AvailableCharacter, availableCharacterComponent);
                    } else {
                        RemoveComponent(ComponentIds.AvailableCharacter);
                    }
                }
            }
        }

        public Entity IsAvailableCharacter(bool value) {
            isAvailableCharacter = value;
            return this;
        }
    }

    public partial class Matcher {
        static IMatcher _matcherAvailableCharacter;

        public static IMatcher AvailableCharacter {
            get {
                if (_matcherAvailableCharacter == null) {
                    var matcher = (Matcher)Matcher.AllOf(ComponentIds.AvailableCharacter);
                    matcher.componentNames = ComponentIds.componentNames;
                    _matcherAvailableCharacter = matcher;
                }

                return _matcherAvailableCharacter;
            }
        }
    }
}
