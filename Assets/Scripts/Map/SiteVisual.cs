using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SiteVisual : MonoBehaviour
{
    [SerializeField] private MeshRenderer siteMesh;
    
    [SerializeField] private Material faceupMaterial;
    [SerializeField] private Material facedownMaterial;

    private bool isFacedown;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetIsFacedown(bool isFacedown)
    {
        this.isFacedown = isFacedown;
    }

    public bool GetIsFaceDown()
    {
        return isFacedown;
    }

    public void TurnFaceUp()
    {
        siteMesh.material = faceupMaterial;
        isFacedown = false;
    }

    public void TurnFaceDown()
    {
        siteMesh.material = facedownMaterial;
        isFacedown = true;
    }

    public void SetFaceUpVisual(Material material)
    {
        this.faceupMaterial = material;
    }
}
