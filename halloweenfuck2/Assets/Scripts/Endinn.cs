using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Endinn : MonoBehaviour
{
    bool f5Hit = false;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F5))
        {
            f5Hit = true;
        }
        if (Input.GetKeyDown(KeyCode.Space) && f5Hit)
        {
            SceneManager.LoadScene(2);
        }
    }
}
