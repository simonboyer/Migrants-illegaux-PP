
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
    */using UnityEngine;
using System.Collections;

public class videosurveillance : MonoBehaviour {

    private GameObject player;
    private CircleCollider2D col;
    private float nextAlarm = 0.0f;
    private AudioSource source;

    public float angleDeVue = 110f;
    public bool alarm = false;
    public AudioClip intruder;
    public float angle;
    public bool fini = false;


    private void Awake()
    {
        player = GameObject.FindWithTag("Player");
        col = GetComponent<CircleCollider2D>();
        source = GetComponent<AudioSource>();
    }

    private void OnTriggerStay2D(Collider2D other) //pour toutes les frames ou un objet est dans le collider triggered
    {
        if (other.name == "Player")
        {
            //playerVisible = false;

            Vector2 direction = other.transform.position - transform.position;
            angle = Vector2.Angle(direction, transform.right);

            if (angle < (angleDeVue * 0.5f))
            {

                RaycastHit2D hit = Physics2D.Raycast(transform.position, direction.normalized); //Créer le raycast
                                                                                                //RaycastHit2D hit = Physics2D.Linecast (transform.position + transform.up, player.transform.position);


                if (hit.collider.name == "Player")
                { //verifier si le raycast a frappe le joueur
                    if (GetComponent<SwitchCamera>().active)
                    {
                        alarm = true;
                        GameObject.Find("Canvas").GetComponent<GameOver>().Alarm = true;
                    }
                }
            }
        }

        //else playerVisible = false;
    }

    // Update is called once per frame
    void Update () {
        Component halo = GetComponent("Halo");

        if (alarm && Time.time > (nextAlarm - 0.5) && !fini)
            {
            source.Play();
            if (alarm && Time.time > nextAlarm)
            {
                nextAlarm = Time.time + 1.0f;
                halo.GetType().GetProperty("enabled").SetValue(halo, true, null);
            }
            else {
                halo.GetType().GetProperty("enabled").SetValue(halo, false, null);
                source.Stop();
            }
            
        }
       // else source.Stop();




    }
}
