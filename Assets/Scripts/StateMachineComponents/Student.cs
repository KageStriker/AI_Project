using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using States;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class Student : MonoBehaviour
{
    #region Variables
    public float energy = 100;
    public float stamina = 100;

    protected float hunger = 0;
    protected float reputation = 0;
    public float money = 30;
    protected float courseExperience;
    protected static int groupMoney;

    protected int locationIndex;

    public bool waitComplete;
    public bool useIndex;
    public bool paid;

    public StateToEnter STE;

    public Course currentCourse;
    public List<Course> completedCourses;

    public Vector3 finalDestination;

    public NavMeshAgent nmAgent;

    public StudentFSM<Student> StateMachine { get; set; }
    #endregion

    private void Start()
    {
        nmAgent = GetComponent<NavMeshAgent>();
        StateMachine = new StudentFSM<Student>(this);

        nmAgent.angularSpeed = 1000;

        StateMachine.ChangeState(CalculateTaskState.Instance);
    }

    private void Update()
    {
        StateMachine.Update();
    }

    #region Getters&Setters
    public float GetEnergy()
    {
        return energy;
    }

    public float GetStamina()
    {
        return stamina;
    }

    public float GetHunger()
    {
        return hunger;
    }

    public float GetRep()
    {
        return reputation;
    }

    public float GetCourseExp()
    {
        return courseExperience;
    }

    public int GetGroupMoney()
    {
        return groupMoney;
    }

    public int GetMoney()
    {
        return Mathf.RoundToInt(money);
    }

    public int GetHouseNumber()
    {
        return Mathf.RoundToInt(money);
    }

    public int GetLocationIndex()
    {
        return locationIndex;
    }

    public Course GetCourse()
    {
        return currentCourse;
    }

    public void SetLocationIndex(int _locationIndex)
    {
        locationIndex = _locationIndex;
    }

    public void SetEnergy(float _energy)
    {
        energy = _energy;
    }

    public void SetStamina(float _stamina)
    {
        stamina = _stamina;
    }

    public void SetHunger(float _hunger)
    {
        hunger = _hunger;
    }

    public void SetRep(float _reputation)
    {
        reputation = _reputation;
    }

    public void SetCourseExp(float _courseExperience)
    {
        courseExperience = _courseExperience;
    }

    public void SetGroupMoney(int _groupMoney)
    {
        groupMoney = _groupMoney;
    }

    public void SetMoney(int _money)
    {
        money = _money;
    }

    public void SetCourse(Course _course)
    {
        currentCourse = _course;
    }

    public void AddCourse(Course _course)
    {
        completedCourses.Add(_course);
    }
    #endregion

    public IEnumerator WaitForDuration(float duration)
    {
        yield return new WaitForSeconds(duration);
        Debug.Log("Wait Over");
        waitComplete = true;
    }
}