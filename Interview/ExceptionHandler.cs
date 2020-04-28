using System;
using System.Text;

namespace Interview
{
    public class ExceptionHandler
    {
        public static void Handle(Exception exception)
        {
            var builder = new StringBuilder();
            builder.AppendLine($"Exception: {exception.GetType().Name}");
            builder.AppendLine($"Message: {exception.Message}");
            builder.AppendLine($"StackTrace: {exception.StackTrace}");
            Console.WriteLine(builder.ToString());
        } 
    }
}