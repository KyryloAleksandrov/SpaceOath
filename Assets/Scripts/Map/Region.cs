using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Region : MonoBehaviour
{
    [SerializeField] private SiteTile[] siteTiles = new SiteTile[4];
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public SiteTile[] GetSiteTiles()
    {
        return siteTiles;
    }
}
