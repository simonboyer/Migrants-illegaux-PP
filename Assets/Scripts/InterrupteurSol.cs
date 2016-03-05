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

public class InterrupteurSol : MonoBehaviour
{

    public OpenDoor2 element;
    public bool actif;
    public bool deuxieme;
    private Animator anim;
    private string nom;
    private SpriteRenderer lumiereV1;
    private SpriteRenderer lumiereV2;
    private SpriteRenderer lumiereR1;
    private SpriteRenderer lumiereR2;
    // Use this for initialization
    void Start()
    {
        actif = element.active1;
        anim = GetComponent<Animator>();
        nom = "";
        lumiereV1 = GameObject.Find("LumieresPorte_0").GetComponent<SpriteRenderer>();
        lumiereV2 = GameObject.Find("LumieresPorte_01").GetComponent<SpriteRenderer>();
        lumiereR1 = GameObject.Find("LumieresPorte_1").GetComponent<SpriteRenderer>();
        lumiereR2 = GameObject.Find("LumieresPorte_11").GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.name == "Player" || other.name == "Bloc")
        {

            actif = true;
            if (deuxieme)
            {
                element.active2 = actif;
                lumiereV2.GetType().GetProperty("enabled").SetValue(lumiereV2, true, null);
                lumiereR2.GetType().GetProperty("enabled").SetValue(lumiereR2, false, null);
            }
            else
            {
                element.active1 = actif;
                lumiereV1.GetType().GetProperty("enabled").SetValue(lumiereV1, true, null);
                lumiereR1.GetType().GetProperty("enabled").SetValue(lumiereR1, false, null);
            }
            anim.SetBool("Actif", true);
            nom = other.name;
        }


    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (nom == "Player" || nom == "Bloc")
        {

            actif = false;
            if (deuxieme)
            {
                lumiereV2.GetType().GetProperty("enabled").SetValue(lumiereV2, false, null);
                lumiereR2.GetType().GetProperty("enabled").SetValue(lumiereR2, true, null);
                element.active2 = actif;
            }
            else
            {
                element.active1 = actif;
                lumiereV1.GetType().GetProperty("enabled").SetValue(lumiereV1, false, null);
                lumiereR2.GetType().GetProperty("enabled").SetValue(lumiereR1, true, null);
            }
            anim.SetBool("Actif", false);
        }
    }
}
