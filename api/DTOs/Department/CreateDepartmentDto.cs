namespace api.DTOs.Department
{
    public class CreateDepartmentDto
    {
        public string Name { get; set; } = null!;
        public string? Code { get; set; }
    }
}