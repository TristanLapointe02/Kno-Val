using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deplacementPerso : MonoBehaviour
{
    public CharacterController controlleur;
    public float vitesse = 12f;
    Vector3 velocite;
    public float gravite = -18f;

    public Transform solCheck;
    public float solDistance = 0.5f;
    public LayerMask masqueSol;
    bool surSol;
    public float forceSaut = 3f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Sphere qui regarde si le personnage est sur le masque Sol
        surSol = Physics.CheckSphere(solCheck.position, solDistance, masqueSol);

        // Si il est sur le sol, il perd de la vélocité
        if(surSol && velocite.y < 0)
        {
            velocite.y = -2f;
        }

        print(surSol);

        //Saut
        if(Input.GetButtonDown("Jump") && surSol)
        {
            velocite.y = Mathf.Sqrt(forceSaut * -2f * gravite);
        }
        //Inputs
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        //Mouvement
        Vector3 mouvement = transform.right * x + transform.forward * z;
        controlleur.Move(mouvement * vitesse * Time.deltaTime);

        //Faire tomber le personnage avec la gravité
        velocite.y += gravite * Time.deltaTime;
        controlleur.Move(velocite * Time.deltaTime);
    }
}
