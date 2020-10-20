using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class MoveBehaviour : ActorBehaviour
{
    public MoveData Data;

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


    public MoveBehaviour(UnitBehaviour _sourceUnit , MoveData _data)
    {
        SourceUnit = _sourceUnit;
        Data = _data;
    }

}
