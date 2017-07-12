using System;

namespace MentoringD1D2.Patterns.Task2.Elements
{
    public class Circle : IElement
    {
        private readonly int _radius;
        public Circle(int radius)
        {
            _radius = radius;
        }
        public void Draw(Context context)
        {
            throw new NotImplementedException();
        }

        public bool Equals(IElement other)
        {
            if (other == null)
                return false;

            if (object.ReferenceEquals(this, other))
                return true;

            Circle circle = other as Circle;

            if (circle == null)
                return false;

            return _radius == circle._radius;
        }
    }
}
