namespace EffectiveMobile.ResultWriters
{
    internal interface IResultWriter<T> : IDisposable
    {
        public void Write(IEnumerable<T> values);
    }
}
