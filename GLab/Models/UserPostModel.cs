using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace GLab.Models
{
    public class UserPostModel
    {
        public int ID { get; set; }
        public int UserID { get; set; }

        [Required(ErrorMessage = "ჩაწერეთ სიახლის სათაური")]
        public string NewsTitle { get; set; }

        [Required(ErrorMessage = "ჩაწერეთ ავტორის სახელი")]
        public string AuthorName { get; set; }

        [Required(ErrorMessage = "ჩაწერეთ ავტორის გვარი")]
        public string AuthorSurName { get; set; }

        [Required(ErrorMessage = "ჩაწერეთ სიახლის ტექსტი")]
        public string NewsText { get; set; }
    }
}