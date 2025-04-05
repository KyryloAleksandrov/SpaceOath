using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IConfigService
{
    SiteData[] siteDatas {get;}
    PlayerData[] playerDatas {get;}
}
public class ConfigService : IConfigService
{
    public SiteData[] siteDatas {get;}
    public PlayerData[] playerDatas{get;}

    public ConfigService(SitesConfig sitesConfig, PlayerConfig playerConfig)
    {
        siteDatas = sitesConfig.siteDatas;
        playerDatas = playerConfig.playerDatas;
    }
}
