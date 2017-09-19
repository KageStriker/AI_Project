using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using States;

// A = 1; B = 2; C = 3; D = 4; E = 5; F = 6; G = 7; H = 8; 
// J = 9; K = 10; L = 11; M = 12; X = 13; Y = 14; Z = 15;

public class NewClassTypeState : State<Student>
{
    private static NewClassTypeState _instance;
    private static Courses courses;

    private NewClassTypeState()
    {
        if (_instance != null)
        {
            return;
        }

        _instance = this;
    }

    public static NewClassTypeState Instance
    {
        get
        {
            if (_instance == null)
            {
                new NewClassTypeState();
            }

            return _instance;
        }
    }

    public override void EnterState(Student _owner)
    {
        Debug.Log("Entering New Classroom Type State");
        if (_owner.GetCourse().courseValue == 0 && _owner.GetCourse() == null)
        {
            _owner.SetCourse(courses.A);
            _owner.StateMachine.ChangeState(CalculateTaskState.Instance);
        }
        else
        {
            // A = 1; B = 2; C = 3; D = 4; E = 5; F = 6; G = 7; H = 8; 
            // J = 9; K = 10; L = 11; M = 12; X = 13; Y = 14; Z = 15;

            switch (_owner.GetCourse().courseValue)
            {
                case 1:
                    _owner.SetCourse(courses.A);
                    _owner.StateMachine.ChangeState(CalculateTaskState.Instance);
                    break;
                case 2:
                    _owner.SetCourse(courses.B);
                    _owner.StateMachine.ChangeState(CalculateTaskState.Instance);
                    break;
                case 3:
                    _owner.SetCourse(courses.C);
                    _owner.StateMachine.ChangeState(CalculateTaskState.Instance);
                    break;
                case 4:
                    _owner.SetCourse(courses.D);
                    _owner.StateMachine.ChangeState(CalculateTaskState.Instance);
                    break;
                case 5:
                    _owner.SetCourse(courses.E);
                    _owner.StateMachine.ChangeState(CalculateTaskState.Instance);
                    break;
                case 6:
                    _owner.SetCourse(courses.F);
                    _owner.StateMachine.ChangeState(CalculateTaskState.Instance);
                    break;
                case 7:
                    _owner.SetCourse(courses.G);
                    _owner.StateMachine.ChangeState(CalculateTaskState.Instance);
                    break;
                case 8:
                    _owner.SetCourse(courses.H);
                    _owner.StateMachine.ChangeState(CalculateTaskState.Instance);
                    break;
                case 9:
                    _owner.SetCourse(courses.J);
                    _owner.StateMachine.ChangeState(CalculateTaskState.Instance);
                    break;
                case 10:
                    _owner.SetCourse(courses.K);
                    _owner.StateMachine.ChangeState(CalculateTaskState.Instance);
                    break;
                case 11:
                    _owner.SetCourse(courses.L);
                    _owner.StateMachine.ChangeState(CalculateTaskState.Instance);
                    break;
                case 12:
                    _owner.SetCourse(courses.M);
                    _owner.StateMachine.ChangeState(CalculateTaskState.Instance);
                    break;
                case 13:
                    _owner.SetCourse(courses.X);
                    _owner.StateMachine.ChangeState(CalculateTaskState.Instance);
                    break;
                case 14:
                    _owner.SetCourse(courses.Y);
                    _owner.StateMachine.ChangeState(CalculateTaskState.Instance);
                    break;
                case 15:
                    _owner.SetCourse(courses.Z);
                    _owner.StateMachine.ChangeState(CalculateTaskState.Instance);
                    break;
            }

        }
    }

    public override void ExitState(Student _owner)
    {
        Debug.Log("Exiting New Classroom Type State");
        if (_owner.currentCourse != null && _owner.StateMachine.previousState != NewClassTypeState.Instance)
        {
            _owner.SetMoney(_owner.GetMoney() - _owner.currentCourse.coursePrice);
        }
    }

    public override void UpdateState(Student _owner)
    {
        
    }
}
