using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using States;
using System;

public class WorkState : State<Student>
{
    private static WorkState _instance;
    private float counter;
    private float shiftTime;

    private WorkState()
    {
        if (_instance != null)
        {
            return;
        }

        _instance = this;

        counter = 0;
        shiftTime = 10.0f;
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
        Debug.Log("Entering Work State");
        _owner.StartCoroutine(_owner.WaitForDuration(shiftTime));
    }

    public override void ExitState(Student _owner)
    {
        Debug.Log("Exiting Work State");
    }

    public override void UpdateState(Student _owner)
    {
        if (_owner.waitComplete)
        {
            _owner.StateMachine.ChangeState(CalculateTaskState.Instance);
            _owner.waitComplete = false;
        }

        counter += Time.deltaTime;

        _owner.SetEnergy(_owner.GetEnergy() - (Time.deltaTime * 1.2f));
        _owner.SetStamina(_owner.GetStamina() - (Time.deltaTime * 1.2f));

        if (counter >= 5)
        {
            _owner.SetMoney(Mathf.RoundToInt(_owner.GetMoney() + 10));
            counter = 0;
        }
    }
}
