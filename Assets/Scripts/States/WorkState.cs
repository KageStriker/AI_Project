using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using States;
using System;

public class WorkState : State<Student>
{
    private static WorkState _instance;
    private float counter;

    private WorkState()
    {
        if (_instance != null)
        {
            return;
        }

        _instance = this;

        counter = 0;
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
    }

    public override void ExitState(Student _owner)
    {
        Debug.Log("Exiting Work State");
    }

    public override void UpdateState(Student _owner)
    {
        _owner.SetEnergy(_owner.GetEnergy() - (Time.deltaTime * 10.0f));
        _owner.SetStamina(_owner.GetStamina() - (Time.deltaTime * 10.0f));
        counter += Time.deltaTime;

        if (counter >= 5)
        {
            _owner.SetMoney(Mathf.RoundToInt(_owner.GetMoney() + 10));
            counter = 0;
        }
    }
}
