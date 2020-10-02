using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Self : Targeting
{
    public override UnitBehaviour[] Execute(ActorBehaviour _source)
    {
        UnitBehaviour[] _target = new UnitBehaviour[1];
        _target[0] = _source.SourceUnit;
        return _target;
    }
}