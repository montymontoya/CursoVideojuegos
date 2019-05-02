using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gunController : MonoBehaviour
{
    public Transform gun;
    public Transform posAim;
    private Vector3 originalPos;
    private Quaternion originalRot;
    public float moveSpeed = 1;
    public float rotSpeed = 10;
    public bool aiming;
    // Start is called before the first frame update
    void Start()
    {
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
            Apuntar();
        else
            ResetPos();


    }


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
}
