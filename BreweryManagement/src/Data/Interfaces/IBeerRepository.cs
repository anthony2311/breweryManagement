﻿using Data.Models;
using System.Collections.Generic;

namespace Data.Interfaces
{
    public interface IBeerRepository
    {
        IEnumerable<Beer> GetAll();
    }
}
