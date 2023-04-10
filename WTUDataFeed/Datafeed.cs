using CsvHelper;
using CsvHelper.Configuration;
using System.Globalization;

namespace WTUDataFeed
{
   public class Datafeed
   {
      public TextReader Reader { get; set; }
      public List<FeedEntry>? Entries { get; set; }

      public Datafeed(TextReader reader)
      {
         Reader = reader;
      }

      public void Read()
      {
         CsvConfiguration configuration = new CsvConfiguration(CultureInfo.InvariantCulture)
         {
            HasHeaderRecord = false,
            MissingFieldFound = null
         };

         using CsvReader csvReader = new CsvReader(Reader, configuration);
         Entries = csvReader.GetRecords<FeedEntry>().ToList();
      }

   }
}