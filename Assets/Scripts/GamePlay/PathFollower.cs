using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void OnPattFollowFinished();

public class PathFollower : MonoBehaviour {
    public Transform[] _transforms;
    public float _speed = 5.0f;
    public float _reachDist = 1.0f;
    public bool _loop = false;
    public int currentPoint = 0;

    public OnPattFollowFinished OnPathFollowFinished;

    private void Start() { }

    private void Update() {
        if(currentPoint >= _transforms.Length) {
            return;
        }

        float dist = 
            Vector3.Distance(_transforms[currentPoint].position, 
                            transform.position);
        transform.position = 
            Vector3.MoveTowards(
                    transform.position, 
                    _transforms[currentPoint].position, 
                    Time.deltaTime * _speed);
        if(dist <= _reachDist) {
            currentPoint++;
        }

        if(_loop && currentPoint >= _transforms.Length) {
            currentPoint = 0;
        }

        if(currentPoint >= _transforms.Length) {
            if(OnPathFollowFinished != null) {
                OnPathFollowFinished();
            }
        }
    }

    private void OnDrawGizmos() {
        if(_transforms.Length > 0) {
            for (int i = 0; i < _transforms.Length; i++) {
                if(_transforms[i] != null) {
                    Gizmos.DrawSphere(_transforms[i].position, _reachDist);
                }
            }
        }
    }
}
