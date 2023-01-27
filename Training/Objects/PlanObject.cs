namespace Training.Objects
{
    public abstract class PlanObject<T>
    {
        protected abstract int Count { get; }

        public PlanObject(ICollection<T> values)
        {
            if (values.Count != Count)
            {
                throw new ArgumentException("Values count does not match this object");
            }
        }
    }
}
