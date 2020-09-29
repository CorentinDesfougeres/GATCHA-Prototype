using UnityEngine;
using System;
using System.Collections.Generic;

class AlterationBehaviour : MonoBehaviour
{
    public AlterationData Data;

    public SpiritBehaviour Source;
    public SpiritBehaviour Host;

    public void OnEnable()
    {
        foreach (Action action in Data.Actions)
        {
            action.Declare();
        }
        if (Data.Lifespan == AlterationLifespan.Combat && GameManager.Current.GameState == GameStateId.Combat)
        {
            ;//CombatManager.Current.OnCombatEnd += Destroy(this); //matcheras pas, il faudrait une fonction avec les bons arguments, mais c'est l'idée
        }
    }

    public event EventHandler OnLeave;
    public void OnDisable()
    {
        if (OnLeave != null)
        {
            OnLeave(this, EventArgs.Empty);
        }
        
    }
}