using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TravelAction : PlayerAction
{
    private Site targetSite;
    public override string name => $"Travel to {targetSite.GetName()}";

    public TravelAction(Site targetSite)
    {
        this.targetSite = targetSite;
    }

    public override bool CanExecute(Player player)
    {
        return player.currentSupply >= ProjectContext.Instance.MapSetupService.GetTravelCost(player.currentSite, targetSite) && player.currentSite != targetSite;
    }

    public override void Execute(Player player)
    {
        int initialSupply = player.currentSupply;
        int supplyCost = ProjectContext.Instance.MapSetupService.GetTravelCost(player.currentSite, targetSite);

        Site from = player.currentSite;
        player.currentSupply -= supplyCost;
        player.currentSite = targetSite;

        player.pawn.GetComponent<Pawn>().ChangePosition(targetSite.transform.position); //in future, move it to the class that handles visual changes and trigger it via event

        //Debug.Log($"{player.playerName} traveled from {from.GetName()} to {player.currentSite.GetName()}; supply spent {initialSupply} - {supplyCost} = {player.currentSupply}");

        ProjectContext.Instance.GameEventService.PlayerSiteChanged(player, from, targetSite);
    }

    public Site GetTargetSite()
    {
        return this.targetSite;
    }
}
