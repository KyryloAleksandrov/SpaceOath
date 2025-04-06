using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
    public static GameMaster Instance;

    [SerializeField] private Map map;
    private IMapSetupService mapSetupService;
    private IPlayerService playerService; 
    void Awake()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;

        mapSetupService = ProjectContext.Instance.MapSetupService;
        playerService = ProjectContext.Instance.PlayerService;
    }
    // Start is called before the first frame update
    void Start()
    {
        mapSetupService.FirstSetup(map);
        foreach(Player player in playerService.players)
        {
            //Debug.Log(player.playerName + " " + player.Role);
        }

        playerService.SpawnPawn(playerService.activePlayer, mapSetupService.sites[5]);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
