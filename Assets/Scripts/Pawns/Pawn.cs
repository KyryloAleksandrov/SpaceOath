using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pawn : MonoBehaviour
{
    [SerializeField] private MeshRenderer[] meshRenderers;
    
    public Player player;
    private bool isActive = false;
    private Vector3 destination;

    void Update()
    {
        if(!isActive)
        {
            return;
        }

        Vector3 moveDirection = (destination - transform.position).normalized;
        transform.forward = Vector3.Lerp(transform.forward, moveDirection, Time.deltaTime * 10);

        if(Vector3.Distance(transform.position, destination) > 0.1f){
            transform.position += moveDirection * Time.deltaTime * 6f;
        }
        else
        {
            Debug.Log("Done");
            isActive = false;
        }
    }
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

    public void ChangePosition(Vector3 targetPosition)
    {
        Debug.Log("Changing position to" + targetPosition);
        isActive = true;
        destination = targetPosition;

    }
}
