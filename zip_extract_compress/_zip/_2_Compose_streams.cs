using System;
using System.IO;

namespace zip_extract_compress._zip
{
  public class _2_Compose_streams
  {
    public _2_Compose_streams()
    {
      a_Use_StreamReader();
      b_Use_BinaryReader();
    }

    private const string FILE_NAME = "MyFile.txt";

    /// The following example creates a StreamReader to read characters 
    /// from the FileStream, which is passed to the StreamReader 
    /// as its constructor argument. StreamReader.ReadLine then reads 
    /// until StreamReader.Peek finds no more characters.
    public void a_Use_StreamReader()
    {
      if (!File.Exists(FILE_NAME))
      {
        Console.WriteLine($"{FILE_NAME} does not exist!");
        return;
      }
      FileStream fsIn = new FileStream(FILE_NAME, FileMode.Open,
          FileAccess.Read, FileShare.Read);
      // Create an instance of StreamReader that can read
      // characters from the FileStream.
      using (StreamReader sr = new StreamReader(fsIn))
      {
        string input;
        // While not at the end of the file, read lines from the file.
        while (sr.Peek() > -1)
        {
          input = sr.ReadLine();
          Console.WriteLine(input);
        }
      }
    }

    /// The following example creates a BinaryReader to read bytes from the FileStream, 
    /// which is passed to the BinaryReader as its constructor argument. 
    /// ReadByte then reads until PeekChar finds no more bytes.
    public void b_Use_BinaryReader()
    {
      if (!File.Exists(FILE_NAME))
      {
        Console.WriteLine($"{FILE_NAME} does not exist.");
        return;
      }
      FileStream f = new FileStream(FILE_NAME, FileMode.Open,
          FileAccess.Read, FileShare.Read);
      // Create an instance of BinaryReader that can
      // read bytes from the FileStream.
      using (BinaryReader br = new BinaryReader(f))
      {
        byte input;
        bool newLine = false;
        // While not at the end of the file, read lines from the file.
        while (br.PeekChar() > -1)
        {
          input = br.ReadByte();
          if (newLine) {
            Console.WriteLine(input);
            newLine = false;
          }
          else if (input == 13) {
            newLine = true;
            Console.Write(input);
          }
          else
            Console.Write(input);
        }
      }
    }

  }
}