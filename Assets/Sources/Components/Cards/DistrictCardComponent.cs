using Entitas;

public class DistrictCardComponent : IComponent
{
    public District Type;
}

public enum District
{
    //green

    Tavern,
    Market,
    TradingPost,
    Docks,
    Harbor,
    TownHall,

    //blue

    Temple,
    Church,
    Monastery,
    Cathedral,

    //red

    Watchtower,
    Prison,
    Battlefield,
    Fortress,

    //yellow

    Manor,
    Castle,
    Palace,

    //purple

    HauntedCity,
    Keep,
    Laboratory,
    Smithy,
    Graveyard,
    Observatory,
    SchoolOfMagic,
    Library,
    GreatWall,
    University,
    DragonGate
}