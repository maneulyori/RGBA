using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class note_button : MonoBehaviour
{
    Stopwatch stopwatch = new Stopwatch();

    void Start()
    {
        stopwatch.Start();
    }

    void Update()
    {
        
    }

    public void click()
    {
        if(stopwatch.ElapsedMilliseconds < 4000)
        {
            UnityEngine.Debug.Log("miss");
        }
        else if (4000 <= stopwatch.ElapsedMilliseconds & stopwatch.ElapsedMilliseconds < 6000)
        {
            UnityEngine.Debug.Log("hit");
        }
        else
        {
            UnityEngine.Debug.Log("miss");
        }

        Destroy(gameObject);
    }
}
