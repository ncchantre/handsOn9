// See https://aka.ms/new-console-template for more information
using System.Security.Permissions;
using System.Transactions;


public enum loggingLevel
{
    COMMENT,
    WARNING,
    ERROR
}

class ConsoleLogger
{
    //class attributes
    private static ConsoleLogger? instance;
    private static readonly object obj = new object();

    //Constructor made private to prevent instantiaions from outside this class
    private ConsoleLogger()
    {

    }

    public static ConsoleLogger GetInstance()
    {
        if(instance == null)
        {
            lock(obj)
            {
                if(instance == null)
                {
                    instance = new ConsoleLogger();
                }
            }
        }

        return instance;
    }

    public void Log(loggingLevel logLevel, string message)
    {
        switch (logLevel)
        {
            case loggingLevel.COMMENT:
                Console.WriteLine($"COMMENT:  {message}");
                break;
            
            case loggingLevel.WARNING:
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"WARNING: {message}");
                Console.ResetColor();
                break;
            
            case loggingLevel.ERROR:
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"ERROR: {message}");
                Console.ResetColor();
                Environment.Exit(1);
                break;

            default:
                Console.WriteLine("Unknown log level");
                break;
        }
    }

}


public static class ConsoleLoggerStatic
{
    public static void Log(loggingLevel logLevel, string message)
    {
        switch(logLevel)
        {
            case loggingLevel.COMMENT:
                Console.WriteLine($"COMMENT:  {message}");
                break;

            case loggingLevel.WARNING:
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"WARNING: {message}");
                Console.ResetColor();
                break;

            case loggingLevel.ERROR:
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"ERROR: {message}");
                Console.ResetColor();
                Environment.Exit(1);
                break;

        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        ConsoleLogger logger = ConsoleLogger.GetInstance();

        Console.WriteLine("\nSINGLETON IMPLEMENTATION:\n");

        logger.Log(loggingLevel.COMMENT, "Testing Comment");
        logger.Log(loggingLevel.WARNING, "Testing Warning");
        logger.Log(loggingLevel.ERROR, "Testing Error");

        //NOTE: To test the below code, the Error test case froj above must be commented out
        // to prevent terminating the applciation upon printing an ERROR message
        Console.WriteLine("STATIC IMPLEMENTATION:\n");
        
        ConsoleLoggerStatic.Log(loggingLevel.COMMENT, "Testing Comment");
        ConsoleLoggerStatic.Log(loggingLevel.WARNING, "Testing Warning");
        ConsoleLoggerStatic.Log(loggingLevel.ERROR, "Testing Error");

        //NOTE: Static implementation is preffered as it allows access from anywhere in the program whiout the catch of needing to wait for the instance to be
        // released by some other thread. Static is more useful as in real world applications, most programs are multithreaded
    }
}