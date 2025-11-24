public class SqlFile
{
   public string FilePath {get;set;}
   public string FileText {get;set;}
   public string LoadText()
   {
      /* Code to read text from sql file */
   }
   public string SaveText()
   {
      /* Code to save text into sql file */
   }
}

public class SqlFileManager
{
   public List<SqlFile> lstSqlFiles {get;set}

   public string GetTextFromFiles()
   {
      StringBuilder objStrBuilder = new StringBuilder();
      foreach(var objFile in lstSqlFiles)
      {
         objStrBuilder.Append(objFile.LoadText());
      }
      return objStrBuilder.ToString();
   }
   public void SaveTextIntoFiles()
   {
      foreach(var objFile in lstSqlFiles)
      {
         objFile.SaveText();
      }
   }
}

// After our leaders tells us what to do:

public class ReadOnlySqlFile
{
   string FilePath { get; set; }
   string FileText { get; set; }

   public string LoadText()
   {
      // Code to read text from an SQL file
   }
}
public class SqlFileManager
{
   public List<SqlFile> lstSqlFiles {get;set;}
   public string GetTextFromFiles()
   {
      StringBuilder objStrBuilder = new StringBuilder();
      foreach(var objFile in lstSqlFiles)
      {
         objStrBuilder.Append(objFile.LoadText());
      }
      return objStrBuilder.ToString();
   }
   public void SaveTextIntoFiles()
   {
      foreach(var objFile in lstSqlFiles)
      {
         //Check whether the current file object is read-only or not.If yes, skip calling it's
         // SaveText() method to skip the exception.

         if(! objFile is ReadOnlySqlFile)
         objFile.SaveText();
      }
   }
}
// Here we altered the SaveTextIntoFiles() method in the SqlFileManager class to determine whether or not the instance is of ReadOnlySqlFile to avoid the exception. 
// We can't use this ReadOnlySqlFile class as a substitute for its parent without altering the SqlFileManager code. 
// So we can say that this design is not following LSP. Let's make this design follow the LSP. Here we will introduce interfaces to make the SqlFileManager class independent from the rest of the blocks.

public interface IWritableSqlFile
{
   string LoadText();
}

public interface IReadableSqlFile
{
   void SaveText();
}

// Now we implement IReadableSqlFile through the ReadOnlySqlFile class that reads only the text from read-only files. 
// We implement both IWritableSqlFile and IReadableSqlFile in a SqlFile class by which we can read and write files.

public class ReadOnlySqlFile : IReadableSqlFile
{
   string FilePath { get; set; }
   string FileText { get; set; }

   public string LoadText()
   {
      // Code to read text from an SQL file
   }
}

public class SqlFile: IWritableSqlFile,IReadableSqlFile
{
   public string FilePath {get;set;}
   public string FileText {get;set;}
   public string LoadText()
   {
      /* Code to read text from sql file */
   }
   public void SaveText()
   {
      /* Code to save text into sql file */
   }
}

// Now the design of the SqlFileManager class becomes like this.

public class SqlFileManager
{
   public string GetTextFromFiles(List<IReadableSqlFile> aLstReadableFiles)
   {
      StringBuilder objStrBuilder = new StringBuilder();
      foreach(var objFile in aLstReadableFiles)
      {
         objStrBuilder.Append(objFile.LoadText());
      }
      return objStrBuilder.ToString();
   }
   public void SaveTextIntoFiles(List<IWritableSqlFile> aLstWritableFiles)
   {
      foreach(var objFile in aLstWritableFiles)
      {
         objFile.SaveText();
      }
   }
}

// Here the GetTextFromFiles() method gets only the list of instances of classes that implement the IReadOnlySqlFile interface. 
// That means the SqlFile and ReadOnlySqlFile class instances. And the SaveTextIntoFiles() method gets only the list instances of the class that implements the IWritableSqlFiles interface, in this case, SqlFile instances. 
// So now we can say our design is following the LSP. And we fixed the problem using the Interface segregation principle (ISP), identifying the abstraction and the responsibility separation method.