using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour
{

    public static int Minute {get;private set;};
    public static int Hour {get;private set;};

    private float minuteToRealTime = 0.5f;
    private float timer;
    // Start is called before the first frame update
    void Start()
    {
        Minute = 0;
        Hour = 22;
        timer = minuteToRealTime;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;

        if(timer <= 0)
        {
            Minute++;
            if(Minute >= 60)
            {
                Hour++;
                Minute = 0;
            }

            timer = minuteToRealTime;
        }
    }
}
