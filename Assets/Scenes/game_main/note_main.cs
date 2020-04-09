using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;

public class note_main : MonoBehaviour
{
    Stopwatch stopwatch = new Stopwatch();

    void Start()
    {
        stopwatch.Start();
    }

    void FixedUpdate()
    {
        if (stopwatch.ElapsedMilliseconds > 0)
        {
            gameObject.transform.GetChild(0).gameObject.GetComponent<Image>().fillAmount = stopwatch.ElapsedMilliseconds / (float)1000 / 2;
        }

        if(stopwatch.ElapsedMilliseconds > 2200)
        {
            UnityEngine.Debug.Log(stopwatch.ElapsedMilliseconds + "aaaaa");
            Destroy(gameObject);
        }
    }
}
