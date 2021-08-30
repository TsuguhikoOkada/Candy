//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class TimeManager : MonoBehaviour
{
    

    Text timeText;
    float time = 60;

    void Start()
    {
        GameObject canvas = GameObject.Find("Canvas");
        if (canvas != null)
        {
            Transform timeGUI = canvas.transform.Find("TimeGUI");
            if (timeGUI != null)
            {
                timeText = timeGUI.GetComponent<Text>();
                SyncTimeGUI();
            }
        }
    }

    void Update()
    {
        time -= Time.deltaTime;
        if (time < 0)
        {
            time = 0;
        }

        if (time == 0)
        {
            BlockManager manager = this.gameObject.GetComponent<BlockManager>();
            manager.ChangeScene();
        }

        SyncTimeGUI();
    }

    public void AddTime(float deltaTime)
    {
        time += deltaTime;
    }

    void SyncTimeGUI()
    {
        if (timeText != null)
        {
            timeText.text = ((int)time).ToString();
        }
    }
}