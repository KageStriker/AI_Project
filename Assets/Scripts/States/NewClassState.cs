using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using States;
using System;

public class NewClassState : State<Student>
{
    private static NewClassState _instance;
    private List<Student> studentsEnrolled;
    
    private NewClassState()
    {
        if (_instance != null)
        {
            return;
        }

        _instance = this;
    }

    public static NewClassState Instance
    {
        get
        {
            if (_instance == null)
            {
                new NewClassState();
            }

            return _instance;
        }
    }

    public override void EnterState(Student _owner)
    {
        Debug.Log("Entering New Classroom State");
    }

    public override void ExitState(Student _owner)
    {
        Debug.Log("Exiting New Classroom State");
    }

    public override void UpdateState(Student _owner)
    {

    }
}
