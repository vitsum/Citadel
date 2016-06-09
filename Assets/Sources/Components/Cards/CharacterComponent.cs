using Entitas;

public class CharacterComponent : IComponent
{
    public Character Type;
    public int Index;
}

public enum Character
{
    Assassin,
    Thief,
    Magician,
    King,
    Bishop,
    Merchant,
    Architect,
    Warlord,

    Witch,
    TaxCollector,
    Wizard,
    Emperor,
    Abbot,
    Alchemist,
    Navigator,
    Diplomat,
    Artist,
    Queen
}

