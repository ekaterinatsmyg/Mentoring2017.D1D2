
namespace MentoringD1D2.Patterns.Task2.Elements
{
    public class Square : IElement
    {
        private int _height;
        private int _width;

        public Square(int height, int width)
        {
            _height = height;
            _width = width;
        }
        public void Draw(Context context)
        {
            
        }

        public bool Equals(IElement other)
        {
            if (other == null)
                return false;

            if (object.ReferenceEquals(this, other))
                return true;

            Square square = other as Square;

            if (square == null)
                return false;

            return _height == square._height && _width == square._width;
        }
    }
}
