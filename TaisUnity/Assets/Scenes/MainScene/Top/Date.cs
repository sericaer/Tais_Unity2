using System;
using System.Collections;
using System.Collections.Generic;
using ReactiveMarbles.PropertyChanged;
using UnityEngine;
using UnityEngine.UI;
using Tais;

public class Date : MonoBehaviour
{
    public Text year;
    public Text month;
    public Text day;

    public IDate gmData 
    { 
        get
        {
            return _gmData;
        }
        set
        {
            _gmData = value;

            _gmData.WhenPropertyValueChanges(x => x.value).Subscribe(d =>
            {
                year.text = d.y.ToString();
                month.text = d.m.ToString();
                day.text = d.d.ToString();
            }).EndWith(this);
        }
    }

    private IDate _gmData;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
