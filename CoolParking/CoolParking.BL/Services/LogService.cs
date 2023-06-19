// TODO: implement the LogService class from the ILogService interface.
//       One explicit requirement - for the read method, if the file is not found, an InvalidOperationException should be thrown
//       Other implementation details are up to you, they just have to match the interface requirements
//       and tests, for example, in LogServiceTests you can find the necessary constructor format.

// TODO: реалізувати клас LogService з інтерфейсу ILogService.
// Одна явна вимога - для методу читання, якщо файл не знайдено, має бути викинуто InvalidOperationException
// Інші деталі впровадження вирішувати вам, вони просто мають відповідати вимогам інтерфейсу
// і тести, наприклад, в LogServiceTests можна знайти необхідний формат конструктора.

using CoolParking.BL.Interfaces;

namespace CoolParking.BL.Services
{
    public class LogService : ILogService
    {
        private string _logPath;
        public string LogPath => _logPath;
        public LogService(string logPath)
        {
            _logPath = logPath;
        }

        public string Read()
        {
            throw new System.NotImplementedException();
        }

        public void Write(string logInfo)
        {
            throw new System.NotImplementedException();
        }
    }
}
