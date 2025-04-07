using System.Collections;
using System.Collections.Generic;
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

        if(siteTile.GetSiteVisual().GetIsFaceDown())
        {
            siteTile.GetSiteVisual().TurnFaceUp();
        }
        else
        {
            siteTile.GetSiteVisual().TurnFaceDown();
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

        Debug.Log(pawn.player.currentSupply);
    }
}
