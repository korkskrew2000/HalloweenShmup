using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitTrigger : MonoBehaviour
{
    public GameObject player;
    public GameObject entryPoint;
    public Vector3 offset;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player")) { player.transform.position = entryPoint.transform.position + offset; }
    }

}
