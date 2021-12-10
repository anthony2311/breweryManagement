using Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Interfaces
{
    public interface IBeerRepository
    {
        IEnumerable<Beer> GetAll();
    }
}
