using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IGameEventService
{
    event Action<Player, IPlayerAction> OnActionPerformed;
    event Action<Player> OnAvailableActionsChanged; //for UI
    void ActionPerformed(Player player, IPlayerAction action);

    event Action<Player, Site, Site> OnPlayerSiteChanged;
    void PlayerSiteChanged(Player player, Site from, Site to); 
}

public class GameEventService : IGameEventService
{
    public event Action<Player, IPlayerAction> OnActionPerformed;
    public event Action<Player> OnAvailableActionsChanged;

    public event Action<Player, Site, Site> OnPlayerSiteChanged;

    public GameEventService()
    {
        
    }

    public void ActionPerformed(Player player, IPlayerAction action)
    {
        OnActionPerformed?.Invoke(player, action);
        OnAvailableActionsChanged?.Invoke(player);
    }

    public void PlayerSiteChanged(Player player, Site from, Site to)
    {
        OnPlayerSiteChanged?.Invoke(player, from, to);
    }    
}
