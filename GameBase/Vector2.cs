using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace br.com.bonus630.GameBase
{
    public class Vector2
    {
        private int x;

        public int X
        {
            get { return x; }
            set { x = value; }
        }
        private int y;

        public int Y
        {
            get { return y; }
            set { y = value; }
        }

        public Vector2()
        {

        }
        public Vector2(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
        public static Vector2 operator +(Vector2 vector ,Vector2 vector2)
        {
            Vector2 result = new Vector2();
            result.x = vector.x + vector2.x;
            result.y = vector.y + vector2.y;
            return result;
        }
        public static Vector2 operator -(Vector2 vector, Vector2 vector2)
        {
            Vector2 result = new Vector2();
            result.x = vector.x - vector2.x;
            result.y = vector.y - vector2.y;
            return result;
        }

    }
}
