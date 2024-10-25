namespace EffectiveMobile.ResultWriters
{
    internal interface IResultWriter<T> : IDisposable
    {
        public void Write(ICollection<T> values);
    }
}
