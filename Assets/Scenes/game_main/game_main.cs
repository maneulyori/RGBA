using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UI;

public class game_main : MonoBehaviour
{
    Stopwatch stopwatch = new Stopwatch();

    public GameObject note;

    string note_sequence_raw;
    List<string> each_notes_data = new List<string>();
    List<int> each_notes_data_millisecond_time = new List<int>();

    public static int score = 0;

    void Start()
    {
        stopwatch.Start();

        note_sequence_raw = File.ReadAllText(@"C:\Users\pyui\unity projects\rhythm game by broadcaster's anthem\Assets\Scenes\game_main\note sequence test1.txt");
        note_sequence_raw.Trim();
        each_notes_data = new List<string>(Regex.Split(note_sequence_raw, "\r\n"));

        foreach (string a in each_notes_data)
        {
            string[] buffer1 = Regex.Split(a, "/");
            string[] buffer2 = Regex.Split(buffer1[0], ":");

            UnityEngine.Debug.Log(buffer2[0] + buffer2[1] + buffer2[2]);

            int buffer3 = (int.Parse(buffer2[0]) * 60000) + (int.Parse(buffer2[1]) * 1000) + (int.Parse(buffer2[2]));

            each_notes_data_millisecond_time.Add(buffer3);
        }
    }

    void FixedUpdate()
    {
        note_sequence_parser();
    }

    void Update()
    {
        GameObject.Find("score").GetComponent<Text>().text = score.ToString();

        if (Input.GetKeyDown(KeyCode.A))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition).origin, transform.forward);
            if (hit.transform != null)
            {
                if (hit.transform.name.Contains("note"))
                {
                    hit.transform.GetComponent<note_main>().check("r");
                }
            }
        }

        else if (Input.GetKeyDown(KeyCode.S))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition).origin, transform.forward);
            if (hit.transform != null)
            {
                if (hit.transform.name.Contains("note"))
                {
                    hit.transform.GetComponent<note_main>().check("g");
                }
            }
        }

        else if (Input.GetKeyDown(KeyCode.D))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition).origin, transform.forward);
            if (hit.transform != null)
            {
                if (hit.transform.name.Contains("note"))
                {
                    hit.transform.GetComponent<note_main>().check("b");
                }
            }
        }
    }

    float y_position = 0;

    void instantiate_note(int position_x, int position_y, string color)
    {
        float convert_position_x = (float)(position_x - 50) / 50 * 490;
        float convert_position_y = (float)(position_y - 50) / 50 * 490;
        Color32 convert_color = new Color32();

        switch (color)
        {
            case "r":
                {
                    convert_color = new Color32(255, 128, 128, 255);
                    break;
                }
            case "g":
                {
                    convert_color = new Color32(128, 255, 128, 255);
                    break;
                }
            case "b":
                {
                    convert_color = new Color32(128, 128, 255, 255);
                    break;
                }
        }

        GameObject buffer = Instantiate(note, GameObject.Find("game_area").transform);
        buffer.transform.localPosition = new Vector3(convert_position_x, convert_position_y, y_position);
        y_position += 0.01f;
        buffer.GetComponent<Image>().color = convert_color;
    }

    void note_sequence_parser()
    {
        if (each_notes_data_millisecond_time.Count != 0)
        {
            if (stopwatch.ElapsedMilliseconds > each_notes_data_millisecond_time[0] - 2000)
            {
                //position
                int position_x = 0;
                int position_y = 0;

                string[] position_buffer1 = Regex.Split(each_notes_data[0], "/");
                string[] position_buffer2 = Regex.Split(position_buffer1[2], ",");

                position_x = int.Parse(position_buffer2[0]);
                position_y = int.Parse(position_buffer2[1]);

                //color
                string color;

                string[] color_buffer1 = Regex.Split(each_notes_data[0], "/");

                color = color_buffer1[1];



                instantiate_note(position_x, position_y, color);

                each_notes_data.RemoveAt(0);
                each_notes_data_millisecond_time.RemoveAt(0);
            }
        }
    }
}