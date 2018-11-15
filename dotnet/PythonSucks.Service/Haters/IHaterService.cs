using PythonSucks.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PythonSucks.Service.Haters
{
    public interface IHaterService
    {
        IQueryable<Hater> GetHaters();
        Hater GetHaterById(Guid id);
        void UpdateHater(Hater hater);
        void DeleteHater(Guid id);
        Hater CreateHater(Hater hater);
        bool ExistsHater(Guid id);
    }
}
