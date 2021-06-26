using UnityEngine;
using CustomMath;
using EjerciciosAlgebra;

public class TestQuaternion : MonoBehaviour
{
    [SerializeField] GameObject cube1;
    [SerializeField] GameObject cube2;
    [SerializeField] GameObject cylinder;
    [SerializeField] public float valueLerp;

    private Quaternion unityQuaternion;
    private Quaternion unityQuaternion2;

    private MyQuaternion myQuaternion;
    private MyQuaternion myQuaternion2;
    Vector3 repreSentacionUniQuat = Vector3.one;
    Vec3 repreSentacionMyQuat = Vec3.One;

    void Start()
    {
        #region VARIABLES
        unityQuaternion = new Quaternion(3, 5, 0, 1);
        unityQuaternion2 = new Quaternion(1, 0, 0, 1);
        myQuaternion = new MyQuaternion(3, 5, 0, 1);
        myQuaternion2 = new MyQuaternion(1, 0, 0, 1);
        #endregion

        #region TEST ANGLE AXIS
        //unityQuaternion = Quaternion.AngleAxis(180, Vector3.up);
        //myQuaternion = MyQuaternion.AngleAxis(180, Vec3.Up);
        //
        //repreSentacionUniQuat = unityQuaternion * repreSentacionUniQuat;
        //repreSentacionMyQuat = myQuaternion * repreSentacionMyQuat;
        //
        //repreSentacionMyQuat *= 2;  //Escalo mi vector para ver que ambos esten en la direccion correcta
          
          #region VECTOR DEBUGGER INCLUSIONES
          //VectorDebugger.AddVector(repreSentacionUniQuat, Color.red, "Unity Vector");
          //VectorDebugger.AddVector(repreSentacionMyQuat, Color.green, "My Vector");
          //
          //VectorDebugger.EnableCoordinates();
          //VectorDebugger.EnableEditorView("My Vector");
          //VectorDebugger.EnableEditorView("Unity Vector");
          #endregion

        #endregion

        #region DEBUG CONSOLE QUATERNIONS
        //Debug.Log("Unity quaternion:" + unityQuaternion);
        //Debug.Log("--------------------------------");
        //Debug.Log("My quaternion:" + myQuaternion);
        #endregion
    }

    private void Update()
    {
        #region VECTORES UPDATED
        //VectorDebugger.UpdatePosition("Unity Vector", repreSentacionUniQuat);
        //VectorDebugger.UpdatePosition("My Vector", repreSentacionMyQuat);
        #endregion

        #region TEST LERP UNITY X MY QUAT
        ////Unity
        //unityQuaternion = Quaternion.LerpUnclamped(cube1.transform.rotation,
        //    cube2.transform.rotation, valueLerp);
        //repreSentacionUniQuat = Vector3.Lerp(Vector3.one, (unityQuaternion * repreSentacionUniQuat), valueLerp);
        ////My
        //MyQuaternion quatA = new MyQuaternion(cube1.transform.rotation);
        //MyQuaternion quatB = new MyQuaternion(cube2.transform.rotation);
        //myQuaternion = MyQuaternion.LerpUnclamped(quatA, quatB, valueLerp);
        //repreSentacionMyQuat = Vec3.Lerp(Vec3.One*2, (myQuaternion * repreSentacionMyQuat), valueLerp);
        #endregion
    }
}
