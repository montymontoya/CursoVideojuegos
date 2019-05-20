using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clase_1_extra_Semaforo : MonoBehaviour
{
    public GameObject focoVerde;
    public GameObject focoAmbar;
    public GameObject focoRojo;

    public MeshRenderer meshVerde;
    public MeshRenderer meshAmbar;
    public MeshRenderer meshRojo;

    public Material matVerde;
    public Material matAmbar;
    public Material matRojo;

    public Color colorVerde;
    public Color colorAmbar;
    public Color colorRojo;

    public float tSemaforo;
    public float tVerde = 3;
    public float tAmbar = 1;
    public float tRojo = 2;

    public bool bVerde = true;
    public bool bAmbar;
    public bool bRojo;
    // Start is called before the first frame update
    void Start()
    {
        meshVerde = focoVerde.GetComponent<MeshRenderer>();
        matVerde = meshVerde.material;

        meshAmbar = focoAmbar.GetComponent<MeshRenderer>();
        matAmbar = meshAmbar.material;

        meshRojo = focoRojo.GetComponent<MeshRenderer>();
        matRojo = meshRojo.material;
    }

    // Update is called once per frame
    void Update()
    {
        if (bVerde==true)
        {
            colorVerde = new Color(0, 1, 0);
            matVerde.color = colorVerde;
            tSemaforo += Time.deltaTime;
            if (tSemaforo>=tVerde)
            {
                bVerde = false;
                bAmbar = true;
                tSemaforo = 0;
                colorVerde = new Color(0, 0, 0);
                matVerde.color = colorVerde;
            }
        }

        if (bAmbar == true)
        {
            colorAmbar = new Color(1, 1, 0);
            matAmbar.color = colorAmbar;
            tSemaforo += Time.deltaTime;
            if (tSemaforo >= tAmbar)
            {
                bAmbar = false;
                bRojo = true;
                tSemaforo = 0;
                colorAmbar = new Color(0, 0, 0);
                matAmbar.color = colorAmbar;
            }
        }
        if (bRojo == true)
        {
            colorRojo = new Color(1, 0, 0);
            matRojo.color = colorRojo;
            tSemaforo += Time.deltaTime;
            if (tSemaforo >= tRojo)
            {
                bRojo = false;
                bVerde = true;
                tSemaforo = 0;
                colorRojo = new Color(0, 0, 0);
                matRojo.color = colorRojo;
            }
        }



    }
}
