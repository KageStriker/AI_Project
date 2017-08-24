using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using States;
using System;

public class StudyState : State<Student>
{
    private static StudyState _instance;
    private float timeToStudy;
    private float energyDrainMultiplier;
    private float staminaDrainMultiplier;

    private StudyState()
    {
        if(_instance != null)
        {
            return;
        }

        _instance = this;

        timeToStudy = 20.0f;
        energyDrainMultiplier = 0.9f;
        staminaDrainMultiplier = 0.6f;
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

        _owner.StartCoroutine(_owner.WaitForDuration(timeToStudy));
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

        _owner.SetEnergy(_owner.GetEnergy() - (Time.deltaTime * energyDrainMultiplier));
        _owner.SetStamina(_owner.GetStamina() - (Time.deltaTime * staminaDrainMultiplier));
    }
}
