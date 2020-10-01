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
            DontDestroyOnLoad(this.gameObject);
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

    public List<UnitBehaviour> ActingUnits;

    public void Update()
    {
        if (isCTB)
        {
            TickingCTB();
        }
        else
        {
            TickingATB();
        }

        if (ActingUnits != null)
        {
            foreach ( UnitBehaviour _unit in ActingUnits)
            {
                if (_unit.WaitingList != null)
                {
                    _unit.Act();
                }
                else
                {
                    //_unit.Controller.PickAction();     // see how to make sure that UnitBehaviour cache it's controller at the start of Combat so that we don't need to go search it every time
                    _unit.Controller.GetComponent<UnitControllerBehaviour>().PickAction();
                    _unit.Act();
                }
            }
        }
    }

    public void TickingATB()
    {
        tickDebt += Time.deltaTime * TickSpeed;

        while (State == CombatState.ticking && tickDebt >= 1)
        {
            Tick ++;
            tickDebt --;
            TickOnce();
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
        foreach (Team _team in Teams)
        {
            foreach (UnitBehaviour _unit in _team.FieldMembers)
            {
                _unit.ActionPoints += _unit.Stats[(int)StatId.Speed].Value;

                if (_unit.ActionPoints >= GameManager.Current.GameParameters.ActionTreshold)
                {
                    State = CombatState.waitingForAnswer;
                    if (ActingUnits != null)
                    {
                        bool _isAded = false;
                        int _index = 0;
                        while (_index < ActingUnits.Count && _unit.ActionPoints >= ActingUnits[_index].ActionPoints)
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
                        }
                        if (_isAded == false)
                        {
                            ActingUnits.Insert(_index+1 , _unit);
                        }
                    }
                    else
                    {
                        ActingUnits.Insert(0 , _unit);
                    }
                }
            }
        }
    }



    
    public event EventHandler OnCombatStart;
    public void StartCombat(List<Team> _teams)   // Faire dans le OnEnable ?
    {
        if (OnCombatStart != null)
        {
            OnCombatStart(this, EventArgs.Empty);
        }

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
}