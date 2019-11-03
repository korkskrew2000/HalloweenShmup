using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tickmaster : MonoBehaviour
{
    public int ticks;
    public int tickLimit = 10;
    public float tickerTimer = 1;
    float timer;

    void Tick()
    {
        ticks++;
        if (ticks >= tickLimit)
        {
            ticks = 0;
        }
    }
    private void Update()
    {
        timer += Time.deltaTime;
        while (timer > tickerTimer)
        {
            timer -= tickerTimer;
            Tick();
        }
        if (Input.GetKeyDown(KeyCode.F1))
        {
            print(ticks);
        }
    }
}
