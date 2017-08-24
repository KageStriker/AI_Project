using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using States;
using System;


public class CalculateTaskState : State<Student>
{
    private static CalculateTaskState _instance;
    
    private CalculateTaskState()
    {
        if (_instance != null)
        {
            return;
        }

        _instance = this;
    }

    public static CalculateTaskState Instance
    {
        get
        {
            if (_instance == null)
            {
                new CalculateTaskState();
            }

            return _instance;
        }
    }

    public override void EnterState(Student _owner)
    {
        Debug.Log("Entering Calculate Task State");
        if (_owner.GetGroupMoney() > 500)
        {
            _owner.STE = StateToEnter.NewClassroom;
        }
        else if (_owner.GetMoney() < 10 && _owner.GetEnergy() > 20 && _owner.GetStamina() > 20 || _owner.GetMoney() < 10 && _owner.GetStamina() > 20 && _owner.GetEnergy() > 20)
        {
            _owner.STE = StateToEnter.Work;
        }
        else if (_owner.GetEnergy() >= 50 && _owner.GetStamina() >= 50)
        {
            if (_owner.StateMachine.previousState == StudyState.Instance)
                _owner.useIndex = true;
            else
                _owner.useIndex = false;

            _owner.STE = StateToEnter.Study;
        }
        else if (_owner.GetEnergy() < 50 || _owner.GetStamina() < 50)
        {
            if (_owner.GetEnergy() < _owner.GetStamina())
            {
                if (_owner.StateMachine.previousState == EatState.Instance)
                    _owner.useIndex = true;
                else
                    _owner.useIndex = false;

                _owner.STE = StateToEnter.Eat;
            }
            else if (_owner.GetEnergy() > _owner.GetStamina())
            {
                if (_owner.StateMachine.previousState == SleepState.Instance)
                    _owner.useIndex = true;
                else
                    _owner.useIndex = false;

                _owner.STE = StateToEnter.Sleep;
            }
            else if (_owner.GetEnergy() < 10 || _owner.GetStamina() < 10)
            {
                _owner.STE = StateToEnter.DropOut;
            }
            else
            {
                if (_owner.StateMachine.previousState == StudyState.Instance)
                    _owner.useIndex = true;
                else
                    _owner.useIndex = false;
                _owner.STE = StateToEnter.Study;
            }
        }
        else
        {
            if (_owner.StateMachine.previousState == StudyState.Instance)
                _owner.useIndex = true;
            else
                _owner.useIndex = false;
            _owner.STE = StateToEnter.Study;
        }

        _owner.StateMachine.ChangeState(MoveToTaskState.Instance);
    }

    public override void ExitState(Student _owner)
    {
        Debug.Log("Exiting Calculate Task State");
    }

    public override void UpdateState(Student _owner)
    {

    }
}
