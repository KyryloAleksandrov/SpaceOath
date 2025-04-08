using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ControlMaster : MonoBehaviour
{
    public static ControlMaster Instance;

    [SerializeField] private LayerMask siteLayerMask;
    [SerializeField] private LayerMask pawnLayerMask;

    void Awake()
    {
         if(Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            ClickOnSite();
        }
        if(Input.GetMouseButtonDown(1))
        {
            clickOnPawn();
        }
    }

    public void ClickOnSite()
    {

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        bool isSite = Physics.Raycast(ray, out RaycastHit raycastHit, float.MaxValue, siteLayerMask);

        if(!isSite)
        {
            return;
        }

        Transform siteTileTransform = raycastHit.transform;
        SiteTile siteTile = siteTileTransform.GetComponent<SiteTile>();

        if(ProjectContext.Instance.PlayerService.pawnIsSelected == false)
        {
            if(siteTile.GetSiteVisual().GetIsFaceDown())
            {
                siteTile.GetSiteVisual().TurnFaceUp();
            }
            else
            {
                siteTile.GetSiteVisual().TurnFaceDown();
            }
        }
        else
        {
            Player activePlayer = ProjectContext.Instance.PlayerService.GetActivePlayer();
            Site targetSite = siteTile.GetSite();

            TravelAction travelAction = new TravelAction(targetSite);

            if(travelAction.CanExecute(activePlayer))
            {
                ProjectContext.Instance.ActPhaseService.PerformAction(travelAction, activePlayer);
                ProjectContext.Instance.PlayerService.pawnIsSelected = false;
            }

            else
            {
                ProjectContext.Instance.PlayerService.pawnIsSelected = false;
                Debug.Log("Can't perform");
            }
        }


        //Debug.Log(siteTile.GetSite().GetName() + " " + siteTile.GetSite().GetRegionIndex());
    }

    public void clickOnPawn()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        bool isPawn = Physics.Raycast(ray, out RaycastHit raycastHit, float.MaxValue, pawnLayerMask);

        if(!isPawn)
        {
            return;
        }

        Transform pawnTransform = raycastHit.transform;
        Pawn pawn = pawnTransform.GetComponent<Pawn>();

        if(pawn.player == ProjectContext.Instance.PlayerService.GetActivePlayer())
        {
            ProjectContext.Instance.PlayerService.pawnIsSelected = !ProjectContext.Instance.PlayerService.pawnIsSelected;
        }

        Debug.Log(pawn.player.currentSite.GetName() + " " + ProjectContext.Instance.PlayerService.pawnIsSelected);
    }
}
