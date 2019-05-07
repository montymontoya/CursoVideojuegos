using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveChar : MonoBehaviour {

    //variables movimiento general
    public Transform myBodyPlayer;
    public float walkSpeed = 1;
    public float runSpeed = 2;

    //variables mirar
    
    public Transform myBodyHead;
    public float xSpeed = 1;
    public float ySpeed = 1;
    public float yaw, pitch;

    //variables saltar
    public Rigidbody body;
    public float jumpForce = 1000;

    private bool agachado;
	// Use this for initialization
	void Start () {
        Cursor.visible = false; // esconder cursor de mouse
        Cursor.lockState = CursorLockMode.Confined;
        if (myBodyPlayer == null)
            myBodyPlayer = this.transform;
        if (myBodyHead == null)
            myBodyHead = Camera.main.transform;

        body = myBodyPlayer.GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        Mira();
        Avanzar();
        Saltar();
        Agacharse();
    }

    void Mira()
    {
        yaw += xSpeed * Input.GetAxis("Mouse X");
        pitch -= xSpeed * Input.GetAxis("Mouse Y");
        myBodyHead.transform.localEulerAngles = new Vector3(pitch, 0.0f, 0.0f);
        myBodyPlayer.transform.localEulerAngles = new Vector3(0.0f, yaw, 0.0f);
    }
    void Agacharse()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            agachado = !agachado;
        }
        if (agachado)
        {
            myBodyHead.localPosition = Vector3.MoveTowards(myBodyHead.localPosition, new Vector3(0, -0.13f, 0), Time.deltaTime * 3);
        }
        else
        {
            myBodyHead.localPosition = Vector3.MoveTowards(myBodyHead.localPosition, new Vector3(0, 0.8f, 0), Time.deltaTime * 3);
        }
    }

    void Saltar()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            body.AddForce(0, jumpForce, 0);
        }
    }
    void Avanzar()
    {
        if (Input.GetKey(KeyCode.W))
        {
            if (Input.GetKey(KeyCode.LeftShift)) //correr
                myBodyPlayer.localPosition += myBodyPlayer.forward * Time.deltaTime * runSpeed;
            else //caminar
                myBodyPlayer.localPosition += myBodyPlayer.forward * Time.deltaTime * walkSpeed;
        }
        if (Input.GetKey(KeyCode.S))
        {
            myBodyPlayer.localPosition -= myBodyPlayer.forward * Time.deltaTime * walkSpeed;
        }
        if (Input.GetKey(KeyCode.D))
        {
            myBodyPlayer.localPosition += myBodyPlayer.right * Time.deltaTime * walkSpeed;
        }
        if (Input.GetKey(KeyCode.A))
        {
            myBodyPlayer.localPosition -= myBodyPlayer.right * Time.deltaTime * walkSpeed;
        }
    }


}
