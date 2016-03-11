/*
(c) Copyright Simon Boyer and Antoine Brassard Lahey 2016

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
using System.Collections;
using UnityEngine;
//using UnityStandardAssets.CrossPlatformInput;


    [RequireComponent(typeof(PlatformerCharacter2D))]
    public class Platformer2DUserControl : MonoBehaviour
    {
        private PlatformerCharacter2D m_Character;
        private bool m_Jump;
        private float gravityStore;
        private Rigidbody2D m_Rigidbody2D;
        private bool gravite = false;
    private Animator m_Anim;

        public bool onLadder = false;
        public bool monte = false; 
        public float climbSpeed = 1f;


        private void Awake()
        {
            m_Rigidbody2D = GetComponent<Rigidbody2D>();
            m_Character = GetComponent<PlatformerCharacter2D>();
            gravityStore = m_Rigidbody2D.gravityScale;
            m_Anim = GetComponent<Animator>();
    }


        private void Update()
        {
            if (!m_Jump)
            {
                // Read the jump input in Update so button presses aren't missed.
                m_Jump = Input.GetButtonDown("Jump");
            }
            // Read the inputs.
            bool crouch = Input.GetKey(KeyCode.LeftControl);
            float h = Input.GetAxis("Horizontal");

        m_Anim.SetBool("OnLadder", onLadder);  //Ecrire la valeure de OnLadder pour l<animator


        if (onLadder)
            {
                if (Input.GetKeyDown(KeyCode.W))
                {
                    m_Rigidbody2D.gravityScale = -1f * climbSpeed;
                    m_Character.Move(0f, false, false);
                GetComponent<BoxCollider2D>().isTrigger = true;
                GetComponent<CircleCollider2D>().isTrigger = true;
                monte = true;
                m_Anim.SetBool("monte", monte);

            }

                else {
                    if (!monte)
                    {

                                m_Rigidbody2D.gravityScale = gravityStore;
                                m_Character.Move(h, crouch, m_Jump);
                                m_Jump = false;
                    GetComponent<BoxCollider2D>().isTrigger = false;
                    GetComponent<CircleCollider2D>().isTrigger = false;
                    gravite = false;

                    }
                    else
                    m_Rigidbody2D.gravityScale = -1f * climbSpeed;
                } 

            }

            else {
                
                    // Pass all parameters to the character control script.
                    //m_Character.Move(h, crouch, m_Jump);
                    m_Rigidbody2D.gravityScale = gravityStore;
                    m_Character.Move(h, crouch, m_Jump);
                    m_Jump = false;
            GetComponent<BoxCollider2D>().isTrigger = false;
            GetComponent<CircleCollider2D>().isTrigger = false;

        }

    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "sol")
        {
            GetComponent<BoxCollider2D>().isTrigger = false;
            monte = false;
            m_Anim.SetBool("monte", monte);
        }
    }

    }
