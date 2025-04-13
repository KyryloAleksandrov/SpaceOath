using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pawn : MonoBehaviour
{
    [SerializeField] private MeshRenderer[] meshRenderers;
    
    public Player player;

    void Update()
    {

    }
    public void PaintPlayerColor(Color color)
    {
        foreach (var meshRenderer in meshRenderers)
        {
            meshRenderer.material.color = color;
        }
    }

    public void SetPlayer(Player player)
    {
        this.player = player;
    }

    public void ChangePosition(Vector3 targetPosition)
    {
        Debug.Log("Changing position to" + targetPosition);
        this.transform.position = targetPosition;
    }
}
