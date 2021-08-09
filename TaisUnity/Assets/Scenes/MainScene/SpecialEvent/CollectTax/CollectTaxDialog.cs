using System.Collections;
using System.Collections.Generic;
using Tais;
using UnityEngine;

public class CollectTaxDialog : MonoBehaviour
{
    public CountryCollectContainer countryCollectContainer;

    public void OnConfirm()
    {
        foreach(var collectElem in countryCollectContainer.GetComponentsInChildren<CountryCollectTax>())
        {
            collectElem.CollectTax();
        }
        Destroy(this.gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
