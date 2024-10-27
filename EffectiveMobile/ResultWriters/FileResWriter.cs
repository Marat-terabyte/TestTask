using EffectiveMobile.DataReaders.Database.Models;
using EffectiveMobile.Loggers;
using System.Text;

namespace EffectiveMobile.ResultWriters
{
    internal class FileResWriter : IResultWriter<Order>
    {
        private bool _disposed;
        
        private Stream _stream;
        private ILogger _logger;

        public string FileResult { get => "_deliveryOrder"; }

        public FileResWriter(ILogger logger)
        {
            _logger = logger;
            _stream = new FileStream(FileResult, FileMode.Create);
        }

        public void Write(ICollection<Order> values)
        {
            try
            {
                WriteOrders(values);
                _logger.Log($"info: {DateTime.Now} All orders have wrote to the file result");
            }
            catch (Exception ex)
            {
                _logger.Log($"error: {DateTime.Now} {ex.Message}");
            }
        }

        private async void WriteOrders(ICollection<Order> values)
        {
            foreach (Order order in values)
            {
                await _stream.WriteAsync(Encoding.UTF8.GetBytes(order.ToString() + '\n'));
            }
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _stream.Dispose();
                }

                _disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
