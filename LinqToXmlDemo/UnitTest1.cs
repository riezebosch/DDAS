using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Xml.Linq;
using System.Linq;

namespace LinqToXmlDemo
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            XNamespace xmlns = "urn:www-infosupport-com:ddas:linq2xml";
            Console.WriteLine(xmlns + "test");

            var doc = XDocument.Load("books.xml");

            foreach (var book in doc
                .Element(xmlns + "catalog")
                .Elements(xmlns + "book")
                .Where(e => (decimal?)e.Element(xmlns + "price") > 4m))
            {
                Console.WriteLine((string)book.Element(xmlns + "title"));
            }


            var prices = from book in doc.Element(xmlns + "catalog").Elements(xmlns + "book")
                         let price = (decimal?)book.Element(xmlns + "price") ?? 0
                         where price < 45
                         select new 
                         {
                             Title = (string)book.Element(xmlns + "title"), 
                             Price = price
                         };

            foreach (var price in prices)
            {
                Console.WriteLine("{0}: {1}", price.Title, price.Price);
            }

            doc.Descendants(xmlns + "book")
                .First(b => (string)b.Element(xmlns + "title") == "XML Developer's Guide")
                .Element(xmlns + "price")
                .Value = 23.ToString();

            doc.Save("book2.xml");
        }

        [TestMethod]
        public void CreateAFileWithLinqToXml()
        {
            XNamespace xmlns = "urn:www-infosupport-com:training:ddas:linq2xml";
            var doc = new XDocument(
                    new XElement(xmlns + "root",
                        //new XAttribute(XNamespace.Xmlns + "info", "urn:www-infosupport-com:training:ddas:linq2xml"),
                        new XElement(xmlns + "courses",
                            new XElement(xmlns + "course", new XAttribute("id", "DDAS"), "waarde van de training"),
                            new XElement(xmlns + "course", new XAttribute("id", "GIT")),
                            new XElement(xmlns + "course", new XAttribute("id", "TFS"))
                )));

            doc.Save("training.xml");
        }
    }
}
