using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetupGameState : GameState
{
    [SerializeField] int __numberofPlayers = 2;

    bool _activated = false;

    public override void Enter()
    {
        Debug.Log("Setup: ...Entering");
        Debug.Log("Creating " + __numberofPlayers + " players");
        // CANT change state while still in Enter()/Exit() transition
        // DONT put ChangeState<> here
        _activated = false;
    }

    public override void Tick()
    {
        // admittedly hacky for a demo. You would usually have delays or Input
        if(_activated == false)
        {
            _activated = true;
            StateMachine.ChangeState<PlayerTurnGameState>();
        }
    }

    public override void Exit()
    {
        _activated = false;
        Debug.Log("Setup: Exiting...");
    }
}
