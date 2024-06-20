using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoCamera : MonoBehaviour
{
    Transform p;
    // Start is called before the first frame update
    void Start()
    {
        p = GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = p.position + new Vector3(0, 7, -7);
    }
}
