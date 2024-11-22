using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pawn : MonoBehaviour
{
    [SerializeField] private MeshRenderer[] meshRenderers;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void PaintPlayerColor(Color color)
    {
        foreach (var meshrenderer in meshRenderers)
        {
            meshrenderer.material.color = color;
        }
    }
}
