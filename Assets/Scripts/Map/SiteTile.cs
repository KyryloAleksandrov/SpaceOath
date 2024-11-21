using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SiteTile : MonoBehaviour
{
    private Site site;

    private bool isEmpty;
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

    public void SetIsEmpty(bool isEmpty)
    {
        this.isEmpty = isEmpty;
    }

    public bool GetIsEmpty()
    {
        return isEmpty;
    }
}
