using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    Stopwatch stopwatch = new Stopwatch();

    void Start()
    {
        stopwatch.Start();
    }

    void Update()
    {
        if (stopwatch.IsRunning == true)
        {
            transform.localPosition = new Vector2(stopwatch.ElapsedMilliseconds / 1000f / 10f * 1000f, 0);

            if (gameObject.transform.localPosition.x >= 995)
            {
                UnityEngine.Debug.Log(stopwatch.ElapsedMilliseconds + "/" + gameObject.transform.localPosition.x);
            }
        }
    }

    public void button()
    {
        stopwatch.Start();
    }
}
