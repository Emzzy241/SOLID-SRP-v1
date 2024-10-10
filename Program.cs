// The following classes provide the functionality to log a stack trace into a file. 

public class FileLogger
{
   public void LogMessage(string aStackTrace)
   {
      //code to log stack trace into a file.
   }
}
public class ExceptionLogger
{
   public void LogIntoFile(Exception aException)
   {
      FileLogger objFileLogger = new FileLogger();
      objFileLogger.LogMessage(GetUserReadableMessage(aException));
   }
   private GetUserReadableMessage(Exception ex)
   {
      string strMessage = string.Empty;
      //code to convert Exception's stack trace and message to user readable format.
    //   ....
    //   ....
      return strMessage;
   }
}

// Client file exports data from many files to a database
public class DataExporter
{
   public void ExportDataFromFile()
   {
   try {
      //code to export data from files to the database.
   }
   catch(Exception ex)
   {
      new ExceptionLogger().LogIntoFile(ex);
   }
}
}




// But our client wants to store this stack trace in a database if an IO exception occurs. Hmm... 
public class DbLogger
{
   public void LogMessage(string aMessage)
   {
      //Code to write message in the database.
   }
}
public class FileLogger
{
   public void LogMessage(string aStackTrace)
   {
      //code to log stack trace into a file.
   }
}
public class ExceptionLogger
{
   public void LogIntoFile(Exception aException)
   {
      FileLogger objFileLogger = new FileLogger();
      objFileLogger.LogMessage(GetUserReadableMessage(aException));
   }
   public void LogIntoDataBase(Exception aException)
   {
      DbLogger objDbLogger = new DbLogger();
      objDbLogger.LogMessage(GetUserReadableMessage(aException));
   }
   private string GetUserReadableMessage(Exception ex)
   {
      string strMessage = string.Empty;
      //code to convert Exception's stack trace and message to user readable format.
      ....
      ....
      return strMessage;
   }
}

public class DataExporter
{
   public void ExportDataFromFile()
   {
      try {
         //code to export data from files to database.
      }
      catch(IOException ex)
      {
         new ExceptionLogger().LogIntoDataBase(ex);
      }
      catch(Exception ex)
      {
         new ExceptionLogger().LogIntoFile(ex);
      }
   }
}

// Now our low-level classes need to implement this interface
.
public interface ILogger
{
   void LogMessage(string aString);
}

public class DbLogger: ILogger
{
   public void LogMessage(string aMessage)
   {
      //Code to write message in database.
   }
}
public class FileLogger: ILogger
{
   public void LogMessage(string aStackTrace)
   {
      //code to log stack trace into a file.
   }
}





public class ExceptionLogger
{
   private ILogger _logger;
   public ExceptionLogger(ILogger aLogger)
   {
      this._logger = aLogger;
   }
   public void LogException(Exception aException)
   {
      string strMessage = GetUserReadableMessage(aException);
      this._logger.LogMessage(strMessage);
   }
   private string GetUserReadableMessage(Exception aException)
   {
      string strMessage = string.Empty;
      //code to convert Exception's stack trace and message to user readable format.
      ....
      ....
      return strMessage;
   }
}
public class DataExporter
{
   public void ExportDataFromFile()
   {
      ExceptionLogger _exceptionLogger;
      try {
         //code to export data from files to database.
      }
      catch(IOException ex)
      {
         _exceptionLogger = new ExceptionLogger(new DbLogger());
         _exceptionLogger.LogException(ex);
      }
      catch(Exception ex)
      {
         _exceptionLogger = new ExceptionLogger(new FileLogger());
         _exceptionLogger.LogException(ex);
      }
   }
}


public class EventLogger: ILogger
{
   public void LogMessage(string aMessage)
   {
      //Code to write a message in system's event viewer.
   }
}

// 6