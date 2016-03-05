using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class Aleatoire : MonoBehaviour {

    System.Random rnd = new System.Random();
    public int Difficulte = 5;
    public float delais = 1f;
    public OpenDoor element;

    private int[] fleches;
    private int n = 0;
    private float t = 0f;
    private SpriteRenderer FlecheHaut;
    private SpriteRenderer FlecheBas;
    private SpriteRenderer FlecheGauche;
    private SpriteRenderer FlecheDroite;
    private SpriteRenderer neutre;
    private bool deja = false;
    private bool quatre = false;
    private AudioSource source;
    private bool fini = false;
    private int p;
    private List<int> playerInput = new List<int>();
    private int concordance = 0;



    // Use this for initialization
    void Start () {

        neutre = GetComponent<SpriteRenderer>();
        FlecheHaut = GameObject.Find("FlecheHaut").GetComponent<SpriteRenderer>();
        FlecheBas = GameObject.Find("FlecheBas").GetComponent<SpriteRenderer>();
        FlecheGauche = GameObject.Find("FlecheGauche").GetComponent<SpriteRenderer>();
        FlecheDroite = GameObject.Find("FlecheDroite").GetComponent<SpriteRenderer>();
        fleches = new int[Difficulte];
        source = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {

        if (fini)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow) && p < Difficulte)
            {
                playerInput.Add(0);
                p++;
            }

            if (Input.GetKeyDown(KeyCode.DownArrow) && p < Difficulte)
            {
                playerInput.Add(1);
                p++;
            }

            if (Input.GetKeyDown(KeyCode.LeftArrow) && p < Difficulte)
            {
                playerInput.Add(2);
                p++;
            }

            if (Input.GetKeyDown(KeyCode.RightArrow) && p < Difficulte)
            {
                playerInput.Add(3);
                p++;
            }

            // Debug.Log(playerInput[0]);
            if (playerInput.Count == (Difficulte))
            {
                for (int i = 0; i < Difficulte; i++)
                {
                    if (playerInput[i] == fleches[i]) concordance++;
                    //if(i == ( Difficulte - 1)) fini = false;

                }
                if (concordance == Difficulte) element.active = true;
                else {
                    playerInput.Clear();
                    concordance = 0;
                }

            }
        }

    }

    private void OnTriggerStay2D(Collider2D other)
    {
        //Debug.Log(Input.inputString);
        if (other.name == "Player")
        {
            if (Input.GetKey(KeyCode.F) || quatre)
            {
                concordance = 0;
                p = 0;
                fini = false;
                quatre = true;
                deja = true;
                playerInput.Clear();
                for (int i = 0; i < Difficulte; i++)
                {

                    fleches[i] = rnd.Next(4);
                    Debug.Log(fleches[i]);
                    if (i == (Difficulte - 1)) quatre = false;
                }
            }

            if (deja && n < Difficulte)
            {
                switch (fleches[n])
                {
                    case 0:
                        FlecheHaut.GetType().GetProperty("enabled").SetValue(FlecheHaut, true, null);
                        FlecheBas.GetType().GetProperty("enabled").SetValue(FlecheBas, false, null);
                        FlecheGauche.GetType().GetProperty("enabled").SetValue(FlecheGauche, false, null);
                        FlecheDroite.GetType().GetProperty("enabled").SetValue(FlecheDroite, false, null);
                       // neutre.GetType().GetProperty("enabled").SetValue(neutre, false, null);
                        t += Time.deltaTime;
                        if (t >= delais)
                        {
                            n++;
                            t = 0f;
                            source.Play();
                        }
                        break;
                    case 1:
                        FlecheBas.GetType().GetProperty("enabled").SetValue(FlecheBas, true, null);
                        FlecheHaut.GetType().GetProperty("enabled").SetValue(FlecheHaut, false, null);
                        FlecheGauche.GetType().GetProperty("enabled").SetValue(FlecheGauche, false, null);
                        FlecheDroite.GetType().GetProperty("enabled").SetValue(FlecheDroite, false, null);
                        //neutre.GetType().GetProperty("enabled").SetValue(neutre, false, null);
                        t += Time.deltaTime;
                        if (t >= delais)
                        {
                            n++;
                            t = 0f;
                            source.Play();
                        }
                        break;
                    case 2:
                        FlecheGauche.GetType().GetProperty("enabled").SetValue(FlecheGauche, true, null);
                        FlecheBas.GetType().GetProperty("enabled").SetValue(FlecheBas, false, null);
                        FlecheHaut.GetType().GetProperty("enabled").SetValue(FlecheHaut, false, null);
                        FlecheDroite.GetType().GetProperty("enabled").SetValue(FlecheDroite, false, null);
                       // neutre.GetType().GetProperty("enabled").SetValue(neutre, false, null);
                        t += Time.deltaTime;
                        if (t >= delais)
                        {
                            n++;
                            t = 0f;
                            source.Play();
                        }
                        break;
                    case 3:
                        FlecheDroite.GetType().GetProperty("enabled").SetValue(FlecheDroite, true, null);
                        FlecheGauche.GetType().GetProperty("enabled").SetValue(FlecheGauche, false, null);
                        FlecheBas.GetType().GetProperty("enabled").SetValue(FlecheBas, false, null);
                        FlecheHaut.GetType().GetProperty("enabled").SetValue(FlecheHaut, false, null);
                        //neutre.GetType().GetProperty("enabled").SetValue(neutre, false, null);
                        t += Time.deltaTime;
                        if (t >= delais)
                        {
                            n++;
                            t = 0f;
                            source.Play();
                        }
                        break;
                }
            }

            if(n == Difficulte)
            {
                t += Time.deltaTime;
                if (t >= delais)
                {
                    deja = false;
                    fini = true;
                    n = 0;
                    FlecheDroite.GetType().GetProperty("enabled").SetValue(FlecheDroite, false, null);
                    FlecheGauche.GetType().GetProperty("enabled").SetValue(FlecheGauche, false, null);
                    FlecheBas.GetType().GetProperty("enabled").SetValue(FlecheBas, false, null);
                    FlecheHaut.GetType().GetProperty("enabled").SetValue(FlecheHaut, false, null);
                    //neutre.GetType().GetProperty("enabled").SetValue(neutre, true, null);
                    t = 0;
                }
            }
        }

        
    }
}
