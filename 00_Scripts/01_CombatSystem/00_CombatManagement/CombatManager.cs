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

    public void FixedUpdate()
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
            foreach (CombatParticipant _participant in _team.FieldMembers)
            {
                _participant.ActionPoints += _participant.Spirit.Stats[(int)StatId.Speed].Value;

                if (_participant.ActionPoints >= GameManager.Current.GameParameters.ActionTreshold)
                {
                    
                }
            }
        }
    }





    public event EventHandler OnCombatStart;
    public void StartCombat()   //Faire dans le OnEnable?
    {
        if (OnCombatEnd != null)
        {
            OnCombatStart(this, EventArgs.Empty);
        }

        Tick = 0;
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