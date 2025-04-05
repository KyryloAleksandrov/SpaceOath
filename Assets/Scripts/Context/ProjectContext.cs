using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectContext
{
    private static ProjectContext instance;

    public static ProjectContext Instance
    {
        get{
            if(instance == null)
            instance = new ProjectContext();
            return instance;
        }
    }

    public IConfigService ConfigService {get; private set;}

    public IMapSetupService MapSetupService {get; private set;}
    public IPlayerService PlayerService{get; private set;}

    public void Initialize(SitesConfig sitesConfig, PlayerConfig playerConfig)
    {
        ConfigService = new ConfigService(sitesConfig, playerConfig);
        MapSetupService = new MapSetupService(ConfigService);
        PlayerService = new PlayerService(ConfigService);
        Debug.Log("Loaded successfully");
    }
}
