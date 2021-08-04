using DynamicData;
using System;
using System.Collections;
using System.Collections.Generic;
using ReactiveMarbles.PropertyChanged;
using Tais;
using UnityEngine;
using UnityEngine.UI;

public class PopContainer : MonoBehaviour
{
    public GameObject PopPrefabs;

    public IObservableCache<IPop, IPopDef> gmData;
    

    // Start is called before the first frame update
    void Start()
    {
        gmData.Connect().OnItemAdded(x => 
        {
            var gameObj = Instantiate(PopPrefabs, this.transform);
            gameObj.GetComponentInChildren<Pop>().gmData = x;
        }).Subscribe().EndWith(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
