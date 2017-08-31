using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using States;

public class CourseWorkState : State<Student>
{
    private static CourseWorkState _instance;

    private CourseWorkState()
    {
        if (_instance != null)
        {
            return;
        }

        _instance = this;
    }

    public static CourseWorkState Instance
    {
        get
        {
            if (_instance == null)
            {
                new CourseWorkState();
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

    }
}
