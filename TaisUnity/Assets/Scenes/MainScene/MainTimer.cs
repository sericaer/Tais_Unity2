using Tais;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainTimer : MonoBehaviour
{
    public static MainTimer inst;

    public Toggle togSpeed1;
    public Toggle togSpeed2;
    public Toggle togSpeed3;

    public Toggle togPause;

    public int speed { get; set; }

    public bool isPause => isSysPause || isUserPause;

    public bool isSysPause 
    { 
        get
        {
            return _isSysPause;
        }
        set
        {
            _isSysPause = value;

            togSpeed1.interactable = !value;
            togSpeed2.interactable = !value;
            togSpeed3.interactable = !value;
            togPause.interactable = !value;
        }
    }
    private bool isUserPause { get; set; }

    private int _speed { get; set; }

    private bool _isSysPause;

    // Start is called before the first frame update
    public void StartTimer()
    {
        StartCoroutine(OnTimer());
    }

    public void OnSpeedChanged(int value)
    {
        speed = value;
    }

    public void OnUserPause(bool flag)
    {
        isUserPause = flag;
    }

    private void Start()
    {
        inst = this;

        isSysPause = false;
        isUserPause = false;

        speed = 1;
    }

    private IEnumerator OnTimer()
    {
        yield return new WaitForSeconds(1.0f/speed);
        yield return new WaitUntil(() => !isPause);

        Facade.date.Inc();

        StartCoroutine(OnTimer());
    }

    // Update is called once per frame
    private void Update()
    {
        
    }
}
