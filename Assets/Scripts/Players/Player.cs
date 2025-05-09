using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Player
{
    public Transform pawn;
    public Color color;

    public string playerName;
    public int maxSupply = 9;
    public int currentSupply;
    public int warbands;
    public Site currentSite;

    //advisors
    //relics
    //money
    //secrets
    
    public abstract PlayerRole Role {get;}

    //taking turns
    //checking victory

    public Player(string playerName, Transform pawn, Color color)
    {
        this.playerName = playerName;
        this.pawn = pawn;
        this.color = color;
    }

    public virtual void AssignPawn(Transform pawnTransform)
    {
        this.pawn = pawnTransform;
    }
}
