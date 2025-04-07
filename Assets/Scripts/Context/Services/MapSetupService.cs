using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMapSetupService
{
    bool isFirstSetup {get;}
    List<Site> sites {get;}

    void FirstSetup(Map map);
    void NextSetup();
}

public class MapSetupService : IMapSetupService
{
    public bool isFirstSetup {get;}
    public List<Site> sites {get;}

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
                /*while(usedIndexes.Contains(randomSiteIndex))
                {
                    randomSiteIndex = Random.Range(0, 30);
                }
                usedIndexes.Add(randomSiteIndex);
                Transform newSiteTransform = GameObject.Instantiate(siteDatas[randomSiteIndex].siteTransform, siteTile.transform.position + new Vector3(0, -0.1f, 0), Quaternion.identity);
                Site newSite = newSiteTransform.GetComponent<Site>();
                sites.Add(newSite);
                siteTile.SetSite(newSite);

                if(siteTile != region.GetSiteTiles()[0])
                {
                    siteTile.GetSite().TurnFaceDown();
                }
                else
                {
                    siteTile.GetSite().TurnFaceUp();
                }*/
            }
        }


    }

    public void NextSetup()
    {
        throw new System.NotImplementedException();
    }
}
