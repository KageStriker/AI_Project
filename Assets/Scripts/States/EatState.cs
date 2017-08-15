using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using States;

public class EatState : State<Student>
{
    private static EatState _instance;

    private EatState()
    {
        if (_instance != null)
        {
            return;
        }

        _instance = this;
    }

    public static EatState Instance
    {
        get
        {
            if (_instance == null)
            {
                new EatState();
            }

            return _instance;
        }
    }

    public override void EnterState(Student _owner)
    {
        Debug.Log("Entering Eating State");
    }

    public override void ExitState(Student _owner)
    {
        Debug.Log("Exiting Eating State");
    }

    public override void UpdateState(Student _owner)
    {
    }
}
