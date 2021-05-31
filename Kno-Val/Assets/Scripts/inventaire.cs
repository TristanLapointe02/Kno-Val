using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inventaire : MonoBehaviour
{
    bool inventaireOuvert = false;
    public float longueurAmasser;

    public Camera cameraJoueur;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.E) && inventaireOuvert == false)
        {
            OuvreInventaire();

        }
        else if (Input.GetKeyDown(KeyCode.E) && inventaireOuvert == true)
        {
            fermeInventaire();
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            AmasserObjet();
        }
    }

    void OuvreInventaire()
    {
        inventaireOuvert = true;

        print("inventaire Ouvert");

    }

    void fermeInventaire()
    {
        inventaireOuvert = false;
        print("inventaire ferm�");
    }

    void AmasserObjet()
    {
        RaycastHit amasser;
        if (Physics.Raycast(cameraJoueur.transform.position, cameraJoueur.transform.forward, out amasser, longueurAmasser))
        {
            Debug.Log(amasser.transform.name);
        }
    }
}
