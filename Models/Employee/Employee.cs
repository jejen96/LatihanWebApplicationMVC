using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LatihanWebApplicationMVC.Models.Employee
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        public string Nama { get; set; }
        public string Alamat { get; set; }
        public string Usia { get; set; }
        public string TanggalLahir { get; set; }
    }
}
