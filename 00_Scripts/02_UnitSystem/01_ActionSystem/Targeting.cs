using System;

[Serializable]
public class Targeting
{
    public UnitBehaviour[] Execute(ActorBehaviour _source)   // à remplacer par une méthode virtuelle qui sera remplacé dans chaque classe enfant
    {
        UnitBehaviour[] _placeholder = new UnitBehaviour[1];
        return _placeholder;
    }
}