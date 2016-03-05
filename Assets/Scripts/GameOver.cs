/*
Copyright

This file is part of Migrants-illegaux-PP.

    Migrants-illegaux-PP is free software: you can redistribute it and/or modify
    it under the terms of the GNU Lesser General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    Migrants-illegaux-PP is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU Lesser General Public License for more details.

    You should have received a copy of the GNU Lesser General Public License
    along with Migrants-illegaux-PP.  If not, see <http://www.gnu.org/licenses/>. 
    */
using UnityEngine;
using System.Collections;

public class GameOver : MonoBehaviour
{

    private bool paused = false;
    private float t = 0.0f;

    public float restartDelay = 1f;

    public bool Alarm = false;
    public bool lastScene = false;
    Animator anim;
    float restartTimer;
    // Use this for initialization
    void Awake()
    {
        anim = GetComponent<Animator>();
        if (lastScene) Time.timeScale = 0f;
        else Time.timeScale = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        //Alarm = GameObject.Find("SecurityCamera").GetComponent<videosurveillance>().alarm;
        if (Alarm)
        {
            anim.SetTrigger("GameOverTrigger");
            restartTimer += Time.deltaTime;
            if (restartTimer > restartDelay)
            {
                GameObject.Find("SecurityCamera").GetComponent<videosurveillance>().fini = true;
                Time.timeScale = 0f;
            }

        }

        if (paused)
        {
            if (t >= 1f)
            {
                Time.timeScale = 0.0f;
                t = 0f;
            }
            t += Time.deltaTime;
        }

    }

    public void retry()
    {
        Application.LoadLevel(Application.loadedLevel);
    }

    public void menu()
    {
        Application.LoadLevel(1);
    }

    public void pause()
    {
        if (!paused)
        {
            paused = true;
            anim.SetBool("Pause", true);
        }
        else
        {
            Time.timeScale = 1.0f;
            paused = false;
            anim.SetBool("Pause", false);
        }
    }

    public void reprendre()
    {
        Time.timeScale = 1.0f;
        paused = false;
        anim.SetBool("Pause", false);
    }

    public void quitter()
    {
        Application.Quit();
    }

    public void compris()
    {
        if (lastScene)
        {
            Time.timeScale = 1.0f;
            //anim.SetBool("Pause", false);
            GameObject intro = GameObject.Find("Intro");
            GameObject introButton = GameObject.Find("IntroButton");
            Destroy(introButton);
            Destroy(intro);
        }

    }
}
