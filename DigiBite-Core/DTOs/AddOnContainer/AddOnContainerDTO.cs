namespace DigiBite_Core.DTOs.AddOnContainer
{
    public class AddOnContainerDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<AddOnDTO> Addons { get; set; }
    }
}
