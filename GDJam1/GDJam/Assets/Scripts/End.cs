using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class End : MonoBehaviour
{
    public string NextScene;
    public GameObject player;

    void Update()
    {
        Vector3 playerPos = player.transform.position;
        Vector3 endPos = GetComponent<Transform>().position;
        endPos.z = playerPos.z;

        if (playerPos.x >= endPos.x)
        {
            endPos.x += 0.1f;
            player.transform.SetPositionAndRotation(endPos, Quaternion.identity);
            SceneManager.LoadScene(NextScene);
        }
    }
}
