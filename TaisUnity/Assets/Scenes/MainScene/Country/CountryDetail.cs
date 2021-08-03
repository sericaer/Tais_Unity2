using System.Collections;
using System.Collections.Generic;
using Tais;
using UnityEngine;
using UnityEngine.UI;

public class CountryDetail : MonoBehaviour
{
    public Text label;
    public ICountry gmData;

    public void Close()
    {
        Destroy(this.gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        label.text = gmData.name;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
