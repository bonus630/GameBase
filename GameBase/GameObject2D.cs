using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace br.com.bonus630.GameBase
{
    public abstract class GameObject2D
    {
        private List<GameObject2D> children = new List<GameObject2D>();
        private Vector2 position = new Vector2(0, 0);
        public GameObject2D Parent { get; set;}
        public Vector2 Position { get => position; set => position = value; }
        
        public List<GameObject2D> Children { get => children; private set => children = value; }
        public Rectangle Bounds { get; set; }
        public Rectangle Collider { get; set; }
        public virtual void Update()
        {
            
            for (int i = 0; i < this.Children.Count; i++)
            {
                this.Children[i].Update();
            }
        }
        public void AddChildren( GameObject2D gameObject2D)
        {
            this.children.Add(gameObject2D);
            gameObject2D.Parent = this;
        }
        public virtual void Draw(Graphics graphics)
        {
            for (int i = 0; i < this.Children.Count; i++)
            {
                this.Children[i].Draw(graphics);
            }
        }
        public void Move(Vector2 vector2)
        {
            this.Position += vector2;
        }
        public virtual bool HitTest(GameObject2D otherGameObject)
        {
            if (this.Collider.IntersectsWith(otherGameObject.Collider))
                return true;
            return false;
        }
    }
}
