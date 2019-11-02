using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    int nextRoom;
    Random rnd = new Random();
    int ezRnd;
    int medRnd;
    int hardRnd;
    bool isEz;
    bool isMed;
    bool isHard;
    public int roomNumber;
    List<int> roomList = new List<int> { };
    public GameObject lastEntry;
    public int lives = 3;
    public GameObject player;
    public Vector3 offset;
    private void Awake()
    {
        roomNumber = SceneManager.GetActiveScene().buildIndex;
        roomList.Add(roomNumber);
        print(roomNumber);
    }
    public void PlayerHit()
    {
        if (lives == 0)
        {
            GameOver();
            return;
        } else
        lives--;
        player.transform.position = lastEntry.transform.position + offset;

    }
    void GameOver()
    {
        Time.timeScale = 0;
        print("game over!");
    }
}
