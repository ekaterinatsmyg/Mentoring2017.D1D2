using System;

namespace MentoringD1D2.Patterns.Task1
{
    public sealed class Singleton
    {
        private static readonly Lazy<Singleton> Lazy =
       new Lazy<Singleton>(() => new Singleton());

        public static Singleton Instance => Lazy.Value;

        private Singleton()
        {
        }
    }
}
