using System;

namespace MentoringD1D2.Patterns.Task2.Elements
{
    public interface IElement : IEquatable<IElement>
    {
        void Draw(Context context);
    }
}
