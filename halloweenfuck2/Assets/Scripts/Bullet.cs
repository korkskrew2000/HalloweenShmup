using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 2f;
    void Update()
    {
        gameObject.transform.position += Vector3.right * Time.deltaTime * speed;
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
         Destroy(gameObject);
    }
}
