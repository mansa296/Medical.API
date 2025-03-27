namespace Medical.Model.DTOs.Requests
{
    public class FilterRequest
    {
        public string? CompletenessType { get; set; }
        public string? ApplicationStatus { get; set; }
        public int? GroupId { get; set; }
        public int? WaveId { get; set; }
        public List<int> ApplicationIds { get; set; } = new List<int>();
    }
}
