using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBootstrapper : MonoBehaviour {
    public GameObject _targetObject;

    private void Start() {
        DontDestroyOnLoad(_targetObject);

        SceneManager.Instance.BuildScene(SceneManager.ESceneType.GameMain);
    }
}
