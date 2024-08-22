namespace MilkyProject.WebUi.Dtos.EmployeeDtos
{
    public class ResultEmployeWithJobDto
    {
        public int EmployeId { get; set; }
        public string EmployeName { get; set; }
        public string ImageUrl { get; set; }

        public int? JobId { get; set; }
        public Job job { get; set; }

        public class Job
        {
            public string JobName { get; set; }
        }
    }
}
