using System;
using System.Threading.Tasks;
using ApplicationCore.Entities;
namespace ApplicationCore.ServiceInterfaces
{


    public interface ICurrentUser
    {
        int UserId { get; }
        bool IsAuthenticated { get; }
        string Email { get; }
        string FullName { get; }
        bool IsAdmin { get; }
        bool IsSuperAdmin { get; }

        //Task<Purchase> PurchaseMovie(int MovieID);
    }
}
