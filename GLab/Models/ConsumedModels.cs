using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace GLab.Models
{
    public class ConsumedModels
    {
        public RegistrationModel regModel { get; set; }
        public List<UserPost> UsrPsts { get; set; }
        public UserPost SingleUserPost { get; set; }
        public UserPost SingleUserEdit { get; set; }
        public UserPostModel usrPstModel { get; set; }

        //for login modal
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "გთხოვთ ჩაწეროთ სწორედ ელ.ფოსტის მისამართი")]
        [Required(ErrorMessage = "ჩაწერეთ ელ.ფოსტა")]
        public string UsrEmail { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "ჩაწერეთ პაროლი")]
        public string UsrPassword { get; set; }

        //for add post modal
        [Required(ErrorMessage = "ჩაწერეთ სიახლის სათაური")]
        public string NewsTitle { get; set; }
        [Required(ErrorMessage = "ჩაწერეთ სახელი")]
        public string AuthorName { get; set; }
        [Required(ErrorMessage = "ჩაწერეთ გვარი")]
        public string AuthorSurName { get; set; }
    }
}