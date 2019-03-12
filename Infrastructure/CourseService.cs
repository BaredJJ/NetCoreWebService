using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using WebService.Models;

namespace WebService.Infrastructure
{
    public class CourseService
    {
        private readonly Uri _uri;
        private readonly CourseReader _reader;

        public CourseService()
        {
             Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            _uri = new Uri(@"http://www.cbr.ru/scripts/XML_daily.asp");
            _reader = new CourseReader();
        }

        public CurrentCurrency GetCurrentCourse()
        {
            var stream = Task.Run(async () => await _reader.GetRequest(_uri));           
            return ParseResponse(stream.Result);
        }

        public CurrentCurrency ParseResponse(Stream stream)
        {
            var currentCourse = new CurrentCurrency();
            using (var xmlReader = XmlReader.Create(stream, new XmlReaderSettings()))
            {
                xmlReader.MoveToContent();
                currentCourse.Date = DateTime.Parse(xmlReader["Date"]);
                xmlReader.ReadStartElement("ValCurs");
                for (int i = 0; i < 34; ++i)
                {

                        xmlReader.ReadStartElement("Valute");
                    var currency = new Currency
                    {
                        NumCode = xmlReader.ReadElementContentAsInt(),
                        CharCode = xmlReader.ReadElementContentAsString(),
                        Nominal = xmlReader.ReadElementContentAsDouble(),
                        Name = xmlReader.ReadElementContentAsString(),
                        Value = xmlReader.ReadElementContentAsString()
                    };
                    currentCourse.Currencies.Add(currency);
                        xmlReader.ReadEndElement();
                }
                xmlReader.ReadEndElement();
            }

            return currentCourse;
        }
    }
}
