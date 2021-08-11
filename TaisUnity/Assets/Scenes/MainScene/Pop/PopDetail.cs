using DynamicData;
using System;
using System.Collections;
using System.Collections.Generic;
using ReactiveMarbles.PropertyChanged;
using Tais;
using UnityEngine;
using UnityEngine.UI;

public class PopDetail : MonoBehaviour
{
    public Text type;
    public Text name;
    public Text popNum;
    public Text farm;
    public Text perFarm;
    public Text goodNum;
    public Text perGood;
    public Text consume;

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

            _gmData.WhenPropertyValueChanges(x => x.num).Subscribe(x => popNum.text = x.ToString("N0")).EndWith(this);
            _gmData.WhenPropertyValueChanges(x => x.consume).Subscribe(x => consume.text = x.ToString("F2")).EndWith(this);
            _gmData.WhenPropertyValueChanges(x => x.good).Subscribe(x => goodNum.text = x.ToString("N0")).EndWith(this);
            _gmData.WhenPropertyValueChanges(x => x.per_good).Subscribe(x => perGood.text = x.ToString("F2")).EndWith(this);

            if (_gmData.farmWork != null)
            {
                _gmData.farmWork.WhenPropertyValueChanges(x => x.farm).Subscribe(x => farm.text = x.ToString("N0")).EndWith(this);
                _gmData.farmWork.WhenPropertyValueChanges(x => x.per_farm).Subscribe(x => perFarm.text = x.ToString("F2")).EndWith(this);
            }
        }
    }

    private IPop _gmData;

    public void OnClose()
    {
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
