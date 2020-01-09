using System;
using System.IO.Compression;
using zip_extract_compress._zip;

namespace zip_extract_compress
{
  class Program
  {
    static void Main(string[] args)
    {
      _1_Compress_and_extract_files _1 = new _1_Compress_and_extract_files();
      _2_Compose_streams _2 = new _2_Compose_streams();
    }
  }
}
