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
        static readonly TakeCoinsFromBankActionComponent takeCoinsFromBankActionComponent = new TakeCoinsFromBankActionComponent();

        public bool isTakeCoinsFromBankAction {
            get { return HasComponent(ComponentIds.TakeCoinsFromBankAction); }
            set {
                if (value != isTakeCoinsFromBankAction) {
                    if (value) {
                        AddComponent(ComponentIds.TakeCoinsFromBankAction, takeCoinsFromBankActionComponent);
                    } else {
                        RemoveComponent(ComponentIds.TakeCoinsFromBankAction);
                    }
                }
            }
        }

        public Entity IsTakeCoinsFromBankAction(bool value) {
            isTakeCoinsFromBankAction = value;
            return this;
        }
    }

    public partial class Matcher {
        static IMatcher _matcherTakeCoinsFromBankAction;

        public static IMatcher TakeCoinsFromBankAction {
            get {
                if (_matcherTakeCoinsFromBankAction == null) {
                    var matcher = (Matcher)Matcher.AllOf(ComponentIds.TakeCoinsFromBankAction);
                    matcher.componentNames = ComponentIds.componentNames;
                    _matcherTakeCoinsFromBankAction = matcher;
                }

                return _matcherTakeCoinsFromBankAction;
            }
        }
    }
}