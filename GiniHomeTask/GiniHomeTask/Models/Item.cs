﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GiniTask.Models
{
    public class Item
    {
        public string name { get; set; }
        public RepoOwner Owner { get; set; }
    }
}
