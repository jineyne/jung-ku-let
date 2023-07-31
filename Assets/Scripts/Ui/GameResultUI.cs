using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameResultUI : MonoBehaviour
{
    [SerializeField] 
    private bool _lastRound = false;

    [SerializeField] private Button _btnNextRound;

    [SerializeField] private SceneManager.ESceneType _nextRound;

    void Start()
    {
        _btnNextRound.gameObject.SetActive(!_lastRound);
    }

    private void OnEnable()
    {
        Time.timeScale = 0;
    }

    private void OnDisable()
    {
        Time.timeScale = 1;
    }

    public void GoHome()
    {
        SceneManager.Instance.BuildScene(SceneManager.ESceneType.GameMain);
    }

    public void Restart()
    {
        SceneManager.Instance.BuildScene(SceneManager.Instance.ActiveScene);
    }

    public void NextRound()
    {
        SceneManager.Instance.BuildScene(_nextRound);
    }
}
