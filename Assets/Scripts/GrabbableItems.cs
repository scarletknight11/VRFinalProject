using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabbableItems : OVRGrabbable {

    [SerializeField] private Material _isGrabbableMat;
    private Material _originalMat;
    private Renderer _renderer;

    // Start is called before the first frame update
     protected override void Start()
    {
        base.Start();
        _renderer = GetComponent<Renderer>();
        _originalMat = _renderer.material;
    }

    //project virtual hands to grab object at location
     public override void GrabBegin(OVRGrabber hand, Collider grabPoint) 
    {
        base.GrabBegin(hand, grabPoint);
        _renderer.material = _isGrabbableMat;
    }

    //drop objects
    public override void GrabEnd(Vector3 linearVelocity, Vector3 angularVelocity)
    {
        base.GrabEnd(linearVelocity, angularVelocity);
        _renderer.material = _originalMat;
    }
}
