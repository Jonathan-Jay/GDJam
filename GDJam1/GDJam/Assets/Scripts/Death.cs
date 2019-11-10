using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{
    public float height;
    public float width;
    public bool Spawnpoint;
    public bool isDeath;
    public bool isDeathHole;

    public GameObject player;
    public GameObject SpawnPoint;
    void Start()
    {
        SpawnPoint.GetComponent<Transform>().SetPositionAndRotation(player.transform.position, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 ObjPos = GetComponent<Transform>().position;
        Vector3 playerPos = player.transform.position;
        Vector3 spawnPoint = SpawnPoint.transform.position;
        if (isDeath)
        {
            if ( (playerPos.x < ObjPos.x + width / 2 && playerPos.x > ObjPos.x - width / 2 &&
                playerPos.y < ObjPos.y + height / 2 && playerPos.y > ObjPos.y - height / 2) ||
                (playerPos.y < ObjPos.y + height / 2 && isDeathHole) )
            {
                float temp = player.GetComponent<Rigidbody2D>().velocity.x;
                player.GetComponent<Rigidbody2D>().AddRelativeForce(Vector2.left * temp * Mathf.Abs(temp) * 2 );
                player.GetComponent<Transform>().SetPositionAndRotation(spawnPoint, Quaternion.identity);
            }
        }
        else if (Spawnpoint)
        {
            if (playerPos.x < ObjPos.x + width / 2 && playerPos.x > ObjPos.x - width / 2 &&
                playerPos.y < ObjPos.y + height / 2 && playerPos.y > ObjPos.y - height / 2)
            {
                ObjPos.z = playerPos.z;
                SpawnPoint.GetComponent<Transform>().SetPositionAndRotation(ObjPos, Quaternion.identity);
            }
        }
    }
}
