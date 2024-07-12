using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float speed = 8f;
    Rigidbody rd;

    public GameObject effect1;
    public GameObject effect2;

    public AudioClip sound1;
    public AudioSource audio;

    public MeshRenderer renderer;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            PlayerController pc = other.GetComponent<PlayerController>();
            if (pc != null)
            {
                pc.cnt--;
                pc.UpdateUI();
                audio.PlayOneShot(sound1);
                Instantiate(effect1, transform.position, Quaternion.identity);
                Destroy(gameObject, 1f);
                renderer.enabled = false;
                

                if (pc.cnt == 0)
                {
                    audio.PlayOneShot(sound1);
                    Instantiate(effect2, transform.position, Quaternion.identity);
                    pc.Die();
                }
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        rd = GetComponent<Rigidbody>();
        rd.velocity = transform.forward * speed;
        renderer = GetComponent<MeshRenderer>();

        Destroy(gameObject, 3f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
