using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyMusic : MonoBehaviour
{
    // Removes all music
    private void Awake()
    {
        GameObject[] musicObjs = GameObject.FindGameObjectsWithTag("Music");

        foreach (GameObject obj in musicObjs)
        {
            Destroy(obj);
        }

    }
}
