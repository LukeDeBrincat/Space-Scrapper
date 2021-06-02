using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabbableItems : OVRGrabbable
{
    private Renderer renderer;
    public ParticleSystemRenderer Ps;
    public ParticleSystem A;

    public GameObject GameManager;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        renderer = GetComponent<MeshRenderer>();

        Ps = A.GetComponent<ParticleSystemRenderer>();

        GameManager = GameObject.Find("GameManager");
    }

    public override void GrabBegin(OVRGrabber hand, Collider grabPoint)
    {

        if (GameManager.GetComponent<GameManager>().tutorial == false)
        {
            Material chosen = GetComponent<Debris>().hidden;
            base.GrabBegin(hand, grabPoint);
            renderer.material = chosen;
            GetComponent<Debris>().touching = true;
            Ps.material = chosen;
        }

        else
        {
            Material chosen = GetComponent<Debris>().hidden;
            base.GrabBegin(hand, grabPoint);
            renderer.material = chosen;
            GetComponent<Debris>().touching = true;
            Ps.material = chosen;
            GameManager.GetComponent<GameManager>().Tutorial4.Stop();
            GameManager.GetComponent<GameManager>().Tutorial5.Play();
            
        }

    }

    public override void GrabEnd(Vector3 linearVelocity, Vector3 angularVelocity)
    {
        base.GrabEnd(linearVelocity * 5, angularVelocity);
        A.Play();
        GetComponent<Debris>().thrown = true;
    }
}
