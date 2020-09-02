using System;
using System.Collections.Generic;
using System.Text;

namespace Serverspace.OpenApi.Models
{
    public class ProjectDetailing
    {
        public int Id { get; }

        public decimal Balance { get; }

        public ProjectDetailing(int id, decimal balance)
        {
            Id = id;
            Balance = balance;
        }
    }
}
