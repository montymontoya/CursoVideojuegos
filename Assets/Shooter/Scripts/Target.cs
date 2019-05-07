using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public string balaTag;
    public float initAng,hitAng;
    public float hitSpeed;
    public bool hited;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Update()
    {
        if (hited)
        {
            transform.parent.eulerAngles += new Vector3(0, 0, hitSpeed * Time.deltaTime);
            if (transform.parent.eulerAngles.z>=hitAng)
            {
                hited = false;
            }
        }  
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag==balaTag)
        {
            hited = true;
        }
    }
}
