using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoNotDestroyMusic : MonoBehaviour
{
    [SerializeField] private string objTag;

    // This allows music to play seamlessly between scenes, w/o restarting it.
    private void Awake()
    {
        GameObject[] musicObjs = GameObject.FindGameObjectsWithTag(objTag);
        if (musicObjs.Length > 1)
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
    }
}
