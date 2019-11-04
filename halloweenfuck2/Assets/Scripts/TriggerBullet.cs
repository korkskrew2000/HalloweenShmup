using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TriggerBullet : MonoBehaviour
{
    public UnityEvent onTrigger;
    public AudioClip dingSFX;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Bullet"))
        {
            onTrigger.Invoke();
            Destroy(collision.gameObject);
            AudioSource.PlayClipAtPoint(dingSFX, Camera.main.transform.position);
        }
    }

}
