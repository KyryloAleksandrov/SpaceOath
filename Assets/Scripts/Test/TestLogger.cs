using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestLogger : MonoBehaviour
{
    private void OnEnable()
    {
        ProjectContext.Instance.GameEventService.OnPlayerSiteChanged += HandlePlayerSiteChanged;
    }

    private void OnDisable()
    {
        ProjectContext.Instance.GameEventService.OnPlayerSiteChanged -= HandlePlayerSiteChanged;
    }

    private void HandlePlayerSiteChanged(Player player, Site from, Site to)
    {
        Debug.Log($"[TestLogger] {player.playerName} traveled from {from.GetName()} to {player.currentSite.GetName()}");
    }
}
