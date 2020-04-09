using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class test : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(gameObject.GetComponent<Image>().material.GetColor("_OutlineColor"));

        int intensity = 10;

        gameObject.GetComponent<Image>().material.SetColor("_OutlineColor", new Color(1 * intensity, 1 * intensity, 1 * intensity, 1 * intensity));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
