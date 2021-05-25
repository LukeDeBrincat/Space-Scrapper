using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabbableItems : OVRGrabbable
{
    private Renderer renderer;
    private TrailRenderer Tr = null;
    public ParticleSystemRenderer Ps;
    public ParticleSystem A;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        renderer = GetComponent<MeshRenderer>();
        Tr = GetComponent<TrailRenderer>();
        Tr.enabled = false;

        Ps = A.GetComponent<ParticleSystemRenderer>();
    }

    public override void GrabBegin(OVRGrabber hand, Collider grabPoint)
    {
        Material chosen = GetComponent<Debris>().hidden;
        base.GrabBegin(hand, grabPoint);
        renderer.material = chosen;
        GetComponent<Debris>().touching = true;
        Tr.material = chosen;
        Ps.material = chosen;

    }

    public override void GrabEnd(Vector3 linearVelocity, Vector3 angularVelocity)
    {
        base.GrabEnd(linearVelocity * 5, angularVelocity);
        A.Play();
        Tr.enabled = true;

    }
}
