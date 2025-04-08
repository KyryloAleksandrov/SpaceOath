using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMapSetupService
{
    bool isFirstSetup {get;}
    List<Site> sites {get;}
    static int[,] travelCost {get;}

    void FirstSetup(Map map);
    void NextSetup();

    int GetTravelCost(Site from, Site to);
}

public class MapSetupService : IMapSetupService
{
    public bool isFirstSetup {get;}
    public List<Site> sites {get;}
    private static int[,] travelCosts = new int[4,4]
    {
        //0, 1, 2, 3
    /*0*/{1, 2, 3, 4},
    /*1*/{2, 2, 3, 4},
    /*2*/{3, 3, 3, 4},
    /*3*/{4, 4, 4, 4}
    };

    private SiteData[] siteDatas;

    public MapSetupService(IConfigService configService)
    {
        siteDatas = configService.siteDatas;
        sites = new List<Site>();
    }

    public void FirstSetup(Map map)
    {
        List<int> usedIndexes = new List<int>();
        int randomSiteIndex = -1;
        usedIndexes.Add(randomSiteIndex);
        for(int i = 0; i < map.GetRegions().Length; i++)
        {
            foreach(var siteTile in map.GetRegions()[i].GetSiteTiles())
            {
                while(usedIndexes.Contains(randomSiteIndex))
                {
                    randomSiteIndex = Random.Range(0, 30);
                }
                usedIndexes.Add(randomSiteIndex);
                Transform newSiteTransform = GameObject.Instantiate(siteDatas[randomSiteIndex].siteTransform, siteTile.transform.position + new Vector3(0, -0.1f, 0), Quaternion.identity);

                Site newSite = newSiteTransform.GetComponent<Site>();
                newSite.SetName(siteDatas[randomSiteIndex].siteName);
                newSite.SetRegionIndex(i);

                SiteVisual newSiteVisual = newSiteTransform.GetComponent<SiteVisual>();
                newSiteVisual.SetFaceUpVisual(siteDatas[randomSiteIndex].faceUpMaterial);

                sites.Add(newSite);

                siteTile.SetSite(newSite);
                siteTile.SetSiteVisual(newSiteVisual);

                if(siteTile != map.GetRegions()[i].GetSiteTiles()[0])
                {
                    siteTile.GetSiteVisual().TurnFaceDown();
                }
                else
                {
                    siteTile.GetSiteVisual().TurnFaceUp();
                }
            }
        }
    }

    public void NextSetup()
    {
        throw new System.NotImplementedException();
    }

    public int GetTravelCost(Site from, Site to)
    {
        int travelCost = travelCosts[from.GetRegionIndex(), to.GetRegionIndex()];
        return travelCost;
    }

}
