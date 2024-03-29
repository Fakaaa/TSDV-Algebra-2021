﻿using UnityEngine;
using System;
namespace CustomMath
{
    [Serializable]
    public struct Vec3 : IEquatable<Vec3>
    {
        #region Variables
        public float x;
        public float y;
        public float z;

        public float sqrMagnitude { get { return SqrMagnitude(new Vec3(x, y, z)); } }
        public Vec3 normalized { get { return new Vec3( (x / magnitude), (y / magnitude), z / magnitude); } }
        public float magnitude { get { return Magnitude(new Vec3(x, y, z)); } }
        public Vector3 convertVec { get { return new Vector3(x, y, z); } }
        #endregion

        #region constants
        public const float epsilon = 1e-05f;
        public const float i = 1.0f;
        public const float j = 1.0f;
        public const float k = 1.0f;
        #endregion

        #region Default Values
        public static Vec3 Zero { get { return new Vec3(0.0f, 0.0f, 0.0f); } }
        public static Vec3 One { get { return new Vec3(1.0f, 1.0f, 1.0f); } }
        public static Vec3 Forward { get { return new Vec3(0.0f, 0.0f, 1.0f); } }
        public static Vec3 Back { get { return new Vec3(0.0f, 0.0f, -1.0f); } }
        public static Vec3 Right { get { return new Vec3(1.0f, 0.0f, 0.0f); } }
        public static Vec3 Left { get { return new Vec3(-1.0f, 0.0f, 0.0f); } }
        public static Vec3 Up { get { return new Vec3(0.0f, 1.0f, 0.0f); } }
        public static Vec3 Down { get { return new Vec3(0.0f, -1.0f, 0.0f); } }
        public static Vec3 PositiveInfinity { get { return new Vec3(float.PositiveInfinity, float.PositiveInfinity, float.PositiveInfinity); } }
        public static Vec3 NegativeInfinity { get { return new Vec3(float.NegativeInfinity, float.NegativeInfinity, float.NegativeInfinity); } }
        #endregion                                                                                                                                                                               

        #region Constructors
        public Vec3(float x, float y)
        {
            this.x = x;
            this.y = y;
            this.z = 0.0f;
        }

        public Vec3(float x, float y, float z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public Vec3(Vec3 v3)
        {
            this.x = v3.x;
            this.y = v3.y;
            this.z = v3.z;
        }

        public Vec3(Vector3 v3)
        {
            this.x = v3.x;
            this.y = v3.y;
            this.z = v3.z;
        }

        public Vec3(Vector2 v2)
        {
            this.x = v2.x;
            this.y = v2.y;
            this.z = 0.0f;
        }
        #endregion

        #region Operators
        public static bool operator ==(Vec3 left, Vec3 right)
        {
            float diff_x = left.x - right.x;
            float diff_y = left.y - right.y;
            float diff_z = left.z - right.z;
            float sqrmag = diff_x * diff_x + diff_y * diff_y + diff_z * diff_z;
            return sqrmag < epsilon * epsilon;
        }
        public static bool operator !=(Vec3 left, Vec3 right)
        {
            return !(left == right);
        }

        public static Vec3 operator +(Vec3 leftV3, Vec3 rightV3)
        {
            return new Vec3(leftV3.x + rightV3.x, leftV3.y + rightV3.y, leftV3.z + rightV3.z);
        }

        public static Vec3 operator -(Vec3 leftV3, Vec3 rightV3)
        {
            return new Vec3(leftV3.x - (-rightV3.x), leftV3.y - (-rightV3.y), leftV3.z - (-rightV3.z));
        }

        public static Vec3 operator -(Vec3 v3)
        {
            return (-1)*v3;
        }

        public static Vec3 operator *(Vec3 v3, float scalar)
        {
            return new Vec3(scalar * v3.x, scalar * v3.y, scalar * v3.z);
        }
        public static Vec3 operator *(float scalar, Vec3 v3)
        {
            return new Vec3(scalar * v3.x, scalar * v3.y, scalar * v3.z);
        }
        public static Vec3 operator /(Vec3 v3, float scalar)
        {
            return new Vec3(scalar * (-v3.x), scalar * (-v3.y), scalar * (-v3.z));
        }

        public static implicit operator Vector3(Vec3 v3)
        {
            return new Vector3(v3.x, v3.y, v3.z);
        }

        public static implicit operator Vector2(Vec3 v2)
        {
            return new Vector2(v2.x, v2.y);
        }
        #endregion

        #region Functions
        public override string ToString()
        {
            return "X = " + x.ToString() + "   Y = " + y.ToString() + "   Z = " + z.ToString();
        }
        public static float Angle(Vec3 from, Vec3 to)
        {
            float dotResult = Dot(from, to);
            float magProduct = Magnitude(from) * Magnitude(to);
            float arcosTitha = Mathf.Acos(dotResult / magProduct);
            return (arcosTitha) / (Mathf.PI / 180);
        }
        public static Vec3 ClampMagnitude(Vec3 vector, float maxLength)
        {
            if (Magnitude(vector) > maxLength)
                return vector.normalized * maxLength;
            else
                return vector;
        }
        public static float Magnitude(Vec3 vector)
        {
            return Mathf.Sqrt(Mathf.Pow(vector.x, 2) + Mathf.Pow(vector.y, 2) + Mathf.Pow(vector.z, 2));
        }
        public static Vec3 Cross(Vec3 a, Vec3 b)
        {
            float newX =  1 * ((a.y * b.z) - (a.z * b.y));
            float newY = -1 * ((a.x * b.z) - (a.z * b.x));
            float newZ =  1 * ((a.x * b.y) - (a.y * b.x));
            return new Vec3(newX, newY, newZ);
        }
        public static float Distance(Vec3 a, Vec3 b)
        {
            return Mathf.Sqrt((Mathf.Pow((a.x - b.x), 2)) + (Mathf.Pow((a.y - b.y), 2)) + (Mathf.Pow((a.z - b.z), 2)));
        }
        public static float Dot(Vec3 a, Vec3 b)
        {
            return ((a.x * b.x) + (a.y * b.y) + (a.z * b.z));
        }
        public static Vec3 Lerp(Vec3 a, Vec3 b, float t)
        {
            t = Mathf.Clamp(t, 0, 1);
            return new Vec3((a * (1 - t) + b * t));
        }
        public static Vec3 LerpUnclamped(Vec3 a, Vec3 b, float t)
        {
            return new Vec3((a * (1 - t) + b * t));
        }
        public static Vec3 Max(Vec3 a, Vec3 b)
        {
            float newX, newY, newZ;
            if (a.x > b.x)
                newX = a.x;
            else
                newX = b.x;
            if (a.y > b.y)
                newY = a.y;
            else
                newY = b.y;
            if (a.z > b.z)
                newZ = a.z;
            else
                newZ = b.z;
            return new Vec3(newX,newY,newZ);
        }
        public static Vec3 Min(Vec3 a, Vec3 b)
        {
            float newX, newY, newZ;
            if (a.x < b.x)
                newX = a.x;
            else
                newX = b.x;
            if (a.y < b.y)
                newY = a.y;
            else
                newY = b.y;
            if (a.z < b.z)
                newZ = a.z;
            else
                newZ = b.z;
            return new Vec3(newX, newY, newZ);
        }
        public static float SqrMagnitude(Vec3 vector)
        {
            return Mathf.Sqrt(Magnitude(vector));
        }
        public static Vec3 Project(Vec3 vector, Vec3 onNormal)
        {
            return (Dot(vector, onNormal) / Mathf.Pow(Magnitude(onNormal), 2) * onNormal);
        }
        public static Vec3 Reflect(Vec3 inDirection, Vec3 inNormal)
        {
            inNormal.Normalize();
            return inDirection - 2 * (-Dot(inDirection, inNormal)) * inNormal;
        }
        public void Set(float newX, float newY, float newZ)
        {
            x = newX;
            y = newY;
            z = newZ;
        }
        public void Scale(Vec3 scale)
        {
            Set(x * scale.x, y * scale.y, z * scale.z);
        }
        public void Normalize()
        {
            Set(normalized.x, normalized.y, normalized.z);
        }
        #endregion

        #region Internals
        public override bool Equals(object other)
        {
            if (!(other is Vec3)) return false;
            return Equals((Vec3)other);
        }

        public bool Equals(Vec3 other)
        {
            return x == other.x && y == other.y && z == other.z;
        }

        public override int GetHashCode()
        {
            int hashCode = -1636739968;
            hashCode = hashCode * -1521134295 + x.GetHashCode();
            hashCode = hashCode * -1521134295 + y.GetHashCode();
            hashCode = hashCode * -1521134295 + z.GetHashCode();
            hashCode = hashCode * -1521134295 + sqrMagnitude.GetHashCode();
            hashCode = hashCode * -1521134295 + normalized.GetHashCode();
            hashCode = hashCode * -1521134295 + magnitude.GetHashCode();
            hashCode = hashCode * -1521134295 + convertVec.GetHashCode();
            return hashCode;
        }
        #endregion
    }
}