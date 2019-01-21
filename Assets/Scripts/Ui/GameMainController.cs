using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMainController : MonoBehaviour {
    private void Start() {
        Screen.SetResolution(800, 600, false);
    }

	private void FixedUpdate() {
        Screen.SetResolution(800, 600, false);
		if(Input.GetKeyDown(KeyCode.X)) {
            Screen.SetResolution(800, 600, false);
            SceneManager.Instance.BuildScene(SceneManager.ESceneType.GameScene1);
        }
	}
}
