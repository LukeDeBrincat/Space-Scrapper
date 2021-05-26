using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabbableItems : OVRGrabbable
{
    private Renderer renderer;
    public ParticleSystemRenderer Ps;
    public ParticleSystem A;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        renderer = GetComponent<MeshRenderer>();

        Ps = A.GetComponent<ParticleSystemRenderer>();
    }

    public override void GrabBegin(OVRGrabber hand, Collider grabPoint)
    {
        Material chosen = GetComponent<Debris>().hidden;
        base.GrabBegin(hand, grabPoint);
        renderer.material = chosen;
        GetComponent<Debris>().touching = true;
        Ps.material = chosen;

    }

    public override void GrabEnd(Vector3 linearVelocity, Vector3 angularVelocity)
    {
        base.GrabEnd(linearVelocity * 5, angularVelocity);
        A.Play();

    }
}
