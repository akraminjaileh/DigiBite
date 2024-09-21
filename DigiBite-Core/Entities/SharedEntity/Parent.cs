namespace DigiBite_Core.Models.SharedEntity
{
    public abstract class Parent
    {
        public int Id { get; set; }
        public bool? IsActive { get; set; }
        public DateTime CreationDateTime { get; set; }
        public string CreatedBy { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedDateTime { get; set; }

    }
}
