using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunBober : MonoBehaviour
{

    private float timer = 0.0f;
    public float bobbingSpeed = 0.18f;
    public float bobbingAmount = 0.05f;
    public float midpoint = 0.0f;
    public string eje = "y";
    private float resetTime = 0;
    private float oBobSpeed;
    private float oBobAmount;
    private bool aiming;

    private void Start()
    {
        oBobAmount = bobbingAmount;
        oBobSpeed = bobbingSpeed;   
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(1))
            aiming = true;
        if (Input.GetMouseButtonUp(1))
            aiming = false;

        if (aiming)
        {
            resetTime = 0;
        }
        else
        {
            resetTime += Time.deltaTime;
            if (resetTime >= 0.3f)
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
                    {
                        bobbingSpeed *= 2;
                        bobbingAmount *= 2;
                    }
                        
                    if (Input.GetKeyUp(KeyCode.LeftShift))
                    {
                        bobbingAmount = oBobAmount;
                        bobbingSpeed = oBobSpeed;
                    }
                        

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
                    cSharpConversion = Selector(eje, cSharpConversion, midpoint + translateChange);
                    //cSharpConversion.y = midpoint + translateChange;
                }
                else
                {
                    cSharpConversion = Selector(eje, cSharpConversion, midpoint);
                }

                transform.localPosition = cSharpConversion;
            }
        }

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
