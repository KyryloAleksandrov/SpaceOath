using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Renegade : Player
{
    public override PlayerRole Role => PlayerRole.Renegade;

    public Renegade(string playerName, Transform pawn, Color color): base(playerName, pawn, color)
    {
        currentSupply = maxSupply;
    }

    //implement take turns

    //implement checking victory
}
