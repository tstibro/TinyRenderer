using System;
namespace TinyRendererLib.GeometryDataStructures.Vectors
{
    public struct Vector2f
    {
		public float x, y;

		public Vector2f(float x, float y)
		{
			this.x = x;
			this.y = y;
		}

		public static Vector2f operator +(Vector2f v1, Vector2f v2)
        {
			return new Vector2f(v1.x + v2.x, v1.y + v2.y);
        }

		public static Vector2f operator -(Vector2f v1, Vector2f v2)
        {
            return new Vector2f(v1.x - v2.x, v1.y - v2.y);
        }

		public static Vector2f operator *(Vector2f v1, Vector2f v2)
        {
            return new Vector2f(v1.x * v2.x, v1.y * v2.y);
        }

		public static Vector2f operator /(Vector2f v1, Vector2f v2)
        {
            return new Vector2f(v1.x / v2.x, v1.y / v2.y);
        }

		public static Vector2f operator *(Vector2f v1, float c)
        {
            return new Vector2f(v1.x * c, v1.y * c);
        }      
    }
}
