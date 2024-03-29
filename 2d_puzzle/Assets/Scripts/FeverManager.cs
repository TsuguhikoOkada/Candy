using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FeverManager : MonoBehaviour
{

    Scrollbar scrollbar;
    float feverValue = 0; 
    bool isFever = false;

    Action onFeverStartCallBack;

    void Start()
    {
        GameObject canvas = GameObject.Find("Canvas");
        if (canvas != null)
        {
            Transform feverGUI = canvas.transform.Find("FeverGUI");
            if (feverGUI != null)
            {
                scrollbar = feverGUI.GetComponent<Scrollbar>();
            }
        }
    }

    void Update()
    {
        if (!isFever)
        {
            feverValue -= Time.deltaTime * 2;
            if (feverValue < 0)
            {
                feverValue = 0;
            }
        }
        else
        {
            feverValue -= Time.deltaTime * 10;
            if (feverValue < 0)
            {
                feverValue = 0;
                OnFeverEnd();
            }
        }

        SyncFeverGUI();
    }

    public void RegisterOnFeverCallBack(Action onFeverCallBack)
    {
        this.onFeverStartCallBack = onFeverCallBack;
    }

    public void AddFeverValue(int chain)
    {
        if (!isFever)
        {
            feverValue += 3.4f * (float)chain;
            if (feverValue > 100)
            {
                feverValue = 100;
                OnFeverStart();
            }
        }
    }

    public bool IsFever()
    {
        return isFever;
    }

    void OnFeverStart()
    {
        isFever = true;
        if (onFeverStartCallBack != null)
        {
            onFeverStartCallBack();
        }
    }

    void OnFeverEnd()
    {
        isFever = false;
    }

    void SyncFeverGUI()
    {
        if (scrollbar != null)
        {
            scrollbar.size = feverValue / 100f;
        }
    }
}
