using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitTrigger : MonoBehaviour
{
    public GameObject player;
    public GameObject entryPoint;
    public Vector3 offset;
    public GameObject nextRoom;
    public GameObject previousRoom;
    Tickmaster tm;
    GameManager gm;
    public AudioClip dingSFX;
    public bool isEnd = false;

    private void Awake()
    {
        tm = FindObjectOfType<Tickmaster>().GetComponent<Tickmaster>();
        gm = FindObjectOfType<GameManager>().GetComponent<GameManager>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player")) {
            if (isEnd)
            {
                SceneManager.LoadScene(2);
            }
            gm.lastEntry = entryPoint;
            nextRoom.SetActive(true);
            player.transform.position = entryPoint.transform.position;
            previousRoom.SetActive(false);
            tm.ticks = 0;
            AudioSource.PlayClipAtPoint(dingSFX, Camera.main.transform.position);
        }
    }

}
