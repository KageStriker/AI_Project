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

        _owner.StartCoroutine(_owner.WaitForDuration(10.0f));
    }

    public override void ExitState(Student _owner)
    {
        Debug.Log("Entering Sleep State");
        _owner.SetStamina(100);
    }

    public override void UpdateState(Student _owner)
    {
        _owner.SetStamina(_owner.GetStamina() + (Time.deltaTime * 5.0f));

        if (_owner.GetStamina() >= 100)
        {
            if (_owner.GetEnergy() < 30)
            {
                _owner.STE = StateToEnter.Eat;
                _owner.StateMachine.ChangeState(MoveToTaskState.Instance);
            }
            else
            {
                _owner.StateMachine.ChangeState(CalculateTaskState.Instance);
            }
        }
    }
}
