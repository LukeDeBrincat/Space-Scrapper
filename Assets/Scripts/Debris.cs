using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Debris : MonoBehaviour
{
    public bool touching;
    public Material[] materials;

    public Material hidden;

    public bool thrown;
    // Start is called before the first frame update
    void Awake()
    {
        hidden = materials[Random.Range(0, 4)];
        GetComponent<MeshRenderer>().material = hidden;

        thrown = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!touching)
        {
            GetComponent<Rigidbody>().velocity = 10 * Time.deltaTime * transform.forward;
        }
    }
}
