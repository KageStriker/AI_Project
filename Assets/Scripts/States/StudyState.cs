using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using States;
using System;

public class StudyState : State<Student>
{
    private static StudyState _instance;
    
    private StudyState()
    {
        if(_instance != null)
        {
            return;
        }

        _instance = this;
    }

    public static StudyState Instance
    {
        get
        {
            if(_instance == null)
            {
                new StudyState();
            }

            return _instance;
        }
    }

    public override void EnterState(Student _owner)
    {
        Debug.Log("Entering Study State");

        _owner.StartCoroutine(_owner.WaitForDuration(10.0f));
    }

    public override void ExitState(Student _owner)
    {
        Debug.Log("Exiting Study State");
    }

    public override void UpdateState(Student _owner)
    {
        if(_owner.waitComplete)
        {
            _owner.StateMachine.ChangeState(CalculateTaskState.Instance);
            _owner.waitComplete = false;
        }

        _owner.SetEnergy(_owner.GetEnergy() - (Time.deltaTime * 1.5f));
        _owner.SetStamina(_owner.GetStamina() - (Time.deltaTime * 1.3f));
    }
}
