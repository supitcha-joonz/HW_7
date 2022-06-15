using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemNotififation.Shared
{
    public class Problem
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string ApplicationName { get; set; } = string.Empty;
        public string ProblemName { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
}
