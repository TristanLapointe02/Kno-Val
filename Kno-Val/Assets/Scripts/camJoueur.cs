using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camJoueur : MonoBehaviour
{
    public Transform joueur;
    public float sensitivite;
    private float rotationX = 0f;
    //private float rotationY = 0f;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {

        float mouseX = Input.GetAxis("Mouse X") * sensitivite * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivite * Time.deltaTime;

        rotationX -= mouseY;
        rotationX = Mathf.Clamp(rotationX, -90, 90f);

        //Rotation
        transform.localRotation = Quaternion.Euler(rotationX, 0f, 0f);
        joueur.Rotate(Vector3.up * mouseX);
    }
}
