using System;
using System.Collections;
using System.Collections.Generic;
using ReactiveMarbles.PropertyChanged;
using Tais;
using UnityEngine;
using UnityEngine.UI;

public class CountryDetail : MonoBehaviour
{
    public Text label;
    public Text popNum;
    public Text farm;
    public Text cropgrown;

    public PopContainer popContainer;

    public ICountry gmData;

    public void Close()
    {
        Destroy(this.gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        label.text = gmData.name;

        gmData.WhenPropertyValueChanges(x => x.popNum).Subscribe(x => popNum.text = x.ToString()).EndWith(this);
        gmData.WhenPropertyValueChanges(x => x.farm).Subscribe(x => farm.text = x.ToString()).EndWith(this);
        gmData.WhenPropertyValueChanges(x => x.cropGrown).Subscribe(x => cropgrown.text = x != null ?  x.ToString() : "--").EndWith(this);

        popContainer.gmData = gmData.popMgr;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
