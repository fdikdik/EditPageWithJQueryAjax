using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EditPageWithJQueryAjax.ViewModels
{
    public class UserViewModel
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
    }
}