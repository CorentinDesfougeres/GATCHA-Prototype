using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class DirectDamage : Effect
{
    public int FlatDamage;
    public List<StatIntCouple> StatDependantDammages;
    public TypeId Type;
    public ElementId Element;
    public OrigineId Origine;

    public override void Execute(ActorBehaviour _source , UnitBehaviour[] _targets)
    {
        int _baseAmount = FlatDamage;
        foreach (StatIntCouple _statDependantDamage in StatDependantDammages)
        {
            _baseAmount += _source.SourceUnit.Stats[(int)_statDependantDamage.Stat].Value * _statDependantDamage.Value / 100 ;
        }
        foreach (UnitBehaviour _target in _targets)
        {
            //devrait calculer en prenant en compte la défence etc, mais pas nécéssaire pour le proto
            _target.TakeDamage(_baseAmount , Type , Element , Origine);
        }
    }
}

