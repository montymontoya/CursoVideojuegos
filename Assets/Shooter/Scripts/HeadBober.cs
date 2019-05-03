using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadBober : MonoBehaviour
{

    private float timer = 0.0f;
    public float bobbingSpeed = 0.18f;
    public float bobbingAmount = 0.05f;
    public float midpoint = 0.0f;
    public string eje = "y";
    private float oBob;

    private void Start()
    {
        oBob = bobbingSpeed;   
    }

    void Update()
    {
        float waveslice = 0.0f;
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 cSharpConversion = transform.localPosition;

        if (Mathf.Abs(horizontal) == 0 && Mathf.Abs(vertical) == 0)
        {
            timer = 0.0f;
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.LeftShift)) //correr
                bobbingSpeed *= 2;
            if (Input.GetKeyUp(KeyCode.LeftShift))
                bobbingSpeed = oBob;

            waveslice = Mathf.Sin(timer);
            timer = timer + bobbingSpeed;
            if (timer > Mathf.PI * 2)
            {
                timer = timer - (Mathf.PI * 2);
            }
        }
        if (waveslice != 0)
        {
            float translateChange = waveslice * bobbingAmount;
            float totalAxes = Mathf.Abs(horizontal) + Mathf.Abs(vertical);
            totalAxes = Mathf.Clamp(totalAxes, 0.0f, 1.0f);
            translateChange = totalAxes * translateChange;
            cSharpConversion=Selector(eje, cSharpConversion, midpoint + translateChange);
            //cSharpConversion.y = midpoint + translateChange;
        }
        else
        {
            cSharpConversion=Selector(eje, cSharpConversion, midpoint);
        }

        transform.localPosition = cSharpConversion;
    }


    Vector3 Selector(string toTest, Vector3 Pos,float point)
    {
        if (toTest == "x")
            Pos.x = point;
        else if (toTest == "z")
            Pos.z = point;
        else
            Pos.y = point;

        return Pos;
    }
}
