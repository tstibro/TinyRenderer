using System;
namespace TinyRendererLib.GeometryDataStructures.Vectors
{
    public struct Vector4f
    {
		public float x, y, z, w;

		public Vector4f(float x, float y, float z, float w)
        {
            this.x = x;
            this.y = y;
            this.z = z;
			this.w = w;
        }

		public static Vector4f operator +(Vector4f v1, Vector4f v2)
        {
            return new Vector4f(v1.x + v2.x, v1.y + v2.y, v1.z + v2.z, v1.w + v2.w);
        }

		public static Vector4f operator -(Vector4f v1, Vector4f v2)
        {
            return new Vector4f(v1.x - v2.x, v1.y - v2.y, v1.z - v2.z, v1.w - v2.w);
        }

		public static Vector4f operator *(Vector4f v1, Vector4f v2)
        {
            return new Vector4f(v1.x * v2.x, v1.y * v2.y, v1.z * v2.z, v1.w * v2.w);
        }

		public static Vector4f operator /(Vector4f v1, Vector4f v2)
        {
            return new Vector4f(v1.x / v2.x, v1.y / v2.y, v1.z / v2.z, v1.w / v2.w);
        }

		public static Vector4f operator *(Vector4f v1, float c)
        {
            return new Vector4f(v1.x * c, v1.y * c, v1.z * c, v1.w * c);
        }
    }
}
