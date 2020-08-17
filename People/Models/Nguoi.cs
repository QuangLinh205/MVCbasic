using System;
using System.ComponentModel.DataAnnotations;

namespace People.Models
{
    public class Nguoi
    {
        [Display(Name="mã")]
        public int Id { get; set; }

        [Display(Name = "tên")]
        [StringLength(20, MinimumLength = 2)]
        [Required]
        public string Name { get; set; }

        [Display(Name="tuổi")]
        public int Age { get; set; }

        [Display(Name="địa chỉ")]
        [RegularExpression(@"^[A-Z]+[a-zA-Z''-'\s]*$")]
        
        [StringLength(30)]
        public string Address { get; set; }

        [Display(Name="sinh nhật")]// đổi tên hiển thị trên form
        [DataType(DataType.Date)] //đổi kiểu từ DateTime sang Date
        [DisplayFormat(DataFormatString = "{0:yyyy-mm-dd}", ApplyFormatInEditMode = true)]// format từ mm-dd-yyyy sang yyyy-mm-dd
        public DateTime BirthDay { get; set; }
    }
}
