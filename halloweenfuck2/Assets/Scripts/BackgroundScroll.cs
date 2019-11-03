using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroll : MonoBehaviour
{
    public Transform cam;
    public float speed;
    Vector3 lastpos;

    void Start() {
        lastpos = cam.position;
    }

    void Update() {
        transform.position -= ((lastpos - cam.position) * speed);
        lastpos = cam.position;
    }
}
