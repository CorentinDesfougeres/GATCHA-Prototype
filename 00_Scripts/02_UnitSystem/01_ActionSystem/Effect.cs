using System;
using UnityEngine;

[Serializable]
public abstract class Effect
{
    public abstract void Execute(ActorBehaviour _source , UnitBehaviour[] _targets);
}