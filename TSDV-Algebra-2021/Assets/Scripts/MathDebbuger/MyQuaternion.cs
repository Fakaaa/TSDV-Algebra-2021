using System;
using UnityEngine;

namespace CustomMath
{
    [Serializable]
    public struct MyQuaternion : IEquatable<MyQuaternion>
    {
        public float x;
        public float y;
        public float z;
        public float w;

        #region constants
        public const float kEpsilon = 1e-06f;
        public const float i = 1.0f;
        public const float j = 1.0f;
        public const float k = 1.0f;
        public const float e = 1.0f;

        public Quaternion convertQuat { get { return new Quaternion(x, y, z, w); } }
        private static MyQuaternion identityQuat = new MyQuaternion(0, 0, 0, 1);
        #endregion

        public MyQuaternion(float x, float y, float z, float w)
        {
            this.x = x; this.y = y;
            this.z = z; this.w = w;
        }
        public MyQuaternion(Quaternion quat)
        {
            this.x = quat.x; this.y = quat.y;
            this.z = quat.z; this.w = quat.w;
        }
        public MyQuaternion(MyQuaternion quat)
        {
            this.x = quat.x; this.y = quat.y;
            this.z = quat.z; this.w = quat.w;
        }
        public void Set(float x, float y, float z, float w)
        {
            this.x = x; this.y = y;
            this.z = z; this.w = w;
        }
        public static MyQuaternion identity
        {
            get
            {
                return identityQuat;
            }
        }
        public MyQuaternion normalized
        {
            get
            {
                return Normalize(this);
            }
        }
        public static MyQuaternion AngleAxis(float angle, Vec3 axis)    //Tiene que estar normalizado el vector
        {
            angle *= (Mathf.PI / 180) * 0.5f;
            axis.Normalize();

            double axisX = axis.x * Mathf.Sin(angle);
            double axisY = axis.y * Mathf.Sin(angle);
            double axisZ = axis.z * Mathf.Sin(angle);
            float axisW = Mathf.Cos(angle);

            axisX = Math.Round(axisX,1,MidpointRounding.AwayFromZero);
            axisY = Math.Round(axisY,1,MidpointRounding.AwayFromZero);
            axisZ = Math.Round(axisZ,1,MidpointRounding.AwayFromZero);

            MyQuaternion resulAngleAxis = new MyQuaternion((float)axisX, (float)axisY, (float)axisZ, axisW);
            return resulAngleAxis.normalized;
        }
        public static MyQuaternion Euler(Vec3 euler)
        {
            MyQuaternion qX = identity;
            MyQuaternion qY = identity;
            MyQuaternion qZ = identity;

            float sin = Mathf.Sin(Mathf.Deg2Rad * euler.x * 0.5f);
            float cos = Mathf.Cos(Mathf.Deg2Rad * euler.x * 0.5f);
            qX.Set(sin, 0.0f, 0.0f, cos);

            sin = Mathf.Sin(Mathf.Deg2Rad * euler.y * 0.5f);
            cos = Mathf.Cos(Mathf.Deg2Rad * euler.y * 0.5f);
            qY.Set(0.0f, sin, 0.0f, cos);

            sin = Mathf.Sin(Mathf.Deg2Rad * euler.z * 0.5f);
            cos = Mathf.Cos(Mathf.Deg2Rad * euler.z * 0.5f);
            qZ.Set(0.0f, 0.0f, sin, cos);

            return new MyQuaternion(qX * qY * qZ);
        }
        public MyQuaternion LookRotation(Vec3 direction)
        {
            return identity;    //Noup
        }
        public static float Dot(MyQuaternion a, MyQuaternion b)
        {
            return (a.x * b.x + a.y * b.y + a.z * b.z + a.w * b.w);
        }
        public static float Angle(MyQuaternion a, MyQuaternion b)
        {
            MyQuaternion inverA = Inverse(a);
            MyQuaternion calc = b * inverA;

            float angle = Mathf.Acos(calc.w) * 2.0f * Mathf.Rad2Deg;
            return angle;
        }
        public static MyQuaternion Slerp(MyQuaternion a, MyQuaternion b, float t)
        {
            Mathf.Clamp(t, 0, 1f);
            return SlerpUnclamped(a,b,t);
        }
        public static MyQuaternion SlerpUnclamped(MyQuaternion a, MyQuaternion b, float t)
        {
            MyQuaternion quatInterpolated = identity;

            float cosHalfTheta = Dot(a, b);
            if (Mathf.Abs(cosHalfTheta) >= 1f)
            {
                quatInterpolated.Set(a.x, a.y, a.z, a.w);
                return quatInterpolated;
            }
            float halfTheta = Mathf.Acos(cosHalfTheta);
            float sinHalfTheta = Mathf.Sqrt(1 - cosHalfTheta * cosHalfTheta);
            if (Mathf.Abs(sinHalfTheta) < 0.001f)
            {
                quatInterpolated.w = (a.w * 0.5f + b.w * 0.5f);
                quatInterpolated.x = (a.x * 0.5f + b.x * 0.5f);
                quatInterpolated.y = (a.y * 0.5f + b.y * 0.5f);
                quatInterpolated.z = (a.z * 0.5f + b.z * 0.5f);
                return quatInterpolated;
            }
            float ratioA = Mathf.Sin((1 - t) * halfTheta) / sinHalfTheta;
            float ratioB = Mathf.Sin(t * halfTheta) / sinHalfTheta;
            quatInterpolated.w = (a.w * ratioA + b.w * ratioB);
            quatInterpolated.x = (a.x * ratioA + b.x * ratioB);
            quatInterpolated.y = (a.y * ratioA + b.y * ratioB);
            quatInterpolated.z = (a.z * ratioA + b.z * ratioB);
            return quatInterpolated;
        }
        public static MyQuaternion Normalize(MyQuaternion quat)
        {
            float mag = Mathf.Sqrt(quat.x * quat.x + quat.y * quat.y + quat.z * quat.z + quat.w * quat.w);

            quat.x /= mag;
            quat.y /= mag;
            quat.z /= mag;
            quat.w /= mag;

            return new MyQuaternion(quat.x,quat.y,quat.z,quat.w);
        }
        public static MyQuaternion Inverse(MyQuaternion quat)
        {
            return new MyQuaternion(-quat.x, -quat.y, -quat.z, quat.w);
        }
        public static Vec3 operator*(MyQuaternion rotation, Vec3 point)
        {
            float num = rotation.x * 2f;
            float num2 = rotation.y * 2f;
            float num3 = rotation.z * 2f;
            float num4 = rotation.x * num;
            float num5 = rotation.y * num2;
            float num6 = rotation.z * num3;
            float num7 = rotation.x * num2;
            float num8 = rotation.x * num3;
            float num9 = rotation.y * num3;
            float num10 = rotation.w * num;
            float num11 = rotation.w * num2;
            float num12 = rotation.w * num3;
            Vec3 result;
            result.x = (1f - (num5 + num6)) * point.x + (num7 - num12) * point.y + (num8 + num11) * point.z;
            result.y = (num7 + num12) * point.x + (1f - (num4 + num6)) * point.y + (num9 - num10) * point.z;
            result.z = (num8 - num11) * point.x + (num9 + num10) * point.y + (1f - (num4 + num5)) * point.z;
            return result;
        }
        public static MyQuaternion operator *(MyQuaternion a, MyQuaternion b)
        {
            #region Rules
            //ixi = -1;
            //jxj = -1;
            //kxk = -1;
            //ijk = -1;
            #endregion
            float awXbw = a.w * b.w;
            float awXbx = a.w * b.x;
            float awXby = a.w * b.y;
            float awXbz = a.w * b.z;

            float axXbw = a.x * b.w;
            float axXbx = a.x * b.x; 
            float axXby = a.x * b.y; 
            float axXbz = a.x * b.z; 

            float ayXbw = a.y * b.w;
            float ayXbx = a.y * b.x; 
            float ayXby = a.y * b.y; 
            float ayXbz = a.y * b.z; 

            float azXbw = a.z * b.w;
            float azXbx = a.z * b.x; 
            float azXby = a.z * b.y; 
            float azXbz = a.z * b.z; 


            float rowRealResult = (awXbw - axXbx - ayXby - azXbz);//* w 
            float rowIResult = (awXbx + axXbw + ayXbz - azXby);   //* i
            float rowJResult = (awXby - axXbz + ayXbw + azXbx);   //* j
            float rowKResult = (awXbz + axXby - ayXbx + azXbw);   //* k

            return new MyQuaternion(rowIResult, rowJResult, rowKResult, rowRealResult);
        }
        public override string ToString()
        {
            return "X = " + x.ToString() + "   Y = " + y.ToString() + "   Z = " + z.ToString() + "   W = " + w.ToString();
        }
        #region Internals
        public override bool Equals(object other)
        {
            if (!(other is MyQuaternion)) return false;
            return Equals((MyQuaternion)other);
        }
        public bool Equals(MyQuaternion other)
        {
            return x == other.x && y == other.y && z == other.z && w == other.w;
        }
        #endregion
    }
}
