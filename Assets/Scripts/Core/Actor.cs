using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
public class Actor : MonoBehaviour {

    public float _moveTime = 0.1f;
    public LayerMask _blockingLayer;

    protected bool bIsDrawing = false;
    protected bool bIsMoving = true;

    protected Animator mAnimator;
    protected SpriteRenderer mSpriteRenderer;
    protected Rigidbody2D mRigidbody;
    protected BoxCollider2D mBoxCollider;
    private float mInverseMoveTime;

    protected bool HasEffected(Actor other) {
        return this.bIsDrawing == other.bIsDrawing;
    }

    private void Awake() {
        mAnimator = GetComponent<Animator>();
        mSpriteRenderer = GetComponent<SpriteRenderer>();
        mRigidbody = GetComponent<Rigidbody2D>();
        mBoxCollider = GetComponent<BoxCollider2D>();

        mInverseMoveTime = 1.0f / _moveTime;
    }

    private void OnBecameVisible() {
        bIsDrawing = true;
    }

    private void OnBecameInvisible() {
        bIsDrawing = false;
    }
}
