using System.ComponentModel.DataAnnotations;

namespace Task4.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }

        [
            MinLength(5, ErrorMessage ="The Author must more than 5 char!"),
            Required(ErrorMessage ="This field should not be empty!")
        ]
        public string Author { get; set; }

        [
            MinLength(5, ErrorMessage ="The Title must more than 5 char!"),
            Required(ErrorMessage ="This field should not be empty")
        ]
        public string Title { get; set; }

        [
            MinLength(5, ErrorMessage = "The Category must more than 5 char!"),
            Required(ErrorMessage ="This field should not be empty!")
        ]
        public string Category { get; set; }

        [
            Required(ErrorMessage ="This field should not be empty!"),
            DataType(DataType.Currency)
        ]
        public decimal Price { get; set; }
    }
}