﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UserManagement.Model
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        public string UserName { get; set; }
        
        public byte[] PasswordHash { get; set; }

        public byte[] PasswordSalt { get; set; }
        
        public string Email { get; set; }

        public char Gender { get; set; }

        public int ContactNumber { get; set; }
    }
}
