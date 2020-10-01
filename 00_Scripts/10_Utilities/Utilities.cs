using System;

public enum Origine
{
    Primordial,
    Demonic,
    Angelic,
    Artificial,
    Aberration
}

[Serializable]
public class StatIntCouple
{
    StatId Stat;
    int Value;
}

public delegate void TestEventHandler();