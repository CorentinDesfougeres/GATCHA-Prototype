using UnityEngine;
using System;
using System.Collections.Generic;

class AlterationBehaviour : ActorBehaviour
{
    public AlterationData Data;

    public UnitBehaviour Host;

    public AlterationBehaviour(UnitBehaviour _source , UnitBehaviour _host , AlterationData _data)
    {
        SourceUnit = _source;
        Host = _host;
        Data = _data;
        foreach (Action action in Data.Actions)
        {
            action.Declare(this);
        }
        if (Data.Lifespan == AlterationLifespan.Combat && GameManager.Current.GameState == GameStateId.Combat)
        {
            ;//CombatManager.Current.OnCombatEnd += Destroy(this); //matcheras pas, il faudrait une fonction avec les bons arguments, mais c'est l'idée
        }
    }

    public event EventHandler OnLeave;
    public void OnDisable()  // attention c'est plus un monobehaviour !
    {
        if (OnLeave != null)
        {
            OnLeave(this, EventArgs.Empty);
        }
        
    }
}