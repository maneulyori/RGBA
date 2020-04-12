using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;

public class note_main : MonoBehaviour
{
    Stopwatch stopwatch = new Stopwatch();
    bool hit_check = false;

    void Start()
    {
        stopwatch.Start();

        gameObject.transform.GetChild(0).GetComponent<Image>().color =
            new Color(gameObject.GetComponent<Image>().color.r, gameObject.GetComponent<Image>().color.g, gameObject.GetComponent<Image>().color.b, 0);
    }

    public void check(string key)
    {
        if (key == "r" & gameObject.GetComponent<Image>().color.r == 1 & hit_check == false)
        {
            hit_check = true;
            gameObject.GetComponent<Collider2D>().enabled = false;
            timer_check();
        }

        else if (key == "g" & gameObject.GetComponent<Image>().color.g == 1 & hit_check == false)
        {
            hit_check = true;
            timer_check();
        }

        else if (key == "b" & gameObject.GetComponent<Image>().color.b == 1 & hit_check == false)
        {
            hit_check = true;
            timer_check();
        }

        else if (hit_check == false)
        {
            hit_check = true;
            gameObject.GetComponent<Animation>().Play("note_fade_out_miss_animation");
        }
    }

    void FixedUpdate()
    {
        if (stopwatch.ElapsedMilliseconds > 2600)
        {
            Destroy(gameObject);
        }
    }

    void timer_check()
    {
        if (0 <= stopwatch.ElapsedMilliseconds & stopwatch.ElapsedMilliseconds < 1900)
        {
            gameObject.GetComponent<Animation>().Play("note_fade_out_miss_animation");
        }

        if (1900 <= stopwatch.ElapsedMilliseconds & stopwatch.ElapsedMilliseconds < 1950)
        {
            game_main.score += 1;
            gameObject.GetComponent<Animation>().Play("note_fade_out_good_animation");
        }

        if (1950 <= stopwatch.ElapsedMilliseconds & stopwatch.ElapsedMilliseconds < 2050)
        {
            game_main.score += 2;
            gameObject.GetComponent<Animation>().Play("note_fade_out_perfect_animation");
        }

        if (2050 <= stopwatch.ElapsedMilliseconds & stopwatch.ElapsedMilliseconds < 2100)
        {
            game_main.score += 1;
            gameObject.GetComponent<Animation>().Play("note_fade_out_good_animation");
        }

        if (2100 <= stopwatch.ElapsedMilliseconds)
        {
            //already animating on default animation file
            //gameObject.GetComponent<Animation>().Play("note_fade_out_miss_animation");
        }
    }
}