using UnityEngine;
using CustomMath;

public class MyMatrix4X4 : MonoBehaviour
{
    [SerializeField] GameObject cube;
    [SerializeField] GameObject cube2;
    void Start()
    {
        //----------------------------
        #region TEST GETER []
        //Matrix4x4 unityMat = Matrix4x4.identity;
        //Mat4X4 myMat = Mat4X4.identity;
        //Debug.Log("Unity Matrix");
        //Debug.Log(unityMat[7]);
        //Debug.Log("==================================");
        //Debug.Log("My Matrix");
        //Debug.Log(myMat[7]);
        #endregion
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
        //Mat4X4 myMatRotation = Mat4X4.Rotate(cube.transform.rotation);
        //Debug.Log("Unity Matrix");
        //DebugMatrix(unityMatRotation);
        //Debug.Log("==================================");
        //Debug.Log("My Matrix");
        //DebugMatrix(myMatRotation);
        #endregion
        //----------------------------
        #region PRODUCT MATRIX
        //Matrix4x4 unityA = Matrix4x4.Translate(cube.transform.position);
        //Matrix4x4 unityB = Matrix4x4.Translate(cube2.transform.position);
        //Matrix4x4 resultMatUnity = Matrix4x4.identity;
        //Mat4X4 myA = Mat4X4.Translate(cube.transform.position);
        //Mat4X4 myB = Mat4X4.Translate(cube2.transform.position);
        //Mat4X4 myResultC = Mat4X4.identity;
        //Debug.Log("Unity Matrix");
        //resultMatUnity = unityA * unityB;
        //DebugMatrix(resultMatUnity);
        //Debug.Log("==================================");
        //Debug.Log("My Matrix");
        //myResultC = myA * myB;
        //DebugMatrix(myResultC);
        #endregion
        //----------------------------
        #region TEST MAT X VEC4
        //Matrix4x4 unityMat = Matrix4x4.Translate(cube2.transform.position);
        //Mat4X4 myMat = Mat4X4.Translate(cube2.transform.position);
        //Vector4 resultUnityMatPerVec = unityMat * new Vector4(2,5,2,1);
        //Vector4 resultMyMatPerVec = myMat * new Vector4(2,5,2,1);
        //Debug.Log("Unity Vec4 result: " + resultUnityMatPerVec.ToString());
        //Debug.Log("======================================================");
        //Debug.Log("My Vec4 result: " + resultMyMatPerVec.ToString());
        #endregion
        //----------------------------
        #region TEST GET QUAT FROM MAT
        //Matrix4x4 a = Matrix4x4.Rotate(cube2.transform.rotation);
        //Mat4X4 b = Mat4X4.Rotate(cube2.transform.rotation);
        //Quaternion q1 = a.rotation;
        //Quaternion q2 = b.rotation;
        //Debug.Log("Unity result quat from mat" + q1.ToString());
        //Debug.Log("==========================================");
        //Debug.Log("My result quat from mat" + q2.ToString());
        #endregion
        //----------------------------
        #region TEST LOSSY SCALE MAT
        Matrix4x4 unityMat = Matrix4x4.Scale(cube.transform.lossyScale);
        Vector3 losssyScaleUnityMat = unityMat.lossyScale;
        Debug.Log("Unity lossyScale from mat" + losssyScaleUnityMat.ToString());
        Debug.Log("==========================================");
        Mat4X4 myMat = Mat4X4.Scale(cube.transform.lossyScale);
        Vector3 losssyScaleMyMat = myMat.lossyScale;
        Debug.Log("My lossyScale from mat" + losssyScaleMyMat.ToString());
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
