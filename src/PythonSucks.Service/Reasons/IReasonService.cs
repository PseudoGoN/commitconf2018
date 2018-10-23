using PythonSucks.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PythonSucks.Service.Reasons
{
    public interface IReasonService
    {
        IQueryable<Reason> GetReasons();
        Reason GetReasonById(Guid id);
        void UpdateReason(Reason reason);
        void DeleteReason(Guid id);
        Reason CreateReason(Reason reason);
        bool ExistsReason(Guid id);
        bool AddVote(Guid reasonId, Guid haterId);
    }
}
