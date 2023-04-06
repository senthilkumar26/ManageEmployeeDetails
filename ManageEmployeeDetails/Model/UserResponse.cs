using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageEmployeeDetails.Model
{
    public class UserResponse
    {
        public int Code { get; set; }
        public Meta Meta { get; set; }

        public List<User> Data { get; set; }
    }
    public class Pagination
    {
        public int Total { get; set; }
        public int Pages { get; set; }
        public int Page { get; set; }
        public int Limit { get; set; }
    }
    public class Meta
    {
        public Pagination Pagination { get; set; }
    }
}
