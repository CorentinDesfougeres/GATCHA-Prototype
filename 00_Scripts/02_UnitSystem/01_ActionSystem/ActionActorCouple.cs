using System;
using UnityEngine;

[Serializable]
public class ActionActorCouple
{
    public Action SavedAction;
    public ActorBehaviour SavedActor;

    public ActionActorCouple(Action _savedAction , ActorBehaviour _savedActor)
    {
        SavedAction = _savedAction;
        SavedActor = _savedActor;
    }
}