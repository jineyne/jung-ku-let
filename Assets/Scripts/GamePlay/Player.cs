using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Actor {
    private PathFollower mPathFollower;

    [SerializeField] private GameObject victoryUI;
    [SerializeField] private GameObject deathUI;

    private void Start() {
        mPathFollower = GetComponent<PathFollower>();
        mPathFollower.OnPathFollowFinished += this.OnPathFollowFinished;
        
        victoryUI.SetActive(false);
        deathUI.SetActive(false);
    }

    private void OnPathFollowFinished() {
        GameClear();
    }

    private void GameClear() {
        SceneManager.ESceneType nextType;

        /*switch (SceneManager.Instance.ActiveScene) {
            case SceneManager.ESceneType.GameScene1:
                nextType = SceneManager.ESceneType.GameScene2;
                break;
            case SceneManager.ESceneType.GameScene2:
                nextType = SceneManager.ESceneType.GameScene3;
                break;
            case SceneManager.ESceneType.GameScene3:
                nextType = SceneManager.ESceneType.GameScene4;
                break;
            case SceneManager.ESceneType.GameScene4:
                nextType = SceneManager.ESceneType.GameMain;
                break;
            default:
                nextType = SceneManager.ESceneType.GameMain;
                break;
        }

        if(nextType != SceneManager.ESceneType.GameMain) {
            SceneManager.Instance.ClearDict[nextType] = true;
            SceneManager.Instance.BuildScene(nextType);
        } else {
            SceneManager.Instance.BuildScene(nextType);
        }*/

        if (victoryUI)
        {
            victoryUI.SetActive(true);
        }
    }

    public void GameOver() {
        if (mPathFollower.enabled && deathUI) {
            mPathFollower.enabled = false;
            /*StartCoroutine(GameOverCoroutine());*/
            deathUI.SetActive(true);
        }
    }

    IEnumerator GameOverCoroutine() {
        yield return new WaitForSeconds(1);
        SceneManager.Instance.BuildScene(SceneManager.ESceneType.GameMain);
        yield return null;
    }

    private void FixedUpdate() {
        Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);
        if (pos.x < 0 || pos.x > 1 || pos.y < 0 || pos.y > 1) {
            GameOver();
        }
    }

    private void OnTriggerEnter2D(Collider2D col) {
        Debug.Log(col.gameObject);
        if(col.gameObject.GetComponent<Monster>() != null) {
            GameOver();
        }
    }
}
