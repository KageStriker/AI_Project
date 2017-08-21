using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using States;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class Student : MonoBehaviour
{
    public float energy = 100;
    public float stamina = 100;

    protected float hunger = 0;
    protected float reputation = 0;
    protected float money = 30;

    protected int locationIndex;

    public bool waitComplete;

    public StateToEnter STE;

    public Vector3 finalDestination;

    public NavMeshAgent nmAgent;
    
    public StudentFSM<Student> StateMachine { get; set; }


    private void Start()
    {
        nmAgent = GetComponent<NavMeshAgent>();
        StateMachine = new StudentFSM<Student>(this);

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

    public void SetMoney(int _money)
    {
        money = _money;
    }
    #endregion

    public IEnumerator WaitForDuration(float duration)
    {
        yield return new WaitForSeconds(duration);
        Debug.Log("Wait Over");
        waitComplete = true;
    }
}