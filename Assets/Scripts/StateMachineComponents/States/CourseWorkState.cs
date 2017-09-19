using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using States;

public class CourseWorkState : State<Student>
{
    private static CourseWorkState _instance;
    private float timeToStudy;
    private float energyDrainMultiplier;
    private float staminaDrainMultiplier;

    private CourseWorkState()
    {
        if (_instance != null)
        {
            return;
        }

        _instance = this;

        timeToStudy = 10.0f;
        energyDrainMultiplier = 0.9f;
        staminaDrainMultiplier = 0.6f;
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
        _owner.StartCoroutine(_owner.WaitForDuration(timeToStudy));
    }

    public override void ExitState(Student _owner)
    {
        Debug.Log("Exiting Idle State");
    }

    public override void UpdateState(Student _owner)
    {
        _owner.SetStamina(_owner.GetStamina() - (Time.deltaTime * staminaDrainMultiplier));
        _owner.SetEnergy(_owner.GetEnergy() - (Time.deltaTime * energyDrainMultiplier));
        _owner.SetCourseExp(_owner.GetCourseExp() + (Time.deltaTime * 2.5f));

        if(_owner.GetCourseExp() >= 100)
        {
            _owner.SetCourseExp(0);
            _owner.StateMachine.ChangeState(NewClassTypeState.Instance);
        }
    }
}
