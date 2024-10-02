using DigiBite_Core.Constant;

namespace DigiBite_Core.Entities.Lookups
{
    public class Media
    {
        public int Id { get; set; }
        public string FileName { get; set; }
        public string ImageUrl { get; set; }
        public string AltText { get; set; }
        public int SizeKB { get; set; }
        public DateTime UploadedOn { get; set; }
        public string UploadedBy { get; set; }
        public FileType FileType { get; set; }

    }
}
