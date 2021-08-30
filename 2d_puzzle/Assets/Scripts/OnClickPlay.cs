using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OnClickPlay : MonoBehaviour
{
    public void OnClickPlayButton()
    {
        SceneManager.LoadScene("SceneMain");
    }
}
