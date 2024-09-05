namespace MilkyProject.WebUi.Dtos.AdressDtos
{
    public class UpdateAdressDto
    {
        public int AdressId { get; set; }
        public string AdressDetail { get; set; }
        public string Phone { get; set; }
        public string Mail { get; set; }
        public string Weekdays { get; set; }
        public string Saturday { get; set; }
        public string Sunday { get; set; }
    }
}
