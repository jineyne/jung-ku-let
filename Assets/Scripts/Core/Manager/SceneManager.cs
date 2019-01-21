using RuntimeBuildscenes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManager : Singleton<SceneManager> {
    protected SceneManager() { }

    public Dictionary<ESceneType, bool> ClearDict = new Dictionary<ESceneType, bool>();

    public enum ESceneType {
        GameMain,
        GameScene1,
        GameScene2,
        GameScene3,
        GameScene4,
    }

    public ESceneType ActiveScene;

    private Dictionary<string, List<BuildSceneRecord>> SceneDict = new Dictionary<string, List<BuildSceneRecord>>();

    public void BuildScene(ESceneType type) {
        string sceneName = type.ToString();
        if (SceneDict.ContainsKey(sceneName)) {
            ActiveScene = type;
            int i = 0;
            foreach (BuildSceneRecord asset in SceneDict[sceneName]) {
                if (i++ == 0) {
                    UnityEngine.SceneManagement.SceneManager.LoadScene(asset.Name, LoadSceneMode.Single);
                } else {
                    UnityEngine.SceneManagement.SceneManager.LoadScene(asset.Name, LoadSceneMode.Additive);
                }
            }
            Screen.SetResolution(800, 600, false);
        } else {
            Debug.LogError(sceneName + "을 찾을 수 없습니다.");
        }

    }

    private void Awake() {
        foreach (string name in System.Enum.GetNames(typeof(ESceneType))) {
            SceneDict.Add(name, new List<BuildSceneRecord>() { });
        }

        foreach(ESceneType type in System.Enum.GetValues(typeof(ESceneType))) {
            ClearDict.Add(type, true); //type == ESceneType.GameScene1
        }

        BuildSceneRecord[] records = BuildScenes.Records;
        for (int i = 0; i < records.Length; i++) {
            BuildSceneRecord currentRecord = records[i];
            foreach (string name in System.Enum.GetNames(typeof(ESceneType))) {
                if (currentRecord.Name.StartsWith(name)) {
                    SceneDict[name].Add(currentRecord);
                }
            }
        }
    }
}
