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
            var productRegisters = collectElem.CollectTax();

            Facade.productMgr.tax.Add(productRegisters);
        }
        Destroy(this.gameObject);

        MainTimer.inst.isSysPause = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        MainTimer.inst.isSysPause = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
