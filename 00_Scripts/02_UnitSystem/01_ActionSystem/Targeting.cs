using System;

[Serializable]
public abstract class Targeting
{
    public abstract UnitBehaviour[] Execute(ActorBehaviour _source);
}