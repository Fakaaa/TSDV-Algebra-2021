using UnityEngine;
using CustomMath;

public class MyMatrix4X4 : MonoBehaviour
{
    [SerializeField] GameObject cube;
    [SerializeField] GameObject cube2;
    void Start()
    {
        Matrix4x4 unityA = Matrix4x4.Translate(cube.transform.position);
        Matrix4x4 unityB = Matrix4x4.Translate(cube2.transform.position);
        Matrix4x4 resultMatUnity = Matrix4x4.identity;
        Mat4X4 myA = Mat4X4.Translate(cube.transform.position);
        Mat4X4 myB = Mat4X4.Translate(cube2.transform.position);
        Mat4X4 myResultC = Mat4X4.identity;

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
        //Matrix4x4 unityMatRotation = Matrix4x4.Rotate(cube.transform.rotation);
        #endregion
        //----------------------------
        #region PRODUCT MATRIX
        Debug.Log("Unity Matrix");
        resultMatUnity = unityA * unityB;
        DebugMatrix(resultMatUnity);
        Debug.Log("==================================");
        Debug.Log("My Matrix");
        myResultC = myA * myB;
        DebugMatrix(myResultC);
        #endregion
        //----------------------------
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
