using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using States;

public enum StateToEnter
{
    Study,
    Eat,
    Sleep,
    Work,
    Graduate,
    DropOut,
    NewClassroom
}

public class MoveToTaskState : State<Student>
{
    private static MoveToTaskState _instance;
    
    /////////////////////////// 
    private static int position;
    ///////////////////////////

    private List<GameObject> studyAreas;
    private List<GameObject> eatingAreas;
    private List<GameObject> sleepAreas;
    private List<GameObject> workAreas;
    private List<GameObject> classroomAreas;

    private bool[] studyOpenings;
    private bool[] eatingOpenings;
    private bool[] sleepOpenings;
    private bool[] workOpenings;
    private bool[] classroomOpenings;

    private MoveToTaskState()
    {
        if (_instance != null)
        {
            return;
        }

        _instance = this;

        #region ListCreations
        studyAreas = new List<GameObject>();
        eatingAreas = new List<GameObject>();
        sleepAreas = new List<GameObject>();
        workAreas = new List<GameObject>();
        classroomAreas = new List<GameObject>();
        #endregion

        #region StudyAreaSetup
        foreach (GameObject g in GameObject.FindGameObjectsWithTag("StudyArea"))
        {
            studyAreas.Add(g);
        }

        studyOpenings = new bool[studyAreas.Count];

        for(int i = 0; i < studyAreas.Count; i++)
        {
            studyOpenings[i] = true;
        }
        #endregion

        #region EatingAreaSetup
        foreach (GameObject g in GameObject.FindGameObjectsWithTag("EatingArea"))
        {
            eatingAreas.Add(g);
        }

        eatingOpenings = new bool[eatingAreas.Count];

        for (int i = 0; i < eatingAreas.Count; i++)
        {
            eatingOpenings[i] = true;
        }
        #endregion

        #region SleepingAreaSetup
        foreach (GameObject g in GameObject.FindGameObjectsWithTag("SleepArea"))
        {
            sleepAreas.Add(g);
        }

        sleepOpenings = new bool[sleepAreas.Count];

        for (int i = 0; i < sleepAreas.Count; i++)
        {
            sleepOpenings[i] = true;
        }
        #endregion

        #region WorkAreaSetup
        foreach (GameObject g in GameObject.FindGameObjectsWithTag("WorkArea"))
        {
            workAreas.Add(g);
        }

        workOpenings = new bool[workAreas.Count];

        for (int i = 0; i < workAreas.Count; i++)
        {
            workOpenings[i] = true;
        }
        #endregion

        #region ClassroomAreaSetup
        foreach (GameObject g in GameObject.FindGameObjectsWithTag("ClassArea"))
        {
            classroomAreas.Add(g);
        }

        classroomOpenings = new bool[classroomAreas.Count];

        for (int i = 0; i < classroomAreas.Count; i++)
        {
            classroomOpenings[i] = true;
        }
        #endregion
    }

    public static MoveToTaskState Instance
    {
        get
        {
            if (_instance == null)
            {
                new MoveToTaskState();
            }

            return _instance;
        }
    }

    public override void EnterState(Student _owner)
    {
        Debug.Log("Entering Move To State");

        switch (_owner.STE)
        {
            case StateToEnter.Study:
                for(int i = 0; i < studyAreas.Count; i++)
                {
                    if (!studyOpenings[i])
                    {
                        continue;
                    }
                    else if(!studyOpenings[i] && i >= studyAreas.Count - 1 || _owner.GetEnergy() < 30 || _owner.GetStamina() < 30)
                    {
                        _owner.StateMachine.ChangeState(CalculateTaskState.Instance);
                        position--;
                    }
                    else
                    {
                        _owner.nmAgent.SetDestination(studyAreas[i].transform.position);
                        _owner.finalDestination = studyAreas[i].transform.position;
                        studyOpenings[i] = false;
                        position++;
                        break;
                    }
                }
                break;
            case StateToEnter.Eat:
                for (int i = 0; i < eatingAreas.Count; i++)
                {
                    if (!eatingOpenings[i])
                    {
                        continue;
                    }
                    else if (!eatingOpenings[i] && i >= eatingAreas.Count - 1 || _owner.GetEnergy() < 30 || _owner.GetStamina() < 30)
                    {
                        _owner.StateMachine.ChangeState(CalculateTaskState.Instance);
                        position--;
                    }
                    else
                    {
                        _owner.nmAgent.SetDestination(eatingAreas[i].transform.position);
                        _owner.finalDestination = eatingAreas[i].transform.position;
                        eatingOpenings[i] = false;
                        position++;
                        break;
                    }
                }
                break;
            case StateToEnter.Sleep:
                break;
            case StateToEnter.Work:
                break;
            case StateToEnter.Graduate:
                break;
            case StateToEnter.DropOut:
                break;
            case StateToEnter.NewClassroom:
                break;
        }
    }

    public override void ExitState(Student _owner)
    {
        Debug.Log("Exiting Move To State");
        position--;
    }

    public override void UpdateState(Student _owner)
    {
        _owner.SetEnergy(_owner.GetEnergy() - (Time.deltaTime * 1.3f));
        _owner.SetStamina(_owner.GetStamina() - (Time.deltaTime * 1.5f));

        if (Vector3.Distance(_owner.gameObject.transform.position, _owner.finalDestination) < 0.5f)
        {
            _owner.nmAgent.isStopped = true;

            switch (_owner.STE)
            {
                case StateToEnter.Study:
                    _owner.StateMachine.ChangeState(StudyState.Instance);
                    break;
                case StateToEnter.Eat:
                    _owner.StateMachine.ChangeState(EatState.Instance);
                    break;
                case StateToEnter.Sleep:
                    _owner.StateMachine.ChangeState(SleepState.Instance);
                    break;
                case StateToEnter.Work:
                    _owner.StateMachine.ChangeState(WorkState.Instance);
                    break;
                case StateToEnter.Graduate:
                    _owner.StateMachine.ChangeState(GraduateState.Instance);
                    break;
                case StateToEnter.DropOut:
                    _owner.StateMachine.ChangeState(DropOutState.Instance);
                    break;
                case StateToEnter.NewClassroom:
                    _owner.StateMachine.ChangeState(NewClassState.Instance);
                    break;
            }
        }
    }
}
