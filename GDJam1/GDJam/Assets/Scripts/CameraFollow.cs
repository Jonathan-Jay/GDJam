using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public Move Player;

    void Update()
    {
        Vector3 newPosition = Player.GetComponent<Transform>().position;
        newPosition.z = this.GetComponent<Transform>().position.z;

        GetComponent<Transform>().position = newPosition;
    }
}
