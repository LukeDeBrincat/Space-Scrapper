using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Environment : MonoBehaviour
{
    public GameManager GameManager;


    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Debris")
        {
            if (GameManager.tutorial == true)
            {
                GameManager.Tutorial5.Stop();
                GameManager.Tutorial7.Play();
                Instantiate(GameManager.Debris[0], GameManager.Spawnpoint1.transform.position, transform.rotation);

                Destroy(other.gameObject);
            }


        }
    }
}

