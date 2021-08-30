using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;	// シーン切り替えに必要

// タッチすると、シーンを切り換える
public class OnMouseDown_SwitchScene : MonoBehaviour {

	public string sceneName;  // シーン名：Inspectorで指定

	void OnMouseDown() { // タッチしたら
		// シーンを切り換える
		SceneManager.LoadScene (sceneName);
	}
}
