using System;
using UnityEngine;

[Serializable]
public class Action
{
    public Targeting Targeting;
    public Effect Effect;

    public void Declare()
    {
        //s'ajoute à la resolve liste du combatManager
    }

    public void Execute(ActorBehaviour _source)           //méthode appelée par la résolveliste
    {
        UnitBehaviour[] _targets = Targeting.Execute(_source);
        Effect.Execute(_source , _targets);
    }
}