using Godot;

namespace GMCS.StateMachine;

public partial class IState : GodotObject
{
    [Signal] public delegate void RegisterEventHandler();
    [Signal] public delegate void ReadyEventHandler();

    public virtual void _Register()
    {
    }

    public virtual void _Ready()
    {
    }

    public virtual void _Enter()
    {
    }

    public virtual void _Process(double delta)
    {
    }

    public virtual void _PhysicsProcess(double delta)
    {
    }

    public virtual void _Exit()
    {
    }
}
