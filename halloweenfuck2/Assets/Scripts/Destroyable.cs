using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyable : MonoBehaviour
{
    public bool enemyCanDestroy;
    public int hitpoints;

    private void Update()
    {
        if (hitpoints <= 0)
        {
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Bullet"))
        {
            hitpoints--;
        }
        if (enemyCanDestroy)
        {
            if (collision.gameObject.layer == LayerMask.NameToLayer("EnemyBullet"))
            {
                hitpoints--;
            }
        }
        if (collision.gameObject.GetComponent<Bullet>().isCharged) {
            Destroy(gameObject);
        }
    }
}
