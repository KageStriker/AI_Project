using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using States;
using System;

public class IdleState : State<Student>
{
    private static IdleState _instance;

    private IdleState()
    {
        if (_instance != null)
        {
            return;
        }

        _instance = this;
    }

    public static IdleState Instance
    {
        get
        {
            if (_instance == null)
            {
                new IdleState();
            }

            return _instance;
        }
    }
    
    public override void EnterState(Student _owner)
    {
        Debug.Log("Entering Idle State");
        
    }

    public override void ExitState(Student _owner)
    {
        Debug.Log("Exiting Idle State");
    }

    public override void UpdateState(Student _owner)
    {
        if (_owner.waitComplete)
        {
            _owner.StateMachine.ChangeState(CalculateTaskState.Instance);
        }
    }
}
