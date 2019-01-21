using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenManager : Singleton<ScreenManager> {
    private int height = 800;
    private IntPtr hWnd;
    private Rect lastWindowRect;

    void Start() {
        hWnd = Win32API.FindWindow(null, "team4");
        Win32API.GetWindowRect(hWnd, ref lastWindowRect);
    }

    // Update is called once per frame
    void Update () {
        Rect rect = new Rect();
        Win32API.GetWindowRect(hWnd, ref rect);

        float topDiff = (lastWindowRect.Top - rect.Top) * 0.01f;
        float bottomDiff = (lastWindowRect.Bottom - rect.Bottom) * 0.01f;
        float leftDiff = (lastWindowRect.Left - rect.Left) * 0.01f;
        float rightDiff = (lastWindowRect.Right - rect.Right) * 0.01f;
        Vector3 pos = Camera.main.transform.position;

        pos.y += topDiff;
        pos.y += bottomDiff;
        pos.x -= leftDiff;
        pos.x -= rightDiff;

        Camera.main.orthographicSize = (float)Screen.height / 120.0f;
        Camera.main.transform.position = pos;

        lastWindowRect = rect;
    }
}
