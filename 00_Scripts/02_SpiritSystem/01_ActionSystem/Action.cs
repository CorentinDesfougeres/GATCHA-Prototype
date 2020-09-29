using System;

[Serializable]
public class Action
{
    public Targeting Targeting;
    public Effect Effect;

    public void Declare()
    {
        //s'ajoute à la resolve liste du combatManager
    }

    public void Execute()           //méthode appelée par la résolveliste
    {
        SpiritBehaviour[] _targets = Targeting.Execute();
        Effect.Execute(this , _targets);
    }
}