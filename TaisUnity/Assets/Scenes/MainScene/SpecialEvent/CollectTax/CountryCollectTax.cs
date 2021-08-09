using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Tais;
using UnityEngine;
using UnityEngine.UI;

public class CountryCollectTax : MonoBehaviour
{
    public Text lablel;
    public Slider slider;
    public Text taxValue;

    private IDictionary<string, double> taxDetail;

    public ICountry gmData
    {
        get
        {
            return _gmData;
        }
        set
        {
            _gmData = value;
            lablel.text = _gmData.name;

            slider.onValueChanged.AddListener((v) =>
            {
                taxDetail = _gmData.CalcTaxDetail((TAX_LEVEL)v);
                taxValue.text = taxDetail.Values.Sum().ToString();
            });
        }
    }

    internal void CollectTax()
    {
        gmData.CollectTax((TAX_LEVEL)((int)slider.value));
    }

    private ICountry _gmData;

    // Start is called before the first frame update
    void Start()
    {
        slider.maxValue = Enum.GetValues(typeof(TAX_LEVEL)).Cast<int>().Max();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
