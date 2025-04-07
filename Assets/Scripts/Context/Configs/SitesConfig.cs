using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SitesConfig", menuName = "MyConfigs/SitesConfig")]
public class SitesConfig : ScriptableObject
{
    public SiteData[] siteDatas;
}

[Serializable]
public struct SiteData
{
    public Transform siteTransform; //it will use the default site prefab
    public string siteName;
    public Material faceUpMaterial;
}