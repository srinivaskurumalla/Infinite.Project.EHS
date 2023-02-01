using System.Collections.Generic;
using System.Threading.Tasks;

namespace EHS_API.Repository
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

    public interface ISellerDtoRepository<T> where T : class
    {
        Task<T> GetSellerDetails(int id);
    }

    public interface ICityRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllHouseByCityId(int id);
        Task<IEnumerable<T>> GetAllHousesBySellerName(string sellerName);
    }

    public interface IGetBuyerRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllApproved();
        Task<IEnumerable<T>> GetHousesByCity(int cityId);
        Task<IEnumerable<T>> GetHousesByType(string type);
        Task<IEnumerable<T>> GetHousesByOption(string option);
        Task<T> GetById(int id);
    }

    public interface IGetBuyerCartRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllMyCart(int id);
        Task AddToCart(T obj);
        Task<T> DeleteFromCart(int HouseId, int UserDetailsId);
        Task<T> CheckCartExistence(T obj);

    }

    public interface IGetUserDetailsRepository<T> where T : class
    {
        Task<T> GetUserId(string userName);
    }
}