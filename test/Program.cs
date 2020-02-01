using System;
using test.XML;

namespace test
{
  class Program
  {
    static void Main(string[] args)
    {
      // DumpFileSample
      // Console.WriteLine("Hello World!");

      XDocument_WriteTo_XmlWriter writeTo 
        = new XDocument_WriteTo_XmlWriter(true);
      XDocument_WriteTo_XmlWriter writeTo2 
        = new XDocument_WriteTo_XmlWriter(false);
    }
  }
}
