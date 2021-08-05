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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    internal void AssocateData()
    {
        Facade.date.WhenPropertyValueChanges(x => x.value).Subscribe(d =>
          {
              year.text = d.y.ToString();
              month.text = d.m.ToString();
              day.text = d.d.ToString();
          });
    }
}
