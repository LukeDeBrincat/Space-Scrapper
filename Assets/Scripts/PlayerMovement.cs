using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float speed = 20f;
    public GameObject Lefthand;
    public GameObject RightHand;

    public AudioSource Thruster;

    private bool Playing;

    public ParticleSystem Righthand;
    public ParticleSystem LeftHand;

    public Transform spawn;

    public GameManager GameManager;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.GameStarted == true || GameManager.tutorial == true)
        {
            Thrust();
        }

        else
        {
            GetComponent<Rigidbody>().velocity = Vector3.zero;
            transform.position = spawn.position;
        }
    }

    private void Thrust()
    {
        if (OVRInput.Get(OVRInput.Button.One) == true)
        {
            GetComponent<Rigidbody>().velocity += speed * Time.deltaTime * -RightHand.transform.forward;

            if (Playing == false)
            {
                Thruster.Play();
                Playing = true;
            }

            Righthand.Play();
        }

        else if (OVRInput.Get(OVRInput.Button.Three) == true)
        {
            GetComponent<Rigidbody>().velocity += speed * Time.deltaTime * -Lefthand.transform.forward;

            if (Playing == false)
            {
                Thruster.Play();
                Playing = true;
            }

            LeftHand.Play();
        }

        else
        {
            Thruster.Stop();
            Playing = false;
            Righthand.Stop();
            LeftHand.Stop();
        }

        if (OVRInput.Get(OVRInput.Button.Two) == true)
        {
            transform.position = spawn.position;
            GetComponent<Rigidbody>().velocity = Vector3.zero;
        }
    }
}
