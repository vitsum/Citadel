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
        static readonly GreenComponent greenComponent = new GreenComponent();

        public bool isGreen {
            get { return HasComponent(ComponentIds.Green); }
            set {
                if (value != isGreen) {
                    if (value) {
                        AddComponent(ComponentIds.Green, greenComponent);
                    } else {
                        RemoveComponent(ComponentIds.Green);
                    }
                }
            }
        }

        public Entity IsGreen(bool value) {
            isGreen = value;
            return this;
        }
    }

    public partial class Matcher {
        static IMatcher _matcherGreen;

        public static IMatcher Green {
            get {
                if (_matcherGreen == null) {
                    var matcher = (Matcher)Matcher.AllOf(ComponentIds.Green);
                    matcher.componentNames = ComponentIds.componentNames;
                    _matcherGreen = matcher;
                }

                return _matcherGreen;
            }
        }
    }
}
