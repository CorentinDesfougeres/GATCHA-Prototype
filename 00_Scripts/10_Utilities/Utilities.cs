using System;

public enum Origine
{
    Primordial,
    Demonic,
    Angelic,
    Artificial,
    Aberration
}

public enum Type
{
    Physical,
    Mental
}

[Serializable]
public class StatIntCouple
{
    StatId Stat;
    int Value;
}

public delegate void TestEventHandler();