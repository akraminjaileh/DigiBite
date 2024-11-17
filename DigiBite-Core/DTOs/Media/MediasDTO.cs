using DigiBite_Core.Constant;

namespace DigiBite_Core.DTOs.Media
{
    public class MediasDTO
    {
        public int Id { get; set; }
        public string FileName { get; set; }
        public string ImageUrl { get; set; }
        public string AltText { get; set; }
        public int SizeKB { get; set; }
        public DateTime UploadedOn { get; set; }
        public string UploadedBy { get; set; }
        public string FileType { get; set; }
    }
}
