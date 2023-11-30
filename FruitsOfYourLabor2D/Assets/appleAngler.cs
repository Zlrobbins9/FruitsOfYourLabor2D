using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class appleAngler : MonoBehaviour
{
    float curAngle = 0;
    int launchCooldown = 0; //keeps track of how long has passed since the ball stopped moving
    bool rotatingLeft = true; //is the arrow moving left in part 1
    bool growing = true; //is the arrpw growing in part 2
    public int aimMode = 0; //0 = inactive, 1 = rotation, 2 = power
    public float forceToUse = 200;
    Rigidbody2D rb2D;
    void Start()
    {
        rb2D = GameObject.Find("Apple").GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        switch (aimMode)
        {
            case 0:
                if (Mathf.Abs(rb2D.velocity.x) < 0.25 && Mathf.Abs(rb2D.velocity.y) < 0.25)
                {
                    launchCooldown++;
                }
                else
                {
                    launchCooldown = 0;
                }

                if (launchCooldown >= 60) //60 frames of stillness have happened
                {
                    launchCooldown = 0;
                    aimMode = 1;
                    transform.eulerAngles = new Vector3(0, 0, 0.000197947f);
                    transform.localScale = new Vector3(1,1,1);
                }
                //TODO: add movement here
                GetComponent<SpriteRenderer>().enabled = false;
                break;
            case 1:
                GetComponent<SpriteRenderer>().enabled = true;
                if (Input.GetKeyDown("space"))
                {
                    aimMode = 2;
                }

                if (rotatingLeft)
                {
                    transform.eulerAngles += new Vector3(0, 0, 0.25f);
                    if (transform.eulerAngles.z >= 180)
                    {
                        rotatingLeft = false;
                        //Debug.Log("Now rotating right... vector is " + transform.eulerAngles.z);
                    }
                }
                else
                {
                    transform.eulerAngles += new Vector3(0, 0, -0.25f);
                    if (transform.eulerAngles.z <= 0 || transform.eulerAngles.z >= 182)
                    {
                        rotatingLeft = true;
                    }
                }

                float rotateRad = Mathf.Deg2Rad*transform.eulerAngles.z;

                transform.position = new Vector2(2*Mathf.Cos(rotateRad) + GameObject.Find("Apple").transform.position.x, 2 * Mathf.Sin(rotateRad) + +GameObject.Find("Apple").transform.position.y);
                break;
            case 2:
                float rotateRad2 = Mathf.Deg2Rad * transform.eulerAngles.z;
                if (growing)
                {
                    //Debug.Log("it is growing");
                    transform.localScale += new Vector3(0.005f,0,0);
                    if (transform.localScale.x >= 2)
                    {
                        growing = false;
                    }
                }
                else
                {
                    transform.localScale += new Vector3(-0.005f, 0, 0);
                    if (transform.localScale.x <= 1)
                    {
                        growing = true;
                    }
                }
                if (Input.GetKeyDown("space"))
                {
                    forceToUse = (transform.localScale.x-1) * 600;
                    //Debug.Log("force is: " + forceToUse + ", scale was: " + (transform.localScale.x-1));
                    rb2D.AddForce(new Vector2(forceToUse * Mathf.Cos(rotateRad2) + GameObject.Find("Apple").transform.position.x, forceToUse * Mathf.Sin(rotateRad2) + +GameObject.Find("Apple").transform.position.y), ForceMode2D.Force);
                    aimMode = 0;
                    //Debug.Log("Fire!");
                }
                break;
            default:


                break;
        }
        
    }
}
