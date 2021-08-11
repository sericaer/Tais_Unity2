using DynamicData;
using System;
using System.Collections;
using System.Collections.Generic;
using ReactiveMarbles.PropertyChanged;
using Tais;
using UnityEngine;
using UnityEngine.UI;

public class Pop : MonoBehaviour
{
    public GameObject PopDetailPrefabs;

    public Text type;
    public Text name;
    public Text num;

    public IPop gmData
    {
        get
        {
            return _gmData;
        }
        set
        {
            _gmData = value;

            type.text = _gmData.def.type;

            _gmData.WhenPropertyValueChanges(x => x.num).Subscribe(x => num.text = x.ToString("N0")).EndWith(this);
        }
    }

    private IPop _gmData;
    
    public void OnClick()
    {
        var gameObj = Instantiate(PopDetailPrefabs, transform.GetComponentInParent<Canvas>().transform);
        gameObj.GetComponentInChildren<PopDetail>().gmData = gmData;
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
