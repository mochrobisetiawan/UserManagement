using System;
using System.Collections.Generic;

namespace UserManagement.Models
{
    public partial class Muser
    {
        public int Id { get; set; }
        public string? Username { get; set; }
        public string? Fullname { get; set; }
        public string? Password { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public bool? Status { get; set; }
        public string? Remarks { get; set; }
    }

    public class UserDTO
    {
        public string? Id { get; set; }
        public string? Username { get; set; }
        public string? Fullname { get; set; }
        public string? Password { get; set; }
    }
}