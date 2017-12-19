using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GLab.Models
{
    public class ConsumedModels
    {
        public RegistrationModel regModel { get; set; }
        public List<UserPost> UsrPsts { get; set; }
        public UserPost SingleUserPost { get; set; }
        public UserPost SingleUserEdit { get; set; }
        public UserPostModel usrPstModel { get; set; }
    }
}