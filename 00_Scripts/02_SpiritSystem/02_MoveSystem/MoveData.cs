using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class MoveData : ScriptableObject
{
    public string Name;
    public string Description;
    
    public List<Action> PassiveEffects;

    public List<Action> DeclarationEffects;

    public List<Action> ExecutionEffects;

    // liste d'effets d'une facon qui fasse sens !
}