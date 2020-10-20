using UnityEngine;
using System.Collections.Generic;
using System;


public class UnitBehaviour : MonoBehaviour
{
    public UnitData Specie;

    public List<Stat> Stats;
    public List<int> BonusStatPoints;

    public void UpdateStats()
    {
        for (int i = 0; i < Stats.Count; i++)
        {
            Stats[i].SetBaseValue( Specie.BaseStats[i] * Specie.GrowthFactors[i]^(Level-1) );
        }
    }

    public List<MoveBehaviour> Moves; //array plutot que liste ?

    public int Level;
    private int experience;
    public void GainExperience(int _amoutGained)
    {
        experience += _amoutGained;
        //verifier si exp dépace le thresholde de lvl up et si oui déclancher le lvlup
    }

    public void Start()
    {
        for (int _index = 0 ; _index < Enum.GetValues(typeof(StatId)).Length ; _index ++)
        {
            Stats.Add(new Stat(Specie.BaseStats[_index]));
        }
    }

    // Combat Behaviour :

    [SerializeReference] public UnitControllerBehaviour Controller;

    public bool isAlive;
    public int Health;
    public delegate void DamageEventsHandler(int _amount , TypeId _type, ElementId _element , OrigineId _origine);
    public event DamageEventsHandler OnDamageTaken;
    public void TakeDamage(int _amount , TypeId _type, ElementId _element , OrigineId _origine)
    {
        Health -= _amount;
        OnDamageTaken?.Invoke(_amount , _type, _element , _origine);
    }

    public int Mana;
    public int ActionPoints;

    public List<MoveBehaviour> WaitingList;

    public UnitCombatState State;
    public int TeamId;

    public void Act()
    {
        Debug.Log("UnitAct");
        if (State == UnitCombatState.recuperation)
        {
            if (WaitingList != null)
            {
                WaitingList[0].Declare();
            }
            else
            {
                // faire choisir un move selon si c'est IA ou joueur !
            }
        }
        if (State == UnitCombatState.preparation)
        {
            WaitingList[0].Execute();
        }
    }
}