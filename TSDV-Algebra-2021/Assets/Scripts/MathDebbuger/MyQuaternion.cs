using UnityEngine;
using System;

namespace CustomMath
{
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

        private static MyQuaternion identityQuat = new MyQuaternion(0, 0, 0, 1);
        #endregion

        public MyQuaternion(float x, float y, float z, float w)
        {
            this.x = x; this.y = y;
            this.z = z; this.w = w;
        }
        public void Set(float x, float y, float z, float w)
        {
            this.x = x; this.y = y;
            this.z = z; this.w = w;
        }

        public MyQuaternion(Vec3 v3)
        {
            x = v3.x; y = v3.y;
            z = v3.z; w = 1;
        }
        public static MyQuaternion identity
        {
            get
            {
                return identityQuat;
            }
        }
        public float Dot(MyQuaternion a, MyQuaternion b)
        {
            return (a.x * b.x + a.y * b.y + a.z * b.z + a.w * b.w);
        }
        public float Angle(MyQuaternion a, MyQuaternion b)
        {
            float dotProduct = Dot(a, b);

            return 0.0f; // ?
        }
        public static MyQuaternion operator *(MyQuaternion a, MyQuaternion b)
        {


            return new MyQuaternion();
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

        public override int GetHashCode()
        {
            return 0;
        }
        #endregion
    }
}
