using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public float speed;
    public float FinalPositionX;
    public float FinalPositionY;
    public float width;
    public bool isPlatform;
    public bool isFallingPlatform;

    public GameObject player;

    private Vector3 initialPos;
    private float finalPosX = 0;
    private float finalPosY = 0;
    private float platformx = 0;
    private float platformy = 0;
    private float yspeed = 0;

    private bool MovingRight = true;
    private bool MovingUp = true;
    private bool negativeX = false;
    private bool negativeY = false;

    void Start()
    {
        initialPos = GetComponent<Transform>().position;
        if (FinalPositionX < 0)
            negativeX = true;
        finalPosX = initialPos.x + FinalPositionX;

        if (FinalPositionY < 0)
            negativeY = true;
        finalPosY = initialPos.y + FinalPositionY;
    }

    void Update()
    {
        if ( (FinalPositionX != 0 || FinalPositionY != 0 || isFallingPlatform) && speed > 0 && width > 0)
        {
            platformx = 0;
            Vector3 platformPos = GetComponent<Transform>().position;
            Vector3 temp = player.transform.position - platformPos;

            if (!isFallingPlatform)
            {
                platformy = 0;


                if (FinalPositionX != 0 && !isFallingPlatform)
                {
                    yspeed = FinalPositionY / FinalPositionX * speed;

                    if (negativeX)
                    {
                        if (platformPos.x <= finalPosX && !MovingRight)
                        {
                            MovingRight = true;
                        }
                        else if (platformPos.x >= initialPos.x && MovingRight)
                        {
                            MovingRight = false;
                        }
                    }
                    else
                    {
                        if (platformPos.x >= finalPosX && MovingRight)
                        {
                            MovingRight = false;
                        }
                        else if (platformPos.x <= initialPos.x && !MovingRight)
                        {
                            MovingRight = true;
                        }
                    }


                    if (MovingRight)
                    {
                        platformx += speed;
                        platformy += yspeed;
                    }
                    else
                    {
                        platformx -= speed;
                        platformy -= yspeed;
                    }
                }
                else
                {
                    if (negativeY)
                    {
                        if (platformPos.y <= finalPosY && !MovingUp)
                        {
                            MovingUp = true;
                        }
                        else if (platformPos.y >= initialPos.y && MovingUp)
                        {
                            MovingUp = false;
                        }
                    }
                    else
                    {
                        if (platformPos.y >= finalPosY && MovingUp)
                        {
                            MovingUp = false;
                        }
                        else if (platformPos.y <= initialPos.y && !MovingUp)
                        {
                            MovingUp = true;
                        }
                    }

                    if (MovingUp)
                    {
                        platformy += speed;
                    }
                    else
                    {
                        platformy -= speed;
                    }
                }

            }

            if (isFallingPlatform && FinalPositionY < 0)
            {
                if (platformPos.y >= initialPos.y)
                    platformy = 0;

                if (temp.x < (width) / 2 && temp.x > -(width) / 2 && temp.y > 0.5 && temp.y < 2.45)
                    platformy = -speed;

                if (platformPos.y <= finalPosY)
                    platformy = speed;

            }

            platformx *= 50 * Time.deltaTime;

            if ((temp.x < (width) / 2 && temp.x > -(width) / 2 && temp.y > 0.5 && temp.y < 2.45) && isPlatform)
            {
                player.transform.Translate(Vector3.right * platformx + Vector3.up * platformy * 50 * Time.deltaTime);
            }

            GetComponent<Transform>().Translate(Vector3.right * platformx + Vector3.up * platformy * 50 * Time.deltaTime);
        }

    }
}
