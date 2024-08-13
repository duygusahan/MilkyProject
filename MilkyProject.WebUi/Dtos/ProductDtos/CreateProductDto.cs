namespace MilkyProject.WebUi.Dtos.ProductDtos
{
    public class CreateProductDto
    {
      
        public string productName { get; set; }
        public int oldPrice { get; set; }
        public int newPrice { get; set; }
        public string imageUrl { get; set; }
        public bool status { get; set; }
    }
}
