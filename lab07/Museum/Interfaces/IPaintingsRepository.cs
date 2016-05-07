using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Museum.Models;

namespace Museum.Interfaces
{
    public interface IPaintingsRepository
    {
        List<Painting> GetAll();
        int Add(Painting paiting);
        Painting Get(int id);
        Painting Update(Painting paiting);
        bool Delete(int id);
    }
}