public class LogAnalyzer
{
    public static void Start()
    {

        string[] logs = {   "2023-11-12 08:30:00 INFO Application started successfully",
                            "2023-11-12 08:45:23 WARNING Low memory warning detected",
                            "2023-11-12 09:15:45 ERROR Failed to connect to database",
                            "2023-11-12 09:45:10 INFO User 'admin' logged in",
                            "2023-11-12 10:00:00 ERROR Unexpected exception occurred",
                            "2023-11-12 10:30:33 WARNING Disk space is almost full",
                            "2023-11-12 11:00:05 INFO New user 'john_doe' created",
                            "2023-11-12 11:30:00 INFO Scheduled maintenance started",
                            "2023-11-12 12:00:00 ERROR Email service is not responding",
                            "2023-11-12 12:30:45 WARNING High CPU usage detected"
                        };

        for (int i = 0; i < logs.Length; i++)
        {
            string subLog = logs[i]; //2023-11-12 08:30:00 INFO Application started successfully
            string date = "Дата: " + subLog.Remove(subLog.IndexOf(" "));

            subLog = subLog.Substring(subLog.IndexOf(" ")).Trim(); //08:30:00 INFO Application started successfully
            string time = "Время: " + subLog.Substring(0, subLog.IndexOf(" "));

            subLog = subLog.Substring(subLog.IndexOf(" ")).Trim(); //INFO Application started successfully
            string level = "Уровень: " + subLog.Substring(0, subLog.IndexOf(" "));

            subLog = subLog.Substring(subLog.IndexOf(" ")).Trim(); //Application started successfully
            string message = "Сообщение: " + subLog;

            Console.WriteLine($"{date}, {time}, {level}, {message}.");
        }

        // the end of the code    
    }
}