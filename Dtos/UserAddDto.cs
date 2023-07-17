namespace SimpleCrudDotNetSix.Dtos
{
    public class UserAddDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public bool IsEmancipated { get; set; }
        public List<string> Affiliation { get; set; }
    }
}
