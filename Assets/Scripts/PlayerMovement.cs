using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float speed = 20f;
    public GameObject Lefthand;
    public GameObject RightHand;

    public AudioSource Thruster;
    public AudioSource Music;

    private bool Playing;
    private bool Playing2;

    // Start is called before the first frame update
    void Start()
    {
        Music.Play();
    }

    // Update is called once per frame
    void Update()
    {
        Thrust();
        
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
        }

        else if (OVRInput.Get(OVRInput.Button.Three) == true)
        {
            GetComponent<Rigidbody>().velocity += speed * Time.deltaTime * -Lefthand.transform.forward;

            if (Playing == false)
            {
                Thruster.Play();
                Playing = true;
            }
        }

        else
        {
            Thruster.Stop();
            Playing = false;
        }
    }
}
