using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IActPhaseService
{
    List<IPlayerAction> GetAvailableMajorActions(Player player);
    List<IPlayerAction> GetAvailableMinorActions(Player player);
    void PerformAction(IPlayerAction action, Player player);
}

public class ActPhaseService : IActPhaseService
{
    public ActPhaseService()
    {

    }
    public List<IPlayerAction> GetAvailableMajorActions(Player player)
    {
        List<IPlayerAction> actions = new List<IPlayerAction>();

        //Travel
        foreach(var site in ProjectContext.Instance.MapSetupService.sites)
        {
            PlayerAction travelAction = new TravelAction(site);
            if(travelAction.CanExecute(player))
            {
                actions.Add(travelAction);
            }
        }

        return actions;
    }

    public List<IPlayerAction> GetAvailableMinorActions(Player player)
    {
        throw new System.NotImplementedException();
    }

    public void PerformAction(IPlayerAction action, Player player)
    {
        if(!action.CanExecute(player))
        {
            return;
        }

        action.Execute(player);

        ProjectContext.Instance.GameEventService.ActionPerformed(player, action);
    }
}
