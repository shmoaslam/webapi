using BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessServices.interfaces
{
    /// <summary>
    /// Criminal Service Contract
    /// </summary>
    public interface ICriminalServices
    {
        CriminalEntity GetCriminalById(int CriminalId);
        IEnumerable<CriminalEntity> GetAllCriminals();
        long CreateCriminal(CriminalEntity CriminalEntity);
        bool UpdateCriminal(int CriminalId, CriminalEntity CriminalEntity);
        bool DeleteCriminal(int CriminalId);
    }
}