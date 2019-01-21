using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class LaserType : Monster {

    public Sprite _razerSprite;
    public Vector3 _toVec;
    public LayerMask _playerMask;

    private LineRenderer mLineRenderer;

    private void Start() {
        mLineRenderer = GetComponent<LineRenderer>();
        mLineRenderer.startColor = Color.red;
        mLineRenderer.endColor = Color.red;
    }

	private void FixedUpdate() {
        mLineRenderer.enabled = bIsDrawing;

        if (bIsDrawing) {
            Vector3 start = transform.position;
            Vector3 end = start + _toVec * 100;

            mLineRenderer.SetPosition(0, start);
            mLineRenderer.SetPosition(1, end);

            mBoxCollider.enabled = false;
            RaycastHit2D hit = 
                Physics2D.Linecast(transform.position, end, _playerMask);
            mBoxCollider.enabled = true;

            if(hit.transform != null) {
                mLineRenderer.SetPosition(1, hit.transform.position);
                Player player = hit.transform.GetComponent<Player>();
                if (player != null) {
                    player.GameOver();
                }
            }
        }
    }
}
