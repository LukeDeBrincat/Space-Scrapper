using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashCan : MonoBehaviour
{
    public GameObject GameManager;

    public Material colour;
    public AudioSource Yay;
    public AudioSource Nay;

    public AudioSource HitRightBin;
    public AudioSource HitWrongBin;

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Debris")
        {
            if (other.GetComponent<Debris>().thrown == true)
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
                        GameManager.GetComponent<GameManager>().Tutorial5.Stop();
                        GameManager.GetComponent<GameManager>().Tutorial6.Play();
                    }
                }

                else
                {
                    if (GameManager.GetComponent<GameManager>().GameStarted)
                    {
                        GameManager.GetComponent<GameManager>().points -= 10;
                        Nay.Play();
                    }

                    else
                    {
                        GameManager.GetComponent<GameManager>().Tutorial5.Stop();
                        GameManager.GetComponent<GameManager>().Tutorial7.Play();
                        Instantiate(GameManager.GetComponent<GameManager>().Debris[0], GameManager.GetComponent<GameManager>().Spawnpoint1.transform.position, transform.rotation);
                    }
                }
            }

            Destroy(other.gameObject);
        }
    }
}
