
namespace MentoringD1D2.Patterns.Task2.Elements
{
    public class Point : IElement
    {
        public void Draw(Context context)
        {
            
        }

        public bool Equals(IElement other)
        {
            return object.ReferenceEquals(this, other);
        }
    }
}
