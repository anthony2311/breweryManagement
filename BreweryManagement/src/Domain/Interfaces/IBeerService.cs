using Data.Models;
using System.Collections.Generic;

namespace Api.Controllers
{
    public interface IBeerService
    {
        List<Beer> Get();
    }
}