namespace zip_extract_compress._zip
{
  using System;
  using System.IO;
  using System.IO.Compression;
  public class _1_Compress_and_extract_files
  {

    public _1_Compress_and_extract_files()
    {
      _1_Create_and_extract_a_zip_file();
      _2_Extract_specific_file_extensions();
      _3_Add_a_file_to_an_existing_zip();
      _4_Compress_and_decompress_gz_files();
    }

    /// Example 1: Create and extract a .zip file
    /// 	The following example shows how to create and extract a compressed .zip file by using the ZipFile class. The example compresses the contents of a folder into a new .zip file, and then extracts the zip to a new folder.
    /// 	To run the sample, create a start folder in your program folder and populate it with files to zip.
    /// 	If you get the build error "The name 'ZipFile' does not exist in the current context," add a reference to the System.IO.Compression.FileSystem assembly to your project.
    public void _1_Create_and_extract_a_zip_file()
    {
      string startPath = @".\_zip";
      string zipPath = @".\new_zip.zip";
      string extractPath = @".\extract";

      ZipFile.CreateFromDirectory(startPath, zipPath);
      ZipFile.ExtractToDirectory(zipPath, extractPath);

      // file(s) to delete in extractPath
      string[] filePaths = Directory.GetFiles(extractPath);
      foreach (string filePath in filePaths)
      {
        File.Delete(filePath);
        Console.WriteLine("Delete file: {0}", filePath);
      }

      // zip to delete
      File.Delete(zipPath);
      Console.WriteLine("Delete zip file: {0}", zipPath);
      Console.WriteLine();
    }


    /// Example 2: Extract specific file extensions
    ///   The next example iterates through the contents of an existing .zip file 
    ///     and extracts files that have a .txt extension. It uses the ZipArchive class 
    ///     to access the zip, and the ZipArchiveEntry class to inspect the individual entries. 
    ///     The extension method ExtractToFile for the ZipArchiveEntry object is available  in the System.IO.Compression.ZipFileExtensions class.
    ///   To run the sample, place a .zip file called result.zip in your program folder. 
    ///   When prompted, provide a folder name to extract to.
    ///   If you get the build error "The name 'ZipFile' does not exist in the current context,
    ///     add a reference to the System.IO.Compression.FileSystem assembly to your project.
    ///   If you get the error "The type 'ZipArchive' is defined in an assembly 
    ///     that is not referenced," add a reference to the System.IO.Compression assembly to your project.
    /// Important
    ///   When unzipping files, you must look for malicious file paths, which can escape out of the directory you unzip into. This is known as a path traversal attack. The following example demonstrates how to check for malicious file paths and provides a safe way to unzip.
    public void _2_Extract_specific_file_extensions()
    {
      string zipPath = @".\result.zip";

      //Console.WriteLine("Provide path where to extract the zip file:");
      string extractPath = @".\extract";
      //string extractPath = Console.ReadLine();

      // Normalizes the path.
      extractPath = Path.GetFullPath(extractPath);

      // Ensures that the last character on the extraction path
      // is the directory separator char. 
      // Without this, a malicious zip file could try to traverse outside 
      // of the expected extraction path.
      if (!extractPath.EndsWith(Path.DirectorySeparatorChar.ToString(), StringComparison.Ordinal))
        extractPath += Path.DirectorySeparatorChar;

      using (ZipArchive archive = ZipFile.OpenRead(zipPath))
      {
        foreach (ZipArchiveEntry entry in archive.Entries)
        {
          if (entry.FullName.EndsWith(".txt", StringComparison.OrdinalIgnoreCase))
          {
            // Gets the full path to ensure that relative segments are removed.
            string destinationPath = Path.GetFullPath(Path.Combine(extractPath, entry.FullName));

            // Ordinal match is safest, case-sensitive volumes can be mounted within volumes that
            // are case-insensitive.
            if (destinationPath.StartsWith(extractPath, StringComparison.Ordinal))
              entry.ExtractToFile(destinationPath);
          }
        }
      }
    }


    /// Example 3: Add a file to an existing zip
    ///  The following example uses the ZipArchive class to access an existing .zip file, 
    ///  and adds a file to it. The new file gets compressed when you add it 
    ///  to the existing zip.
    public void _3_Add_a_file_to_an_existing_zip()
    {
      string zipPath = @".\result.zip";
      string zipPathDest = @".\resultDest.zip";
      File.Delete(zipPathDest);
      File.Copy(zipPath, zipPathDest);
      using (FileStream zipToOpen = new FileStream(zipPathDest, FileMode.Open))
      {
        using (ZipArchive archive = new ZipArchive(zipToOpen, ZipArchiveMode.Update))
        {
          ZipArchiveEntry readmeEntry = archive.CreateEntry("Readme.txt");
          using (StreamWriter writer = new StreamWriter(readmeEntry.Open()))
          {
            writer.WriteLine("Information about this package.");
            writer.WriteLine("========================");
          }
        }
      }
    }


    /// Example 4: Compress and decompress .gz files
    ///   You can also use the GZipStream and DeflateStream classes to compress 
    ///   and decompress data. They use the same compression algorithm. 
    ///   You can decompress GZipStream objects that are written to a .gz file 
    ///   by using many common tools. The following example shows how to compress 
    ///   and decompress a directory of files by using the GZipStream class:
    private string directoryPath = @".\temp";
    public void _4_Compress_and_decompress_gz_files()
    {
      DirectoryInfo directorySelected = new DirectoryInfo(directoryPath);
      Compress(directorySelected);

      foreach (FileInfo fileToDecompress in directorySelected.GetFiles("*.gz"))
      {
        Decompress(fileToDecompress);
      }
    }

    public void Compress(DirectoryInfo directorySelected)
    {
      foreach (FileInfo fileToCompress in directorySelected.GetFiles())
      {
        using (FileStream originalFileStream = fileToCompress.OpenRead())
        {
          if ((File.GetAttributes(fileToCompress.FullName) &
             FileAttributes.Hidden) != FileAttributes.Hidden & fileToCompress.Extension != ".gz")
          {
            using (FileStream compressedFileStream = File.Create(fileToCompress.FullName + ".gz"))
            {
              using (GZipStream compressionStream = new GZipStream(compressedFileStream,
                 CompressionMode.Compress))
              {
                originalFileStream.CopyTo(compressionStream);

              }
            }
            FileInfo info = new FileInfo(directoryPath + Path.DirectorySeparatorChar + fileToCompress.Name + ".gz");
            Console.WriteLine($"Compressed {fileToCompress.Name} from {fileToCompress.Length.ToString()} to {info.Length.ToString()} bytes.");
          }

        }
      }
    }

    public void Decompress(FileInfo fileToDecompress)
    {
      using (FileStream originalFileStream = fileToDecompress.OpenRead())
      {
        string currentFileName = fileToDecompress.FullName;
        string newFileName = currentFileName.Remove(currentFileName.Length - fileToDecompress.Extension.Length);

        using (FileStream decompressedFileStream = File.Create(newFileName))
        {
          using (GZipStream decompressionStream = new GZipStream(originalFileStream, CompressionMode.Decompress))
          {
            decompressionStream.CopyTo(decompressedFileStream);
            Console.WriteLine($"Decompressed: {fileToDecompress.Name}");
          }
        }
      }

    }
  }
}