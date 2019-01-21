using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageButton : MonoBehaviour {
    public SceneManager.ESceneType sceneType;
    public Button targetButton;

    private void Start() {
        targetButton.interactable = SceneManager.Instance.ClearDict[sceneType];
    }

    public void OnClick() {
        SceneManager.Instance.BuildScene(sceneType);
    }
}
