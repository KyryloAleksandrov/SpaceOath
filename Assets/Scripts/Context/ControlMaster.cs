using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlMaster : MonoBehaviour
{
    public static ControlMaster Instance;

    [SerializeField] private LayerMask siteLayerMask;

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
    }

    public void ClickOnSite()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        bool isSite = Physics.Raycast(ray, out RaycastHit raycastHit, float.MaxValue, siteLayerMask);

        if(!isSite)
        {
            return;
        }

        Transform siteTransform = raycastHit.transform;
        Site site = siteTransform.GetComponent<Site>();

        if(site.GetIsFaceDown())
        {
            site.TurnFaceUp();
        }
        else
        {
            site.TurnFaceDown();
        }
    }
}
