using CsvHelper.Configuration.Attributes;

namespace WTUDataFeed
{
   public class FeedEntry
   {
      [Index(0)]
      public int ID { get; set; }

      [Index(1)]
      public string? Day { get; set; }

      [Index(2)]
      public string? Date { get; set; }

      [Index(3)]
      public string? Time { get; set; }

      [Index(4)]
      public string? Level { get; set; }

      [Index(5)]
      public string? Competition { get; set; }

      [Index(6)]
      public string? Ground { get; set; }

      [Index(8)]
      public string? Home { get; set; }

      [Index(9)]
      public string? Away { get; set; }

      [Index(10)]
      public string? Appointee { get; set; }

      [Index(13)]
      public string? Role { get; set; }

      public override string ToString()
      {
         return $"{ID}  {Day}  {Date}  {Time}  {Level}  {Competition}  {Ground}  {Home}  {Away}  {Appointee}  {Role}";
      }
   }
}
