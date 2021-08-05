using Tais;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainTimer : MonoBehaviour
{
    public int speed = 1;

    // Start is called before the first frame update
    public void StartTimer()
    {
        StartCoroutine(OnTimer());
    }

    private IEnumerator OnTimer()
    {
        yield return new WaitForSeconds(1/speed);

        Facade.date.Inc();

        StartCoroutine(OnTimer());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
