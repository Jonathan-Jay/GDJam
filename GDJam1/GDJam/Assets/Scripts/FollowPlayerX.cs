using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayerX : MonoBehaviour
{
    public bool isCamera;
    public float parallaxModifier;
    public GameObject player;

    private Vector3 initialPosition;
    void Start()
    {
        if (!isCamera)
        {
            initialPosition = GetComponent<Transform>().position;
        }
    }

    // Update is called once per frame
    void Update()
    {
        float playerPosX = player.transform.position.x;

        if (isCamera)
        {
            Vector3 temp = GetComponent<Transform>().position;
            temp.x = playerPosX;
            GetComponent<Transform>().SetPositionAndRotation(temp, Quaternion.identity);
        }
        else
        {
            GetComponent<Transform>().SetPositionAndRotation(initialPosition + Vector3.right * playerPosX * parallaxModifier, Quaternion.identity);
        }
    }
}
