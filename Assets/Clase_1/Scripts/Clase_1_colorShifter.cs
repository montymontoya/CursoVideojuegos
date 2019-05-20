using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clase_1_colorShifter : MonoBehaviour
{
    public MeshRenderer miMesh;
    public Material miMaterial;
    public Color miColor;
    public float miTiempo;
    // Start is called before the first frame update
    void Start()
    {
        miMesh = this.GetComponent<MeshRenderer>();
        miMaterial = miMesh.material;
    }
    // Update is called once per frame
    void Update()
    {
        miTiempo += Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.T))//Incrementar en Rojo
        {
            miColor += new Color(0.04f, 0, 0);
        }
        if (Input.GetKeyDown(KeyCode.Y))//Incrementar en Rojo
        {
            miColor -= new Color(0.04f, 0, 0);
        }
        miMaterial.color = miColor;
    }
}
