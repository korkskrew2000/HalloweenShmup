using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public float explosionRadius;
    GameManager gm;
    public AudioClip explosion;

    private void Start()
    {
        gm = FindObjectOfType<GameManager>().GetComponent<GameManager>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (Vector3.Distance(transform.position, collision.gameObject.transform.position) > explosionRadius)
        {
            if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
            {
                gm.PlayerHit();
            }
            if (collision.gameObject.layer == LayerMask.NameToLayer("Enemy") || collision.gameObject.layer == LayerMask.NameToLayer("EnemyBullet") || collision.gameObject.layer == LayerMask.NameToLayer("Bullet"))
            {
                Destroy(collision.gameObject);
            }
        }
        AudioSource.PlayClipAtPoint(explosion, Camera.main.transform.position);
        Destroy(gameObject);
    }
}
