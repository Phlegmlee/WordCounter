using System.Xml.Serialization;

namespace WordCounter.Models
{
    public class LogItem
    {
        public long WordCount { get; set; }
        public long WordDiff { get; set; }
        public required string DateValue { get; set; }
        public required string NotesValue { get; set; }
    }
}
