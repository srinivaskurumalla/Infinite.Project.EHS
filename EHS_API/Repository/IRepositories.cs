using Microsoft.AspNetCore.Components.Routing;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EHS_API.Repositories
{
    //Manipulation operations
    public interface IRepositories<T> where T : class
    {
        Task Create(T obj);
        Task<T> Update(int id, T obj);
        Task<T> Delete(int id);
    }

    //Query operations
    public interface IGetRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAll();

        Task<T> GetById(int id);

    }

    public interface IAdminRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAll();
        Task<IEnumerable<T>> GetAllPendings();
        Task<IEnumerable<T>> GetAllApproved();
        Task<IEnumerable<T>> GetAllRejected();
        Task<IEnumerable<T>> ViewByRegion(int cityId);
        Task<IEnumerable<T>> ViewByOwner(string modeType);
        Task<T> Reject(int id);
        Task<T> Approve(int id);


    }

    public interface IGetSellerRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllMyProperties(int id);
        Task<IEnumerable<T>> GetPropertiesByCity(int id, int cityId);
    }

    /*public interface ISellerHouseRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAll();
    }*/
}
