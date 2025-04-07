using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IActPhaceService
{
    List<IPlayerAction> GetAvailableActions(Player player);
    List<IPlayerAction> GetAvailableMinorActions(Player player);
    void PerformAction(IPlayerAction action, Player player);
}

public class ActPhaseService : IActPhaceService
{
    public List<IPlayerAction> GetAvailableActions(Player player)
    {
        List<IPlayerAction> actions = new List<IPlayerAction>();

        //Travel
        

        return actions;
    }

    public List<IPlayerAction> GetAvailableMinorActions(Player player)
    {
        throw new System.NotImplementedException();
    }

    public void PerformAction(IPlayerAction action, Player player)
    {
        throw new System.NotImplementedException();
    }
}
