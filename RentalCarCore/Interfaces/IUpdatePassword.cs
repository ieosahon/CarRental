﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalCarCore.Interfaces
{
    public interface IUpdatePassword
    {
        Task<bool> UserUpdate(string userId);
    }
}