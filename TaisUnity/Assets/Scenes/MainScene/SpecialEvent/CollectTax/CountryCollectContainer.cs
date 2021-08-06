using System.Collections;
using System.Collections.Generic;
using Tais;
using UnityEngine;

public class CountryCollectContainer : MonoBehaviour
{
    public GameObject countryCollectPrefabs;

    // Start is called before the first frame update
    void Start()
    {
        foreach(var country in Facade.runData.countyMgr)
        {
            var gameObj = Instantiate(countryCollectPrefabs, this.transform);
            gameObj.GetComponentInChildren<CountryCollectTax>().gmData = country;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
