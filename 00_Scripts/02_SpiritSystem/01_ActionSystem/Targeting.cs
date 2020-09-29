using System;

[Serializable]
public class Targeting
{
    public SpiritBehaviour[] Execute()   // à remplacer par une méthode virtuelle qui sera remplacé dans chaque classe enfant
    {
        SpiritBehaviour[] _placeholder = new SpiritBehaviour[1];
        return _placeholder;
    }
}