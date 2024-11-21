using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMapSetupService
{
    public bool isFirstSetup {get;}
    public void FirstSetup(Map map);
    public void NextSetup();
}

public class MapSetupService : IMapSetupService
{
    public bool isFirstSetup {get;}

    private SiteData[] siteDatas;

    public MapSetupService(IConfigService configService)
    {
        siteDatas = configService.siteDatas;
    }

    public void FirstSetup(Map map)
    {
        List<int> usedIndexes = new List<int>();
        int randomSiteIndex = -1;
        usedIndexes.Add(randomSiteIndex);
        foreach(var region in map.GetRegions())
        {
            foreach(var siteTile in region.GetSiteTiles())
            {
                
                while(usedIndexes.Contains(randomSiteIndex))
                {
                    randomSiteIndex = Random.Range(0, 30);
                }
                usedIndexes.Add(randomSiteIndex);
                Transform newSiteTransform = GameObject.Instantiate(siteDatas[randomSiteIndex].siteTransform, siteTile.transform.position + new Vector3(0, -0.1f, 0), Quaternion.identity);
                Site newSite = newSiteTransform.GetComponent<Site>();
                siteTile.SetSite(newSite);

                if(siteTile != region.GetSiteTiles()[0])
                {
                    siteTile.GetSite().TurnFaceDown();
                }
                else
                {
                    siteTile.GetSite().TurnFaceUp();
                }
            }
        }


    }

    public void NextSetup()
    {
        throw new System.NotImplementedException();
    }
}
