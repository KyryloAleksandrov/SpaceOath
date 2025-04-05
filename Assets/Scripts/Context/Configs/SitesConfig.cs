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
    public Transform siteTransform;
}