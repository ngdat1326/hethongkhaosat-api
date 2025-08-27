namespace api.DTOs.User
{
    public class BulkUserActionRequest
    {
        public List<string> UserIds { get; set; } = new();
    }

    public class BulkSetActiveRequest : BulkUserActionRequest
    {
        public bool SetActive { get; set; }
    }
}
