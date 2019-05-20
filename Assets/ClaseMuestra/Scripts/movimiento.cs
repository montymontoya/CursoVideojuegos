using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movimiento : MonoBehaviour
{
    public float fuerza;
    private Rigidbody kirby;
    // Start is called before the first frame update
    void Start()
    {
        kirby = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            kirby.AddForce(0, fuerza, 0);
        }
    }
}
