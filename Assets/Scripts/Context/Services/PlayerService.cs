using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPlayerService
{
    Player activePlayer {get;}
    List<Player> players {get;}

    Player GetActivePlayer();
    void SetActivePlayer(Player player);

    void SpawnPawn(Player player, Site site);
}

public class PlayerService : IPlayerService
{
    public Player activePlayer {get; private set;}
    public List<Player> players {get;}

    public PlayerService(IConfigService configService)
    {
        players = new List<Player>();

        foreach(PlayerData playerData in configService.playerDatas)
        {
            switch(playerData.playerRole)
            {
                case PlayerRole.Regent:

                    break;
                
                case PlayerRole.Renegade:
                Renegade renegade = new Renegade(playerData.playerName, playerData.pawn, playerData.color);
                players.Add(renegade);
                    break;
                
                case PlayerRole.Vassal:

                    break;
                
            }
        }

        SetActivePlayer(players[0]);    //for now to use for debug
    }

    public Player GetActivePlayer()
    {
        return activePlayer;
    }

    public void SetActivePlayer(Player player)
    {
        this.activePlayer = player;
    }

    public void SpawnPawn(Player player, Site site)
    {
        Transform pawnTranform = GameObject.Instantiate(player.pawn, site.transform.position + new Vector3(0, -0.1f, 0), Quaternion.identity);

        Pawn pawn = pawnTranform.GetComponent<Pawn>();
        pawn.PaintPlayerColor(player.color);
        pawn.SetPlayer(player);
    }
}
