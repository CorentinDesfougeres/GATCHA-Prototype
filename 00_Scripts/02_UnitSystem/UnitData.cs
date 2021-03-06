using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class UnitData : ScriptableObject
{
    public string Name;
    public string Description;
    
    public int[] BaseStats = new int[Enum.GetNames(typeof(StatId)).Length];
    public int[] GrowthFactors = new int[Enum.GetNames(typeof(StatId)).Length];

    [SerializeReference] public List<MoveData> Moves;

    //infos sur les évolutions ?
}