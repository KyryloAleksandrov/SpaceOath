using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SiteTile : MonoBehaviour
{
    private Site site;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void SetSite(Site site)
    {
        this.site = site;
    }

    public Site GetSite()
    {
        return site;
    }
}
