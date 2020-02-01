using System;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace test.XML
{
  public class XDocument_WriteTo_XmlWriter
  {
    public XDocument_WriteTo_XmlWriter(bool indent)
    {
      Metoda_1(indent);
    }

    public void Metoda_1(bool indent)
    {
      StringBuilder sb = new StringBuilder();
      XmlWriterSettings xws = new XmlWriterSettings();
      xws.OmitXmlDeclaration = true;
      // xws.Indent = true;  
      // xws.Indent = false;
      xws.Indent = indent;

      using (XmlWriter xw = XmlWriter.Create(sb, xws))
      {
        XDocument doc = new XDocument(
            new XElement("Child",
                new XElement("GrandChild", "some content")
            )
        );
        doc.WriteTo(xw);
      }
      Console.WriteLine();
      Console.WriteLine("-----------------------");
      Console.WriteLine("XML {0} indent", indent ? "with": "without");
      Console.WriteLine(sb.ToString());
    }


  }
}