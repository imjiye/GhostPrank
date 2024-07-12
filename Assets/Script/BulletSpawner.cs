using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    public GameObject prefab;
    public float rateMin;
    public float rateMax;

    Transform target;
    float spawnRate;
    float timeAfterSpawn;

    // Start is called before the first frame update
    void Start()
    {
        timeAfterSpawn = 0;
        spawnRate = Random.Range(rateMin, rateMax);
        target = FindAnyObjectByType<PlayerController>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        timeAfterSpawn += Time.deltaTime;
        
        if(timeAfterSpawn > spawnRate)
        {
            timeAfterSpawn = 0;

            GameObject obj =
                Instantiate(prefab, transform.position, transform.rotation);

            obj.transform.LookAt(target);

            spawnRate = Random.Range(rateMin, rateMax);
        }
    }
}
