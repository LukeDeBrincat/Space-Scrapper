using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashCan : MonoBehaviour
{
    public GameObject GameManager;

    public Material colour;
    public AudioSource Yay;
    public AudioSource Nay;

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Debris")
        {
            if (other.GetComponent<Debris>().hidden == colour)
            {
                if (GameManager.GetComponent<GameManager>().GameStarted)
                {
                    GameManager.GetComponent<GameManager>().points += 20;
                    Yay.Play();
                }

                else
                {
                    GameManager.GetComponent<GameManager>().tutorialIndex++;
                }
            }

            else
            {
                GameManager.GetComponent<GameManager>().points -= 10;
                Nay.Play();
            }

            Destroy(other.gameObject);
        }
    }
}
