class FileManager : IDisposable
{
    private FileStream fileStream;
    private bool disposed = false;

    public FileManager(string filePath)
    {
        fileStream = new FileStream(filePath, FileMode.OpenOrCreate);
        Console.WriteLine("File stream opened.");
    }

    public void WriteToFile(string text)
    {
        byte[] data = System.Text.Encoding.ASCII.GetBytes(text);
        fileStream.Write(data, 0, data.Length);
        Console.WriteLine("Data written to file.");
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!disposed)
        {
            if (disposing)
            {
                // Dispose managed resources
                if (fileStream != null)
                {
                    fileStream.Close();
                    Console.WriteLine("File stream closed.");
                }
            }

            disposed = true;
        }
    }

    ~FileManager()
    {
        Dispose(false);
    }
}

class Program
{
    static void Main()
    {
        // Using FileManager with IDisposable pattern
        using (FileManager fileManager = new FileManager("example.txt"))
        {
            fileManager.WriteToFile("Hello, World!");
        } // Dispose method is called automatically here

        Console.WriteLine("End of program.");
    }
}
