using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Site : MonoBehaviour
{
    private string siteName;
    private int regionIndex;
    
    [SerializeField] private SiteVisual siteVisual;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public string GetName()
    {
        return siteName;
    }
    public void SetName(string siteName)
    {
        this.siteName = siteName;
    }

    public int GetRegionIndex()
    {
        return this.regionIndex;
    }
    public void SetRegionIndex(int regionIndex)
    {
        this.regionIndex = regionIndex;
    }
}
