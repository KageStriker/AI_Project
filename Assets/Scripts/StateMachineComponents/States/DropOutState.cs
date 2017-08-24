using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using States;

public class DropOutState : State<Student>
{
    private static DropOutState _instance;

    private DropOutState()
    {
        if (_instance != null)
        {
            return;
        }

        _instance = this;
    }

    public static DropOutState Instance
    {
        get
        {
            if (_instance == null)
            {
                new DropOutState();
            }

            return _instance;
        }
    }

    public override void EnterState(Student _owner)
    {
        Debug.Log("Entering Dropout State");
    }

    public override void ExitState(Student _owner)
    {
        Debug.Log("Exiting Dropout State");
    }

    public override void UpdateState(Student _owner)
    {
    }
}
