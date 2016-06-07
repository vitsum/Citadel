using Entitas;
using Entitas.CodeGenerator;

[SingleEntity]
public class CurrentTurnComponent : IComponent
{
    public int CurrentPlayerId;
}