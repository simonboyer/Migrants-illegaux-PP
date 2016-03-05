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
