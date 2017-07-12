using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MentoringD1D2.Patterns.Task2.Elements;

namespace MentoringD1D2.Patterns.Task2
{
    public class ElementFactory
    {
        private Point onePoint;
        private Dictionary<int, Circle> circles;
        private Dictionary<int, Square> squares;


        public Picture CreatePicture(IElement children)
        {
            var picture = new Picture();
            picture.AddElement(children);
            return picture;
        }

        public Circle CreateCircle(int radius)
        {
            if (circles == null)
            {
                circles = new Dictionary<int, Circle> { { radius, new Circle(radius) } };
            }
            if (circles[radius] == null)
            {
                circles.Add(radius, new Circle(radius));
            }

            return circles[radius];
        }

        public Square CreateSquare(int height, int width)
        {
            if (squares == null)
            {
                squares = new Dictionary<int, Square> {{height*10 + width, new Square(height, width)}};
            }
            if (squares[height * 10 + width] == null)
            {
                squares.Add(height * 10 + width, new Square(height, width));
            }

            return squares[height * 10 + width];
        }

        public Point CreatePoint()
        {
            return onePoint ?? (onePoint = new Point());
        }
    }
}
