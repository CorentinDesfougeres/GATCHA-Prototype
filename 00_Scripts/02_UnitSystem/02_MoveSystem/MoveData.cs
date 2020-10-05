using System;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.Serialization;
using Sirenix.OdinInspector;

[CreateAssetMenu]
[ShowOdinSerializedPropertiesInInspector]
public class MoveData : ScriptableObject
{
    public string Name;
    public string Description;
    
    [NonSerialized][OdinSerialize] public List<Action> PassiveEffects;

    [NonSerialized][OdinSerialize] public List<Action> DeclarationEffects;

    [NonSerialized][OdinSerialize] public List<Action> ExecutionEffects;

    // liste d'effets d'une facon qui fasse sens !
}