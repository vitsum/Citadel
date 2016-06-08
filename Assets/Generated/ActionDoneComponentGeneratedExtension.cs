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
        static readonly ActionDoneComponent actionDoneComponent = new ActionDoneComponent();

        public bool isActionDone {
            get { return HasComponent(ComponentIds.ActionDone); }
            set {
                if (value != isActionDone) {
                    if (value) {
                        AddComponent(ComponentIds.ActionDone, actionDoneComponent);
                    } else {
                        RemoveComponent(ComponentIds.ActionDone);
                    }
                }
            }
        }

        public Entity IsActionDone(bool value) {
            isActionDone = value;
            return this;
        }
    }

    public partial class Matcher {
        static IMatcher _matcherActionDone;

        public static IMatcher ActionDone {
            get {
                if (_matcherActionDone == null) {
                    var matcher = (Matcher)Matcher.AllOf(ComponentIds.ActionDone);
                    matcher.componentNames = ComponentIds.componentNames;
                    _matcherActionDone = matcher;
                }

                return _matcherActionDone;
            }
        }
    }
}
