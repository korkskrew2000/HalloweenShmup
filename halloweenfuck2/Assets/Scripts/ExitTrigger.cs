using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitTrigger : MonoBehaviour
{
    public GameObject player;
    public GameObject entryPoint;
    public Vector3 offset;
    public GameObject nextRoom;
    public GameObject previousRoom;
    Tickmaster tm;
    GameManager gm;

    private void Awake()
    {
        tm = FindObjectOfType<Tickmaster>().GetComponent<Tickmaster>();
        gm = FindObjectOfType<GameManager>().GetComponent<GameManager>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player")) {
            gm.lastEntry = entryPoint;
            nextRoom.SetActive(true);
            player.transform.position = entryPoint.transform.position;
            previousRoom.SetActive(false);
            tm.ticks = 0;
        }
    }

}
