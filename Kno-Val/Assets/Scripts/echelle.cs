using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class echelle : MonoBehaviour
{
    public Transform controlleur;
    bool interieurEchelle;
    public float hauteurEchelle = 1.3f;
    public deplacementPerso joueur; 
    // Start is called before the first frame update
    void Start()
    {
        joueur = GetComponent<deplacementPerso>();
        interieurEchelle = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (interieurEchelle && Input.GetKey("w"))
        {
            controlleur.transform.position += Vector3.up / hauteurEchelle;
        }

        if (interieurEchelle && Input.GetKey("s"))
        {
            controlleur.transform.position += Vector3.down / hauteurEchelle;
        }
    }

    private void OnTriggerEnter(Collider infoCollision)
    {
        if(infoCollision.gameObject.tag == "Echelle")
        {
            joueur.enabled = false;
            interieurEchelle = !interieurEchelle;
        }
    }

    private void OnTriggerExit(Collider infoCollision)
    {
        if (infoCollision.gameObject.tag == "Echelle")
        {
            joueur.enabled = true;
            interieurEchelle = !interieurEchelle;
        }
    }
}
