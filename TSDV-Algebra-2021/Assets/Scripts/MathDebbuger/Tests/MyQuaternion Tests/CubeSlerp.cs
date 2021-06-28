using UnityEngine;
using CustomMath;

public class CubeSlerp : MonoBehaviour
{
    [SerializeField] GameObject rerfObject;
    [SerializeField] float speedRotate;
    private float timer;

    void Update()
    {
        timer += Time.deltaTime;
        
        //MIO
        MyQuaternion transformCube = new MyQuaternion(transform.rotation);
        transformCube = MyQuaternion.SlerpUnclamped(transformCube,new MyQuaternion(rerfObject.transform.rotation), timer *  speedRotate);
        transform.rotation = new Quaternion(transformCube.x, transformCube.y, transformCube.z, transformCube.w);
        Debug.Log(transform.rotation);

        //UNITY
        //transform.rotation = Quaternion.Slerp(transform.rotation, 
        //    Quaternion.LookRotation(rerfObject.transform.forward),
        //   timer * speedRotate);
        //Debug.Log(transform.rotation);
    }
}
