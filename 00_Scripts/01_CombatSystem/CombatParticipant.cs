using System.Collections.Generic;

public class CombatParticipant
{
    public SpiritBehaviour Spirit;

    public int Health;
    public int Mana;
    public int ActionPoints;

    public List<MoveData> WaitingList;

    public CombatParticipantState State;

}