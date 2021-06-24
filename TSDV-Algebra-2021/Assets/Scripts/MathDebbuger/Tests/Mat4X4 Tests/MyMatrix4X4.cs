using UnityEngine;
using CustomMath;

public class MyMatrix4X4 : MonoBehaviour
{
    [SerializeField] GameObject cube;
    void Start()
    {
        //----------------------------
        #region TRANSLATE TEST
        //Matrix4x4 unityMatTranslate = Matrix4x4.Translate(cube.transform.position);
        //Mat4X4 myMatTranslate = Mat4X4.Translate(cube.transform.position);
        //Debug.Log("Unity Matrix");
        //DebugMatrix(unityMatTranslate);
        //Debug.Log("----------------------------------");
        //unityMatTranslate = unityMatTranslate.transpose;
        //DebugMatrix(unityMatTranslate);
        //Debug.Log("==================================");
        //Debug.Log("My Matrix");
        //DebugMatrix(myMatTranslate);
        //Debug.Log("----------------------------------");
        //myMatTranslate = myMatTranslate.transpose;
        //DebugMatrix(myMatTranslate);
        #endregion
        //----------------------------
        #region SCALE TEST
        //Matrix4x4 unityMatScale = Matrix4x4.Scale(cube.transform.localScale);
        //Mat4X4 myMatSacale = Mat4X4.Scale(cube.transform.localScale);
        //Debug.Log("Unity Matrix");
        //DebugMatrix(unityMatScale);
        //Debug.Log("==================================");
        //Debug.Log("My Matrix");
        //DebugMatrix(myMatSacale);
        #endregion
        //----------------------------
        #region ROTATE TEST
        Matrix4x4 unityMatRotation = Matrix4x4.Rotate(cube.transform.rotation);
        #endregion
    }


    public void DebugMatrix(Matrix4x4 mat)
    {
        Debug.Log("[" + mat.m00.ToString() + "][" + mat.m01.ToString() + "][" + mat.m02.ToString() + "][" + mat.m03.ToString() + "]");
        Debug.Log("[" + mat.m10.ToString() + "][" + mat.m11.ToString() + "][" + mat.m12.ToString() + "][" + mat.m13.ToString() + "]");
        Debug.Log("[" + mat.m20.ToString() + "][" + mat.m21.ToString() + "][" + mat.m22.ToString() + "][" + mat.m23.ToString() + "]");
        Debug.Log("[" + mat.m30.ToString() + "][" + mat.m31.ToString() + "][" + mat.m32.ToString() + "][" + mat.m33.ToString() + "]");
    }
    public void DebugMatrix(Mat4X4 mat)
    {
        Debug.Log("[" + mat.m00.ToString() + "][" + mat.m01.ToString() + "][" + mat.m02.ToString() + "][" + mat.m03.ToString() + "]");
        Debug.Log("[" + mat.m10.ToString() + "][" + mat.m11.ToString() + "][" + mat.m12.ToString() + "][" + mat.m13.ToString() + "]");
        Debug.Log("[" + mat.m20.ToString() + "][" + mat.m21.ToString() + "][" + mat.m22.ToString() + "][" + mat.m23.ToString() + "]");
        Debug.Log("[" + mat.m30.ToString() + "][" + mat.m31.ToString() + "][" + mat.m32.ToString() + "][" + mat.m33.ToString() + "]");
    }
}
