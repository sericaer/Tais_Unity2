using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Tais;

public class MainScene : MonoBehaviour
{
    public List<Image> departments = new List<Image>();

    public GameObject countryPrefabs;

    public Canvas canvas;

    // Start is called before the first frame update
    void Start()
    {
        Facade.InitLog((x)=>Debug.Log(x));

        Facade.LoadMods(Application.streamingAssetsPath + "/mods");

        Facade.BuildRunData();

        foreach (var depart in departments)
        {
            depart.alphaHitTestMinimumThreshold = 0.1f;

            depart.gameObject.AddComponent<Button>().onClick.AddListener(() =>
            {
                var gameObj = Instantiate(countryPrefabs, canvas.transform);
                gameObj.GetComponentInChildren<CountryDetail>().gmData = Facade.runData.countyMgr.Single(x => x.id == depart.name);
            });
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
