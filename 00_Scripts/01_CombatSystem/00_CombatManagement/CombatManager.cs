using UnityEngine;
using System;
using System.Collections.Generic;

public class CombatManager : MonoBehaviour
{
    public static CombatManager current;
    public void Awake()
    {
        if (current == null)
        {
            current = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Object.Destroy(this.gameObject);
        }
    }

    public CombatState State;

    public int Tick;
    public int TickSpeed;
    public bool isCBT;

    private float tickDebt;

    public List<Team> Teams;

    public void FixedUpdate()
    {
        tickDebt += Time.DeltaTime * TickSpeed;
        while (State == CombatState.ticking && tickDebt >= 1)
        {
            if (isCBT)
            {
                TickingCBT();
            }
            else
            {
                TickingATB();
            }
        }
    }

    public void TickingATB()
    {
        Tick ++;
        TimeDebt --;

        foreach (Team _team in Teams)
        {
            foreach (CombatParticipant _participant in _team.FieldMembers)
            {
                _participant.ActionPoints = +_participant.Spirit.Stats[StatId.Speed];

                if (_participant.ActionPoints >= GameManager.current.GameParameters.ActionTreshold)
                {
                    
                }
            }
        }
    }





    public event EventHandler OnCombatStart;
    public void StartCombat()   //Faire dans le OnEnable?
    {
        if (OnCombatEnd =! null)
        {
            OnCombatStart(this, EventArgs.Empty);
        }

        Tick = 0;
    }

    public event EventHandler OnCombatEnd;
    public void LeaveCombat()  //Faire dans le OnDisable ?
    {
        if (OnCombatEnd =! null)
        {
            OnCombatEnd(this, EventArgs.Empty);
        }
    }
}