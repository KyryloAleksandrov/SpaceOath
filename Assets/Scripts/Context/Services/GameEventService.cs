using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IGameEventService
{
    event Action<Player, IPlayerAction> OnActionPerformed;
    event Action<Player> OnAvailableActionsChanged; //for future use for UI
    void ActionPerformed(Player player, IPlayerAction action); 
}

public class GameEventService : IGameEventService
{
    public event Action<Player, IPlayerAction> OnActionPerformed;
    public event Action<Player> OnAvailableActionsChanged;

    public void ActionPerformed(Player player, IPlayerAction action)
    {
        OnActionPerformed?.Invoke(player, action);
        OnAvailableActionsChanged?.Invoke(player);
    }
}
