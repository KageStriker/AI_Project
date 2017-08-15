using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using States;

public class SleepState : State<Student>
{
    private static SleepState _instance;

    private SleepState()
    {
        if (_instance != null)
        {
            return;
        }

        _instance = this;
    }

    public static SleepState Instance
    {
        get
        {
            if (_instance == null)
            {
                new SleepState();
            }

            return _instance;
        }
    }

    public override void EnterState(Student _owner)
    {
        Debug.Log("Entering Sleep State");
    }

    public override void ExitState(Student _owner)
    {
        Debug.Log("Entering Sleep State");
    }

    public override void UpdateState(Student _owner)
    {
        
    }
}
