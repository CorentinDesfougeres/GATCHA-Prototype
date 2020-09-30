using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectDamage : Effect
{
    public int FlatDamage;
    public List<StatIntCouple> StatDependantDammage;

    new public void Execute(MonoBehaviour _source , UnitBehaviour[] _targets)
    {
        foreach (UnitBehaviour _target in _targets)
        {
            ;  // do the damages
        }
    }
}

