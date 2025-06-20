﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniCRMApp.Data
{
    public class Customer
    {
        private DateTime? _createdAt;
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public DateTime CreatedAt
        {
            get => _createdAt ?? DateTime.Now;
            set => _createdAt = value;
        }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
