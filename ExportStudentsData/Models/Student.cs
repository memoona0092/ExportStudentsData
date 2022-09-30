using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace ExportStudentsData.Models
{
    public class Student
    {
        public int StudentID { set; get; }
        [Display(Name ="Student Name")]
        [Required(ErrorMessage ="Student name is required")]
        public string StudentName { set; get; }
        [Display(Name = "Father Name")]
        [Required(ErrorMessage ="Father name is required")]
        public string FatherName { set; get; }
        [Display(Name = "Course")]
        public string CourseName { set; get; }
        [Display(Name = "Date of birth")]
        [DataType(DataType.Date)]
        public DateTime BirthDate { set; get; }
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage ="Email address is invalid")]
        public string Email { set; get; }
        [Required(ErrorMessage ="Adress is required")]
        public string Adrress { set; get; }
    }
    public class StudentDBContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
    }
}