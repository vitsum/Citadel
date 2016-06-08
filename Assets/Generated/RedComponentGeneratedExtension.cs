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
        static readonly RedComponent redComponent = new RedComponent();

        public bool isRed {
            get { return HasComponent(ComponentIds.Red); }
            set {
                if (value != isRed) {
                    if (value) {
                        AddComponent(ComponentIds.Red, redComponent);
                    } else {
                        RemoveComponent(ComponentIds.Red);
                    }
                }
            }
        }

        public Entity IsRed(bool value) {
            isRed = value;
            return this;
        }
    }

    public partial class Matcher {
        static IMatcher _matcherRed;

        public static IMatcher Red {
            get {
                if (_matcherRed == null) {
                    var matcher = (Matcher)Matcher.AllOf(ComponentIds.Red);
                    matcher.componentNames = ComponentIds.componentNames;
                    _matcherRed = matcher;
                }

                return _matcherRed;
            }
        }
    }
}