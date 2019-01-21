using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : Actor {
    public bool _killOnInvisible = false;

    private float firstDelay = 1;

    private void Update() {
        if(firstDelay > 0) {
            firstDelay -= Time.deltaTime;
            return;
        }
        if(!bIsDrawing && _killOnInvisible) {
            this.gameObject.SetActive(false);
        }
    }
}
