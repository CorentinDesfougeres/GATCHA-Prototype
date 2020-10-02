using System;

public enum OrigineId
{
    Primordial,
    Demonic,
    Angelic,
    Artificial,
    Aberration
}

public enum TypeId
{
    Physical,
    Mental
}

[Serializable]
public class StatIntCouple
{
    public StatId Stat;
    public int Value;
}

public delegate void TestEventHandler();