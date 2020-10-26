using System;
using UnityEngine;

[Serializable]
public class Action
{
    [SerializeReference] public Targeting Targeting;
    [SerializeReference]  public Effect Effect;
    
    public void Declare(ActorBehaviour _source)
    {
        CombatManager.Current.AddToResolveList(this, _source);
    }

    public void Execute(ActorBehaviour _source)
    {
        UnitBehaviour[] _targets = Targeting.Execute(_source);
        Effect.Execute(_source , _targets);
    }
}