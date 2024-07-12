using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class PlayerController : MonoBehaviour
{
    public Rigidbody playerRigidbody;
    public float speed = 8f;
    public int cnt = 3;
    public VariableJoystick joy;

    public GameObject[] life;

    public void Die()
    {
        gameObject.SetActive(false);

        GameManager gm = FindObjectOfType<GameManager>();
        gm.EndGame();
    }

    public void UpdateUI()
    {

        for (int i = 0; i < life.Length; i++)
        {
            life[i].SetActive(false);
        }

        for (int i=0; i<cnt; i++)
        {
            life[i].SetActive(true);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
        UpdateUI();
    }



    // Update is called once per frame
    void Update()
    {
        //float xInput = Input.GetAxis("Horizontal");
        //float zInput = Input.GetAxis("Vertical");

        float xInput = joy.Horizontal;
        float zInput = joy.Vertical;

        float xSpeed = xInput * speed;
        float zSpeed = zInput * speed;


        Vector3 newVel = new Vector3 (xSpeed, 0f, zSpeed);
        //playerRigidbody.velocity = newVel;

        if(xInput != 0f || zInput != 0f) 
        {
            playerRigidbody.transform.rotation = Quaternion.LookRotation (newVel);
            playerRigidbody.MovePosition(playerRigidbody.position + transform.forward * speed * Time.deltaTime);
        }
    }
}
