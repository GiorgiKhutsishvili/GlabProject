using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace GLab.Models
{
    public class RegistrationModel
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "ჩაწერეთ სახელი")]
        public string Name { get; set; }

        [Required(ErrorMessage = "ჩაწერეთ გვარი")]
        public string Surname { get; set; }


        [Required(ErrorMessage = "ჩაწერეთ ელ.ფოსტა")]
        [DataType(DataType.EmailAddress)]
        [StringLength(50, ErrorMessage = "ჩაწერილი ელ.ფოსტა არ უნდა აღემატებოდეს 50 სიმბოლოს")]
        [EmailAddress(ErrorMessage = "გთხოვთ ჩაწეროთ სწორედ ელ.ფოსტის მისამართ")]
        [RegularExpression("^[a-z0-9_\\+-]+(\\.[a-z0-9_\\+-]+)*@[a-z0-9-]+(\\.[a-z0-9]+‌​)*\\.([a-z]{2,4})$", ErrorMessage = "ელ.ფოსტის ფორმატი არასწორია.")]
        public string Email { get; set; }


        [DataType(DataType.Password)]
        [StringLength(255, MinimumLength = 8, ErrorMessage = "პაროლი უნდა შედგებოდეს მინიმუმ 8 სიმბოლოსგან და მაქსიმუმ 16 სიმბოლოსგან")]
        [Required(ErrorMessage = "ჩაწერეთ პაროლი")]
        public string Password { get; set; }


        [Compare("Password", ErrorMessage = "პაროლები არ ემთხვევა")]
        [DataType(DataType.Password)]
        [StringLength(255, MinimumLength = 8, ErrorMessage = "პაროლი უნდა შედგებოდეს მინიმუმ 8 სიმბოლოსგან და მაქსიმუმ 16 სიმბოლოსგან")]
        [Required(ErrorMessage = "გაიმეორეთ პაროლი")]
        public string RepeatPassword { get; set; }
    }
}