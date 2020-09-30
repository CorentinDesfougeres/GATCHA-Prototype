using UnityEngine;
using System.Collections.Generic;

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

    public int Level;
    private int experience;
    public void GainExperience(int _amoutGained)
    {
        experience += _amoutGained;
        //verifier si exp dépace le thresholde de lvl up et si oui déclancher le lvlup
    }


    // Combat Behaviour :
    public bool isAlive;
    public int Health;
    public int Mana;
    public int ActionPoints;

    public List<MoveBehaviour> WaitingList;

    public UnitCombatState State;
    public int TeamId;

    public void Act()
    {
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