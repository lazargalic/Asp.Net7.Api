﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class AllUserUseCase
    {
        public int UserId { get; set; }
        public int UseCaseId { get; set; }

        public User User { get; set; }
    }
}
