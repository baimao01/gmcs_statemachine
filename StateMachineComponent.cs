using Godot;
using System.Collections.Generic;
using GMCS;

namespace GMCS.StateMachine;

public partial class StateMachineComponent : IComponent
{
    public Dictionary<string, IState> states = new();
    public IState currState;
    public IState prevState;

    public virtual bool CheckCurrState()
    {
        if (currState == null)
        {
            GD.Print("[StateMachine] -> current state is null");
            return false;
        }
        return true;
    }

    public virtual bool CheckStates()
    {
        if (states == null || states.Count == 0)
        {
            GD.Print("[StateMachine] -> no states");
            return false;
        }
        return true;
    }

    public virtual void Init()
    {
        if (!CheckStates())
            return;

        foreach (IState state in states.Values)
        {
            state._Register();
            state.EmitSignal(IState.SignalName.Register);
            state._Ready();
            state.EmitSignal(IState.SignalName.Ready);
        }
    }

    public virtual void SwitchState(string name)
    {
        if (!CheckStates())
            return;

        if (CheckCurrState())
        {
            currState._Exit();
            prevState = currState;
        }

        currState = states[name];
        currState._Enter();
    }
}
