using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IConfigService
{
    SiteData[] siteDatas {get;}
}
public class ConfigService : IConfigService
{
    public SiteData[] siteDatas {get;}

    public ConfigService(SitesConfig sitesConfig)
    {
        siteDatas = sitesConfig.siteDataArray;
    }
}
