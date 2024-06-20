using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cake : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 8f;
    Rigidbody rd;

    public GameObject effect;

    public AudioClip sound1;
    public AudioSource audio;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            GameManager gm = FindObjectOfType<GameManager>();
            if (gm != null)
            {
                audio.PlayOneShot(sound1);
                Instantiate(effect, transform.position, Quaternion.identity);

                gm.SetScore(2);
                Destroy(gameObject, 1f);

                renderer.enabled = false;

            }
        }
    }

    public MeshRenderer renderer;

    // Start is called before the first frame update
    void Start()
    {
        rd = GetComponent<Rigidbody>();
        rd.velocity = transform.forward * speed;

        Destroy(gameObject, 3f);

        renderer = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
