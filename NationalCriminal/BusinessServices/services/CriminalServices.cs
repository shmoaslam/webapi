using BusinessServices.interfaces;
using DataModel;
using DataModel.WorkEntry;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using System;
using BusinessEntities;
using AutoMapper;

namespace BusinessServices.services
{
    /// <summary>
    /// Offers services for Criminal specific CRUD operations
    /// </summary>
    public class CriminalServices : ICriminalServices
    {
        private readonly UnitOfWork _unitOfWork;

        /// <summary>
        /// Public constructor.
        /// </summary>
        public CriminalServices()
        {
            _unitOfWork = new UnitOfWork();
        }

        /// <summary>
        /// Fetches Criminal details by id
        /// </summary>
        /// <param name="CriminalId"></param>
        /// <returns></returns>
        public CriminalEntity GetCriminalById(int CriminalId)
        {
            var Criminal = _unitOfWork.CriminalRepository.GetByID(CriminalId);
            if (Criminal != null)
            {
                Mapper.CreateMap<Criminal, CriminalEntity>();
                var CriminalModel = Mapper.Map<Criminal, CriminalEntity>(Criminal);
                return CriminalModel;
            }
            return null;
        }

        /// <summary>
        /// Fetches all the Criminals.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<CriminalEntity> GetAllCriminals()
        {
            var Criminals = _unitOfWork.CriminalRepository.GetAll().ToList();
            if (Criminals.Any())
            {
                Mapper.CreateMap<Criminal, CriminalEntity>();
                var CriminalsModel = Mapper.Map<List<Criminal>, List<CriminalEntity>>(Criminals);
                return CriminalsModel;
            }
            return null;
        }

        /// <summary>
        /// Creates a Criminal
        /// </summary>
        /// <param name="CriminalEntity"></param>
        /// <returns></returns>
        public long CreateCriminal(CriminalEntity CriminalEntity)
        {
            using (var scope = new TransactionScope())
            {
                var Criminal = new Criminal
                {
                    FName = CriminalEntity.FName,
                    LName = CriminalEntity.LName,
                    Age = CriminalEntity.Age,
                    Height = CriminalEntity.Height,
                    Weight = CriminalEntity.Weight,
                    Nationality = CriminalEntity.Nationality,
                    Sex = CriminalEntity.Sex
                };
                _unitOfWork.CriminalRepository.Insert(Criminal);
                _unitOfWork.Save();
                scope.Complete();
                return Criminal.Id;
            }
        }

        /// <summary>
        /// Updates a Criminal
        /// </summary>
        /// <param name="CriminalId"></param>
        /// <param name="CriminalEntity"></param>
        /// <returns></returns>
        public bool UpdateCriminal(int CriminalId, CriminalEntity CriminalEntity)
        {
            var success = false;
            if (CriminalEntity != null)
            {
                using (var scope = new TransactionScope())
                {
                    var Criminal = _unitOfWork.CriminalRepository.GetByID(CriminalId);
                    if (Criminal != null)
                    {
                        Criminal.FName = CriminalEntity.FName;
                        Criminal.LName = CriminalEntity.LName;
                        Criminal.Age = CriminalEntity.Age;
                        Criminal.Height = CriminalEntity.Height;
                        Criminal.Weight = CriminalEntity.Weight;
                        Criminal.Nationality = CriminalEntity.Nationality;
                        Criminal.Sex = CriminalEntity.Sex;
                        _unitOfWork.CriminalRepository.Update(Criminal);
                        _unitOfWork.Save();
                        scope.Complete();
                        success = true;
                    }
                }
            }
            return success;
        }

        /// <summary>
        /// Deletes a particular Criminal
        /// </summary>
        /// <param name="CriminalId"></param>
        /// <returns></returns>
        public bool DeleteCriminal(int CriminalId)
        {
            var success = false;
            if (CriminalId > 0)
            {
                using (var scope = new TransactionScope())
                {
                    var Criminal = _unitOfWork.CriminalRepository.GetByID(CriminalId);
                    if (Criminal != null)
                    {

                        _unitOfWork.CriminalRepository.Delete(Criminal);
                        _unitOfWork.Save();
                        scope.Complete();
                        success = true;
                    }
                }
            }
            return success;
        }
    }
}
