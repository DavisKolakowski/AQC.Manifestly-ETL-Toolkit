﻿namespace AQC.Manifestly.Core.Client.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class UserData
    {
        public int Id { get; set; }

        public string Email { get; set; }

        public string Name { get; set; }

        public string SimpleDisplayName { get; set; }

        public string Username { get; set; }
    }
}
