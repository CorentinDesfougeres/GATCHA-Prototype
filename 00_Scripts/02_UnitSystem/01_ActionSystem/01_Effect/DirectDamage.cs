using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectDamage : Effect
{
    public int FlatDamage;
    public List<StatIntCouple> StatDependantDammage;

    public override void Execute(ActorBehaviour _source , UnitBehaviour[] _targets)
    {
        foreach (UnitBehaviour _target in _targets)
        {
            ;  // do the damages
        }
    }
}

