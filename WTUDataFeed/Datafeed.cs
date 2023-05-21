using CsvHelper;
using CsvHelper.Configuration;
using System.Globalization;

namespace WTUDataFeed
{
   public class Datafeed
   {
      public TextReader Reader { get; set; }
      public List<FeedEntry>? Entries { get; set; }
      public List<Fixture>? Fixtures { get; set; }

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

      public void Process()
      {
         Fixtures = new List<Fixture>();
         Fixture? fixture;
         foreach (FeedEntry entry in Entries)
         {
             fixture = Fixtures.Where(f => f.Date == entry.Date && f.Home == entry.Home && f.Away == entry.Away).FirstOrDefault();
            if (fixture == null)
            {
               fixture = new Fixture(entry.Date, entry.Home, entry.Away, entry.Ground);
               Fixtures.Add(fixture);
            }
            fixture.Appointments.Add(new Appointment(entry.Role, entry.Appointee));
         }
      }

   }
}