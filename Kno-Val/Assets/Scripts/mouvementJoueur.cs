using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouvementJoueur : MonoBehaviour
{
    private Rigidbody rb;
    public float vitesse = 6;
    public float forceSaut = 12;
    public LayerMask masqueJoueur;
    public bool isGrounded;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //Input
        float x = Input.GetAxisRaw("Horizontal") * vitesse;
        float y = Input.GetAxisRaw("Vertical") * vitesse;

        //Saut
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.velocity = new Vector3(rb.velocity.x, forceSaut, rb.velocity.y);
        }
        //Saut avec isGrounded
        isGrounded = Physics.CheckSphere(new Vector3(transform.position.x, transform.position.y - 1, transform.position.z), 0.4f, masqueJoueur);

        //Mouvement
        Vector3 position = transform.right * x + transform.forward * y;
        Vector3 nouvellePosition = new Vector3(position.x, rb.velocity.y, position.z);


        rb.velocity = nouvellePosition;
    }
}
