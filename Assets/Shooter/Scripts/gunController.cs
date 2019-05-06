using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gunController : MonoBehaviour
{
    //variables apuntar
    public Transform gun; // Transform del arma que utilizamos
    public Transform posAim; // Transform de la posición que debe tener el arma al apuntar
    public float moveSpeed = 1; // velocidad del movimiento del arma al apuntar
    public float rotSpeed = 10; // velocidad de la rotación del arma al apuntar
    public bool aiming; // bandera para determinar si estamos apuntando o no
    private Vector3 originalPos; // posición original del arma cuando no apunta
    private Quaternion originalRot; // rotación original del arma cuando no apunta

    // variables apuntar laser
    public Transform laserOrigin; // Transform del objeto de donde saldrá el laser
    public LineRenderer laserLine; // Laser
    public bool laserOn;

    // variables para disparar
    public GameObject bala;
    public Transform balaPos;
    public Camera myCam;
    public float fireForce=200;
    public float fireRate = 1;
    
    
    

    // Start is called before the first frame update
    void Start()
    {
        myCam = Camera.main;
        originalPos = gun.transform.localPosition;
        originalRot = gun.transform.localRotation;
    }

    // Update is called once per frame
    void Update()
    {
       Apuntar();
       Disparar();
       //ApuntarLaser();

    }

    void ApuntarLaser()
    {
        if (Input.GetMouseButtonDown(0))
            laserOn = !laserOn;

        RaycastHit hit;
        if (Physics.Raycast(myCam.transform.position, myCam.transform.forward, out hit, Mathf.Infinity))
        {
            Vector3 point = laserOrigin.InverseTransformPoint(hit.point);
            //laserLine.SetPosition(0, laserOrigin.localPosition);
            laserLine.SetPosition(1, point);
        }
        else
        {
            Vector3 point = laserOrigin.InverseTransformPoint(myCam.transform.forward * 10000);
            //laserLine.SetPosition(0, laserOrigin.position);
            laserLine.SetPosition(1, point);
        }

        if (laserOn)
            laserLine.gameObject.SetActive(true);
        else
            laserLine.gameObject.SetActive(false);

    }
    
    /* SECCION DE DISPARAR */
    void Disparar()
    {
        if (Input.GetMouseButtonDown(0))
        {


            GameObject neuBala = Instantiate<GameObject>(bala);
            neuBala.transform.parent = balaPos;
            neuBala.transform.localPosition = Vector3.zero;
            neuBala.transform.localEulerAngles = Vector3.zero;
            neuBala.transform.parent = null;
          
            

            RaycastHit hit;
            if (Physics.Raycast(myCam.transform.position, myCam.transform.forward, out hit, Mathf.Infinity))
            {
                //Debug.DrawRay(gun.position, gun.forward * hit.distance, Color.yellow);
                neuBala.GetComponent<Rigidbody>().AddForce((hit.point-neuBala.transform.position) * fireForce);
            }
            else
            {
                neuBala.GetComponent<Rigidbody>().AddForce((neuBala.transform.up) * fireForce);
            }
        }
    }
    /********************/

    /* SECCION DE APUNTAR */
    void Apuntar()
    {
        if (Input.GetMouseButton(1))
        {
            gun.localPosition = Vector3.MoveTowards(gun.localPosition, posAim.localPosition, moveSpeed * Time.deltaTime);
            var rotation = Quaternion.LookRotation(Vector3.zero, gun.localPosition);
            gun.localRotation = Quaternion.Slerp(gun.localRotation, rotation, rotSpeed * Time.deltaTime);
        }
        if (Input.GetMouseButtonUp(1))
            aiming = true;

        if (aiming)
        {
            gun.localPosition = Vector3.MoveTowards(gun.localPosition, originalPos, moveSpeed * Time.deltaTime);
            gun.localRotation = Quaternion.Slerp(gun.localRotation, originalRot, rotSpeed * Time.deltaTime);

            if (gun.localPosition == originalPos && gun.localRotation == originalRot)
                aiming = false;
        }        
        else
        {
            
        }

    }
    /*********************/
}
