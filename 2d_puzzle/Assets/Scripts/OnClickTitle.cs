using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OnClickTitle : MonoBehaviour
{
    public void OnClickTitleButton()
    {
        SceneManager.LoadScene("TitleScene");
    }

}
