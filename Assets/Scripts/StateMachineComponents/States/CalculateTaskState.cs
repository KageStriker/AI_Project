using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using States;
using System;


public class CalculateTaskState : State<Student>
{
    private static CalculateTaskState _instance;
    public static int allowableIndex;

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
        if (_owner.GetCourse() != null && _owner.GetEnergy() >= 50 && _owner.GetStamina() >= 50)
        {
            _owner.STE = StateToEnter.CourseWork;
        }
        else if (_owner.GetCourseExp() >= 100 && _owner.GetMoney() > 60 && allowableIndex < 6)
        {
            if (_owner.GetMoney() > 50)
            {
                allowableIndex++;
                _owner.STE = StateToEnter.NewClassType;
                _owner.SetCourseExp(0);
            }
            else
                WorkStudyEatOrSleep(_owner);

            _owner.STE = StateToEnter.CourseWork;
        }
        else if (_owner.GetGroupMoney() < 500 && _owner.GetMoney() < 100 && _owner.GetStamina() > 80 && _owner.GetEnergy() > 80)
        {
            if (_owner.StateMachine.previousState == WorkState.Instance)
                _owner.useIndex = true;
            else
                _owner.useIndex = false;

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

    public void WorkStudyEatOrSleep(Student _owner)
    {
        if (_owner.GetStamina() >= 50 && _owner.GetEnergy() >= 50)
        {
            if (_owner.StateMachine.previousState == WorkState.Instance)
                _owner.useIndex = true;
            else
                _owner.useIndex = false;

            _owner.STE = StateToEnter.Work;
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
        }
    }
}

