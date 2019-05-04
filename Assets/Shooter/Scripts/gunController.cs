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
    public Transform laserGun; // Transform del objeto de donde saldrá el laser
    public LineRenderer laserLine; // Laser
    public bool laserOn;

    // variables para disparar
    public GameObject bala;
    public Transform balaPos;
    public Camera myCam;
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
        if (Input.GetMouseButtonDown(1))
            aiming = true;
        if (Input.GetMouseButtonUp(1))
            aiming = false;
        /*
         * 
         */
        if (Input.GetMouseButtonDown(0))
        {
            Disparar();
//Fire Anim
        }
            
        if (Input.GetMouseButtonUp(0))
        {
//Stop Fire Anim
        }
            
        /*
         * 
         */
        if (aiming)
        {
            Apuntar();
        }
            
        else
            ResetPos();

        if (Input.GetKeyDown(KeyCode.L))
            laserOn = !laserOn;

        ApuntarLaser(laserOn);

    }

    void ApuntarLaser(bool status)
    {
        RaycastHit hit;
        if (Physics.Raycast(myCam.transform.position, myCam.transform.forward, out hit, Mathf.Infinity))
        {
            laserLine.SetPosition(0, laserGun.position);
            laserLine.SetPosition(1, hit.point);
        }
        else
        {
            laserLine.SetPosition(0, laserGun.position);
            laserLine.SetPosition(1, myCam.transform.forward*1000);
        }

        if (status)
            laserLine.gameObject.SetActive(true);
        else
            laserLine.gameObject.SetActive(false);

    }
    
    /* SECCION DE DISPARAR */
    void Disparar()
    {
        GameObject neuBala = Instantiate<GameObject>(bala);
        neuBala.transform.parent = balaPos;
        neuBala.transform.localPosition = Vector3.zero;
        neuBala.transform.localEulerAngles = Vector3.zero;
        neuBala.transform.parent = null;
        neuBala.GetComponent<Rigidbody>().AddRelativeForce(0,1000,0);

        

        RaycastHit hit;
        if (Physics.Raycast(myCam.transform.position, myCam.transform.forward, out hit, Mathf.Infinity))
        {
            Debug.DrawRay(gun.position, gun.forward * hit.distance, Color.yellow);

        }
    }
    /********************/

    /* SECCION DE APUNTAR */
    void Apuntar()
    {
        gun.localPosition = Vector3.MoveTowards(gun.localPosition, posAim.localPosition, moveSpeed * Time.deltaTime);
        var rotation = Quaternion.LookRotation(Vector3.zero, gun.localPosition);
        gun.localRotation = Quaternion.Slerp(gun.localRotation, rotation, rotSpeed * Time.deltaTime);
    }
    void ResetPos()
    {
        gun.localPosition = Vector3.MoveTowards(gun.localPosition, originalPos, moveSpeed * Time.deltaTime);

        gun.localRotation = Quaternion.Slerp(gun.localRotation, originalRot, rotSpeed * Time.deltaTime);
    }
    /*********************/
}
