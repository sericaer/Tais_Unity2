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

    // Start is called before the first frame update
    void Start()
    {
        Facade.LoadMods();
        Facade.BuildRunData();

        foreach (var depart in departments)
        {
            depart.alphaHitTestMinimumThreshold = 0.1f;

            depart.gameObject.AddComponent<Button>().onClick.AddListener(() =>
            {
                Debug.Log(Facade.runData.countyMgr.Single(x=>x.id == depart.name).name);
            });
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
