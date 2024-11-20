using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Site : MonoBehaviour
{
    [SerializeField] private MeshRenderer siteMesh;
    
    [SerializeField] private Material faceupMaterial;
    [SerializeField] private Material facedownMaterial;

    [SerializeField] private string siteName;
    private bool isFacedown;
    

    // Start is called before the first frame update
    void Start()
    {
        SetMaterial();
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

    public void SetMaterial()
    {
        if(isFacedown)
        {
            siteMesh.material = facedownMaterial;
        }
        else{
            siteMesh.material = faceupMaterial;
        }
    }
}
