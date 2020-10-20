using UnityEngine;
using System;
using System.Collections.Generic;

public class CombatManager : MonoBehaviour
{
    public static CombatManager Current;
    public void Awake()
    {
        if (Current == null)
        {
            Current = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }


    public CombatState State;

    public int Tick;
    public int TickSpeed;
    public bool isCTB;

    private float tickDebt;

    public List<Team> Teams;
    public PlayerUnitControllerBehaviour PlayerUnitController;
    public List<UnitControllerBehaviour> UnitControllers;

    public List<UnitBehaviour> ActingUnits;

    public void Update()
    {
        if (State == CombatState.ticking)
        {
            if (isCTB)
            {
                TickingCTB();
            }
            else
            {
                TickingATB();
            }
        }
        if (State == CombatState.ActingList)
        {
            Debug.Log("ActingList");
            if (ActingUnits[0].WaitingList.Count != 0)
            {
                ActingUnits[0].Act();
                State = CombatState.waitingForAnimation;
            }
            else
            {
                ActingUnits[0].Controller.PickAction(ActingUnits[0]);
                State = CombatState.waitingForAnswer;
            }
        }
        if (State == CombatState.waitingForAnswer)
        {
            if (ActingUnits[0].WaitingList.Count != 0)
            {
                ActingUnits[0].Act();
                State = CombatState.waitingForAnimation;
            }
        }
        if (State == CombatState.waitingForAnimation)
        {
            Debug.Log("Waiting for anim");
            // wait for the end of the animation
            if (ActingUnits.Count != 0)
            {
                State = CombatState.ActingList;
            }
            else
            {
                State = CombatState.ticking;
            }
            
        }
    }

    public void TickingATB()
    {

        tickDebt += Time.deltaTime * TickSpeed;
        
        while (State == CombatState.ticking && tickDebt >= 1)
        {
            TickOnce();
            tickDebt --;
        }

    }

    public void TickingCTB()                       //  /!\  crash si TickOnce() ne fait pas sortir de CombatState.Ticking !
    {
        while (State == CombatState.ticking)
        {
            TickOnce();
        }
    }

    public void TickOnce()
    {
        Tick ++;
        foreach (Team _team in Teams)
        {
            foreach (UnitBehaviour _unit in _team.FieldMembers)
            {
                _unit.ActionPoints += _unit.Stats[(int)StatId.Speed].Value;

                if (_unit.ActionPoints >= GameManager.Current.GameParameters.ActionTreshold)
                {
                    State = CombatState.ActingList;
                    if (ActingUnits.Count != 0)
                    {
                        bool _isAded = false;
                        int _index = 0;
                        while (_index < ActingUnits.Count-1 && _unit.ActionPoints >= ActingUnits[_index].ActionPoints)
                        {
                            if (_unit.ActionPoints > ActingUnits[_index].ActionPoints)
                            {
                                ActingUnits.Insert(_index , _unit);
                                _isAded = true;
                            }
                            else if (_unit.Stats[(int)StatId.Speed].Value > ActingUnits[_index].Stats[(int)StatId.Speed].Value)
                            {
                                ActingUnits.Insert(_index , _unit);
                                _isAded = true;
                            }
                            _index ++;
                        }
                        if (_isAded == false)
                        {
                            if(_index < ActingUnits.Count-1)
                            {
                                ActingUnits.Insert(_index+1 , _unit);
                            }
                            else
                            {
                                ActingUnits.Add(_unit);
                            }
                        }
                    }
                    else
                    {
                        ActingUnits.Add(_unit);
                    }
                }
            }
        }
    }



    public delegate void CombatEventHandler();
    public event CombatEventHandler OnCombatStart;
    public void StartCombat(List<Team> _teams)   // Faire dans le OnEnable ?
    {
        OnCombatStart?.Invoke();
        
        Tick = 0;

        Teams = _teams;
    }

    public event EventHandler OnCombatEnd;
    public void LeaveCombat()  //Faire dans le OnDisable ?
    {
        if (OnCombatEnd != null)
        {
            OnCombatEnd(this, EventArgs.Empty);
        }
    }

    public delegate void UnitEntrance(UnitBehaviour _unit);
    public event UnitEntrance OnUnitEnteredFeild;
    public void PutUnitOnFeild(UnitBehaviour _unit, int _position)
    {
        Teams[_unit.TeamId].FieldMembers[_position] = _unit;
        OnUnitEnteredFeild.Invoke(_unit);
    }
}