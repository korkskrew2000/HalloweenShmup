using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PersistentDataContainer : MonoBehaviour
{
    public int roomNumber;
    List<int> roomList = new List<int> { };
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
        roomNumber = SceneManager.GetActiveScene().buildIndex;
        roomList.Add(roomNumber);
        print(roomNumber);
    }
}
