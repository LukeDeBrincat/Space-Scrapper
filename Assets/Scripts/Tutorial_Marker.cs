using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial_Marker : MonoBehaviour
{
    public GameObject GameManager;

    // Start is called before the first frame update
    void Start()
    {
        GameManager = GameObject.Find("GameManager");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            GameManager.GetComponent<GameManager>().tutorialIndex++;
            Destroy(this.gameObject);
        }
    }
}
