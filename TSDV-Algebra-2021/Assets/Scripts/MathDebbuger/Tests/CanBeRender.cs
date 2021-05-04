using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanBeRender : MonoBehaviour
{
    public MeshRenderer myMesh;

    private void Start()
    {
        myMesh = gameObject.GetComponent<MeshRenderer>();
    }

    public void RenderMe(bool what)
    {
        myMesh.enabled = what;
    }
}
