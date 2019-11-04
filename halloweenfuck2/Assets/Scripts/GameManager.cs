using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject lastEntry;
    public int lives = 3;
    public GameObject player;
    public Vector3 offset;
    public AudioClip deathSFX;
    
    public void PlayerHit()
    {
        //if (lives == 0)
        //{
        //    GameOver();
        //    return;
        //} else
        //lives--;
        player.transform.position = lastEntry.transform.position + offset;
        AudioSource.PlayClipAtPoint(deathSFX, Camera.main.transform.position);
        player.GetComponent<PlayerMover>().notOnGround = true;
        player.GetComponent<PlayerMover>().jumping = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
    //void GameOver()
    //{
    //    Time.timeScale = 0;
    //    print("game over!");
    //}
}
