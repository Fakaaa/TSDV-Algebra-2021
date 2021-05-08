using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CustomMath; 

public class CanBeRender : MonoBehaviour
{
    public MeshRenderer myMesh;
    private Vec3 myPos;
    private void Awake()
    {
        myMesh = gameObject.GetComponent<MeshRenderer>();
        myPos = new Vec3(transform.position);
    }

    public Vec3 getRenderPos() { return myPos; }

    public void RenderMe(bool what)
    {
        myMesh.enabled = what;
    }
}
