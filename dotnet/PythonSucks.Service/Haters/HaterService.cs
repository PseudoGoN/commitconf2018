using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PythonSucks.Model;
using PythonSucks.Repository;

namespace PythonSucks.Service.Haters
{
    public class HaterService : IHaterService
    {
        IRepository<Hater> _haterRepository;
        public HaterService(IRepository<Hater> haterRepository)
        {
            _haterRepository = haterRepository;
        }

        public void DeleteHater(Guid id)
        {
            var hater = _haterRepository.GetById(id);
            if(hater != null)
            {
                _haterRepository.Delete(hater);
            }
        }

        public Hater GetHaterById(Guid id)
        {
            return _haterRepository.GetById(id);
        }

        public IQueryable<Hater> GetHaters()
        {
            return _haterRepository.Table;
        }

        public void UpdateHater(Hater hater)
        {
            _haterRepository.Update(hater);
        }

        public Hater CreateHater(Hater hater)
        {
            _haterRepository.Insert(hater);
            return hater;
        }

        public bool ExistsHater(Guid id)
        {
            return _haterRepository.Table.Any(m => m.Id == id);
        }
    }
}
