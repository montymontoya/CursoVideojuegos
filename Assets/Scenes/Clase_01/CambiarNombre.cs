using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CambiarNombre : MonoBehaviour
{
    public string nombre;
    // Start is called before the first frame update
    void Start()
    {
        nombre = this.name;
    }

    // Update is called once per frame
    void Update()
    {
        this.name = nombre;
    }
}
