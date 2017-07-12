using System;
using System.Collections.Generic;

namespace MentoringD1D2.Patterns.Task2.Elements
{
    public class Picture : IElement
    {
        private List<IElement> _childrens;

        public Picture()
        {
            _childrens = new List<IElement>();
        }

        public void AddElement(IElement element)
        {
            _childrens.Add(element);
        }

        public bool RemoveElement(IElement element)
        {
            return _childrens.Remove(element);
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

            Picture picture = other as Picture;

            if (picture == null)
                return false;

            return _childrens == picture._childrens;
        }
    }
}
