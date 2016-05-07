using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Museum.Models;

namespace Museum.Interfaces
{
    public interface IArtistsRepository
    {
        List<Artist> GetAll();
        int Add(Artist artist);
        Artist Get(int id);
        Artist Update(Artist artist);
        bool Delete(int id);
    }
}