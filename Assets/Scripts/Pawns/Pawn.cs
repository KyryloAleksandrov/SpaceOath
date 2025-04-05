using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pawn : MonoBehaviour
{
    [SerializeField] private MeshRenderer[] meshRenderers;
    
    public Player player;


    public void PaintPlayerColor(Color color)
    {
        foreach (var meshrenderer in meshRenderers)
        {
            meshrenderer.material.color = color;
        }
    }

    public void SetPlayer(Player player)
    {
        this.player = player;
    }
}
