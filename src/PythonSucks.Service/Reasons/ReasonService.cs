using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PythonSucks.Model;
using PythonSucks.Repository;

namespace PythonSucks.Service.Reasons
{
    public class ReasonService : IReasonService
    {
        IRepository<Reason> _reasonRepository;
        IRepository<Vote> _voteRepository;

        public ReasonService(IRepository<Reason> reasonRepository, IRepository<Vote> voteRepository)
        {
            _reasonRepository = reasonRepository;
            _voteRepository = voteRepository;
        }
        public void DeleteReason(Guid id)
        {
            var reason = _reasonRepository.GetById(id);
            if (reason != null)
            {
                _reasonRepository.Delete(reason);
            }
        }

        public Reason GetReasonById(Guid id)
        {
            return _reasonRepository.GetById(id);
        }

        public IQueryable<Reason> GetReasons()
        {
            return _reasonRepository.Table;
        }

        public void UpdateReason(Reason reason)
        {
            _reasonRepository.Update(reason);
        }

        public Reason CreateReason(Reason reason)
        {
            _reasonRepository.Insert(reason);
            return reason;
        }

        public bool ExistsReason(Guid id)
        {
            return _reasonRepository.Table.Any(m => m.Id == id);
        }
        
        public bool AddVote(Guid reasonId, Guid haterId)
        {
            if(_voteRepository.Table.Any(m=>m.ReasonId == reasonId && m.HaterId == haterId))
            {
                return false;
            }
            _voteRepository.Insert(new Vote()
            {
                Id = Guid.NewGuid(),
                HaterId = haterId,
                ReasonId = reasonId
            });
            return true;
        }
        
    }
}
