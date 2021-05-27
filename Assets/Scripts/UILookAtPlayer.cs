using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UILookAtPlayer : MonoBehaviour
{
    public GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 targetdirection = transform.position - Player.transform.position;

        float singleStep = 1 * Time.deltaTime;

        Vector3 NewDirection = Vector3.RotateTowards(transform.forward, targetdirection, singleStep, 0);

        transform.rotation = Quaternion.LookRotation(NewDirection);
    }
}
