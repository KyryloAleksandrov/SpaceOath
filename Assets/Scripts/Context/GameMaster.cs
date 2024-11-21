using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
    public static GameMaster Instance;

    [SerializeField] private Map map;
    private IMapSetupService mapSetupService; 
    void Awake()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;

        mapSetupService = ProjectContext.Instance.MapSetupService;
    }
    // Start is called before the first frame update
    void Start()
    {
        mapSetupService.FirstSetup(map);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
