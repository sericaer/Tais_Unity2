using ReactiveMarbles.PropertyChanged;
using System;
using System.Collections;
using System.Collections.Generic;
using Tais;
using UnityEngine;
using UnityEngine.UI;

public class TaxPanel : MonoBehaviour
{
    public Text taxValue;

    public IProduct gmData
    {
        get
        {
            return _gmData;
        }
        set
        {
            _gmData = value;

            _gmData.WhenPropertyValueChanges(x => x.count).Subscribe(x => taxValue.text = x.ToString("N"));
        }
    }

    private IProduct _gmData;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
