using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class GridEditor : MonoBehaviour {
    public Sprite _cursorGuideSprite;

    private GameObject mCursorGuideObject;

    void Start() {
        Screen.SetResolution(800, 600, false);

        mCursorGuideObject = new GameObject("guide");
        mCursorGuideObject.transform.parent = this.transform;

        SpriteRenderer sr = mCursorGuideObject.AddComponent<SpriteRenderer>();
        sr.sprite = _cursorGuideSprite;
    }

	// Update is called once per frame
	void Update () {
		if(_cursorGuideSprite != null) {
            Vector3 mousePos = Camera.main.ViewportToWorldPoint(Input.mousePosition);
            mousePos.x = Mathf.RoundToInt(mousePos.x);
            mousePos.y = Mathf.RoundToInt(mousePos.y);
            mousePos.z = Mathf.RoundToInt(mousePos.z);

            mCursorGuideObject.transform.position = mousePos;
        }
	}
}
