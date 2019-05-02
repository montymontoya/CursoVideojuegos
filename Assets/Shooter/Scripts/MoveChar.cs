using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveChar : MonoBehaviour {
    public Transform myBodyHead;
    public Transform myBodyPlayer;
    public float xSpeed = 1;
    public float ySpeed = 1;
    public float yaw, pitch;
    public float walkSpeed=1;
    public float runSpeed = 2;
	// Use this for initialization
	void Start () {
        Cursor.visible = false;
        if (myBodyPlayer == null)
            myBodyPlayer = this.transform;
        if (myBodyHead == null)
            myBodyHead = Camera.main.transform;
	}
	
	// Update is called once per frame
	void FixedUpdate () {

        Mira();

        Avanzar();

    }

    void Mira()
    {
        yaw += xSpeed * Input.GetAxis("Mouse X");
        pitch -= xSpeed * Input.GetAxis("Mouse Y");
        myBodyHead.transform.localEulerAngles = new Vector3(pitch, 0.0f, 0.0f);
        myBodyPlayer.transform.localEulerAngles = new Vector3(0.0f, yaw, 0.0f);
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
