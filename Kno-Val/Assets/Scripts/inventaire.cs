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
        print("inventaire fermé");
    }

    void AmasserObjet()
    {
        RaycastHit amasser;
        if (Physics.Raycast(cameraJoueur.transform.position, cameraJoueur.transform.forward, out amasser, longueurAmasser))
            //En Appuyant sur F, un laser part tout droit de la caméra à une longueur précise et détruit l'objet en contact
        {
            if(amasser.collider.tag == "amassable")
            {
                Destroy(amasser.transform.gameObject);
            }
            Debug.Log(amasser.transform.name);
        }
    }
}
