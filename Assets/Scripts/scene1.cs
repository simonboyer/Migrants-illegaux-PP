using UnityEngine;
using System.Collections;

public class scene1 : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {


    }

    public void nextLevel()
    {
        Application.LoadLevel(Application.loadedLevel + 1);
    }

    public void dons()
    {
        Application.OpenURL("http://coalitionhumanitaire.ca/nos-campagnes/crise-des-refugies-syriens");
    }

    public void quitter()
    {
        Application.Quit();
    }

    public void credits()
    {
        Application.LoadLevel(8);
    }
}
