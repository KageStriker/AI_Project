using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using States;

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
        if(_owner.GetCourse() == null)
        {
            _owner.SetCourse(courses.A);
        }
        else
            for(int i = 0; i < _owner.completedCourses.Count; i++)
            {
                if (_owner.currentCourse.name == "A")
                {
                    _owner.SetCourse(courses.B);
                }
                else if (_owner.currentCourse.name == "B")
                {
                    _owner.SetCourse(courses.C);
                }
                else if (_owner.currentCourse.name == "C")
                {
                    _owner.SetCourse(courses.D);
                }
                else if (_owner.currentCourse.name == "D")
                {
                    _owner.SetCourse(courses.E);
                }
                else if (_owner.currentCourse.name == "E")
                {
                    _owner.SetCourse(courses.F);
                }
                else if (_owner.currentCourse.name == "F")
                {
                    _owner.SetCourse(courses.G);
                }
                else if (_owner.currentCourse.name == "G")
                {
                    _owner.SetCourse(courses.H);
                }
                else if (_owner.currentCourse.name == "H")
                {
                    _owner.SetCourse(courses.J);
                }
                else if (_owner.currentCourse.name == "J")
                {
                    _owner.SetCourse(courses.K);
                }
                else if (_owner.currentCourse.name == "K")
                {
                    _owner.SetCourse(courses.L);
                }
                else if (_owner.currentCourse.name == "L")
                {
                    _owner.SetCourse(courses.M);
                }
                else if (_owner.currentCourse.name == "M")
                {
                    _owner.SetCourse(courses.X);
                }
                else if (_owner.currentCourse.name == "X")
                {
                    _owner.SetCourse(courses.Y);
                }
                else if (_owner.currentCourse.name == "Y")
                {
                    _owner.SetCourse(courses.Z);
                }
                else if (_owner.currentCourse.name == "Z")
                {
                    _owner.StateMachine.ChangeState(GraduateState.Instance);
                }
            }
    }

    public override void ExitState(Student _owner)
    {
        Debug.Log("Exiting New Classroom Type State");
    }

    public override void UpdateState(Student _owner)
    {

    }
}
