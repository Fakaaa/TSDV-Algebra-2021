using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanBeRender : MonoBehaviour
{

    public delegate void ICanBeRender();

    public ICanBeRender stillRendering;

    public MeshRenderer myMesh;
    private void Start()
    {
        myMesh = gameObject.GetComponent<MeshRenderer>();
    }

    public void RenderMe()
    {
        stillRendering?.Invoke();
    }
}
