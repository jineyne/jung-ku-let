using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : Monster {
    private float delay = 1;

    private void FixedUpdate() {
        if(delay > 0) {
            delay -= Time.deltaTime;
            return;
        }

        if (bIsDrawing) {
            Player player = FindObjectOfType<Player>();
            if (player != null) {
                if(HasEffected(player)) {
                    player.GameOver();
                }
            }
        }
    }
}
