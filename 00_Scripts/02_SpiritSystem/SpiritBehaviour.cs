using UnityEngine;
using System.Collections.Generic;

public class SpiritBehaviour : MonoBehaviour
{
    public SpecieData Specie;

    public List<Stat> Stats;
    public List<int> EVs;

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

    public bool isAlive;
}