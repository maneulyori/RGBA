using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class scene_main : MonoBehaviour
{
    Stopwatch stopwatch = new Stopwatch();
    public GameObject note;

    void Start()
    {
        stopwatch.Start();
    }

    void note_instantiate()
    {
        GameObject buffer = Instantiate(note, GameObject.Find("area").transform);
        buffer.transform.localPosition = new Vector2(-600, 0);
    }

    void Update()
    {

    }

    public void button()
    {
        note_instantiate();
    }
}
