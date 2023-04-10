using WTUDataFeed;

namespace WTUDataFeedTests
{
   [TestClass]
   public class DatafeedTest
   {
      [TestMethod]
      public void LoadSampleFile()
      {
         Datafeed feed = new Datafeed(new StreamReader("sample.csv"));
         feed.Read();
         Assert.IsTrue(feed.Entries?.Count ==379);
      }
      
      [TestMethod]
      public async Task LoadURLFeed()
      {
         HttpClient client = new()
         {
            BaseAddress = new Uri(@"https://www.whostheumpire.com/data-feed.php?feed_id=81430476&dbtu=cricket&feed_format=csv&date=future&unconfirmed=1&show_time=1&title_row=1")
         };

         using HttpResponseMessage responseMessage = await client.GetAsync("");

         responseMessage.EnsureSuccessStatusCode();

         var response = await responseMessage.Content.ReadAsStringAsync();
         using StringReader reader = new StringReader(response);

         Datafeed feed = new Datafeed(reader);
         feed.Read();
         Assert.IsNotNull(feed.Entries);

      }

      
   }
}