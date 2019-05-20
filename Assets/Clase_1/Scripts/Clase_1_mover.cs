using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clase_1_mover : MonoBehaviour
{
    public Transform miTransform;
    // Start is called before the first frame update
    void Start()
    {
        miTransform = this.transform; 
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow)) // ARRIBA
        {
            miTransform.position += new Vector3(0, Time.deltaTime, 0); 
        }
        if (Input.GetKey(KeyCode.DownArrow)) // ABAJO
        {
            miTransform.position -= new Vector3(0, Time.deltaTime, 0);
        }
        if (Input.GetKey(KeyCode.RightArrow)) // ARRIBA
        {
            miTransform.position += new Vector3(Time.deltaTime, 0, 0);
        }
        if (Input.GetKey(KeyCode.LeftArrow)) // ABAJO
        {
            miTransform.position -= new Vector3(Time.deltaTime, 0, 0);
        }
        if (Input.GetKey(KeyCode.Q)) // FRENTE
        {
            miTransform.position += new Vector3(0, 0, Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.E)) // FRENTE
        {
            miTransform.position -= new Vector3(0, 0, Time.deltaTime);
        }
    }
}
