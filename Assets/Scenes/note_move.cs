using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class note_move : MonoBehaviour
{
    Stopwatch stopwatch = new Stopwatch();
    float default_position;

    void Start()
    {
        stopwatch.Start();
        default_position = gameObject.transform.localPosition.x;
    }

    void Update()
    {
        if (stopwatch.ElapsedMilliseconds >= 0)
        {
            transform.localPosition = new Vector2(default_position + (stopwatch.ElapsedMilliseconds / 1000f / 10f * 1000f), 0);

            if (gameObject.transform.localPosition.x >= 395)
            {
                UnityEngine.Debug.Log(stopwatch.ElapsedMilliseconds + "/" + gameObject.transform.localPosition.x);
            }
        }
    }
}