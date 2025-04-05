using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Boot : MonoBehaviour
{
    [SerializeField] private SitesConfig sitesConfig;
    [SerializeField] private PlayerConfig playerConfig;
    void Awake()
    {
        ProjectContext.Instance.Initialize(sitesConfig, playerConfig);
    }


    private IEnumerator Start()
    {
        yield return new WaitForEndOfFrame();
        SceneManager.LoadScene("Gameplay", LoadSceneMode.Single);
    }
}
