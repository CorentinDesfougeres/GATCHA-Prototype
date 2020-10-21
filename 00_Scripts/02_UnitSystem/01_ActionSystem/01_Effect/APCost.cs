using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class APCost : Effect
{
    public int Amount;
    public override void Execute(ActorBehaviour _source , UnitBehaviour[] _targets)
    {
        foreach (UnitBehaviour _target in _targets)
        {
            _target.ActionPoints -= Amount;
        }
    }
}
