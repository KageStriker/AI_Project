using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using States;

public class GraduateState : State<Student>
{
    private static GraduateState _instance;

    private GraduateState()
    {
        if (_instance != null)
        {
            return;
        }

        _instance = this;
    }

    public static GraduateState Instance
    {
        get
        {
            if (_instance == null)
            {
                new GraduateState();
            }

            return _instance;
        }
    }

    public override void EnterState(Student _owner)
    {
        Debug.Log("Entering Graduate State");
    }

    public override void ExitState(Student _owner)
    {
        Debug.Log("Exiting Graduate State");
    }

    public override void UpdateState(Student _owner)
    {
    }
}
