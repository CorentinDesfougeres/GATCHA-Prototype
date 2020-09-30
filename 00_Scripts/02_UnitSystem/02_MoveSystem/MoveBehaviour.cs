using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBehaviour : ActorBehaviour
{
    MoveData Data;

    public void StartPassives()
    {
        foreach (Action action in Data.PassiveEffects)
        {
            action.Declare();
        }
    }

    public void Declare()
    {
        foreach (Action action in Data.DeclarationEffects)
        {
            action.Declare();
        }
    }

    public void Execute()
    {
        foreach (Action action in Data.ExecutionEffects)
        {
            action.Declare();
        }
    }


    public void Start()
    {
        SourceUnit = GetComponent<UnitBehaviour>();
    }

}
