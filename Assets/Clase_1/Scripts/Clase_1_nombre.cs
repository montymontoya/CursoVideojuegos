using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clase_1_nombre : MonoBehaviour
{
    public string miNombre;
    public Transform transformacion;
    public float x;
    public float y;
    public float z;

    // Start is called before the first frame update
    void Start()
    {
        miNombre = this.name;
        transformacion = this.transform;
    }

    // Update is called once per frame
    void Update()
    {
        this.name = miNombre;
        transformacion.position = new Vector3(x, y, z);
    }
}
