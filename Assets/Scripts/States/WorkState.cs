using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using States;
using System;

public class WorkState : State<Student>
{
    private static WorkState _instance;

    private WorkState()
    {
        if (_instance != null)
        {
            return;
        }

        _instance = this;
    }

    public static WorkState Instance
    {
        get
        {
            if (_instance == null)
            {
                new WorkState();
            }

            return _instance;
        }
    }

    public override void EnterState(Student _owner)
    {
        Debug.Log("Entering Study State");
    }

    public override void ExitState(Student _owner)
    {
        Debug.Log("Exiting Study State");
        _owner.StateMachine.ChangeState(CalculateTaskState.Instance);
    }

    public override void UpdateState(Student _owner)
    {

    }
}
