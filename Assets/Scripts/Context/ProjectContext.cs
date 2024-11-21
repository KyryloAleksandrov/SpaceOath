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

    public void Initialize(SitesConfig sitesConfig)
    {
        ConfigService = new ConfigService(sitesConfig);
        MapSetupService = new MapSetupService(ConfigService);
        Debug.Log("Loaded successfully");
    }
}
