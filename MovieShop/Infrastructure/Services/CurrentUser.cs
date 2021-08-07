using System;
using System.Linq;
using ApplicationCore.ServiceInterfaces;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Infrastructure.Repositories;
using ApplicationCore.RepositoryInterfaces;
using ApplicationCore.Entities;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class CurrentUser : ICurrentUser

    {//httpcontext has those methods

        // ==>right click the Infrastructure
        // ==> "edit project file"
        // ==> add this:
        /*
         * <ItemGroup>
          <FrameworkReference Include="Microsoft.AspNetCore.App" />
           </ItemGroup>
         */
        //  ==> Then go to startup.cs add
        //==> services.AddHttpContextAccessor();

        private readonly IHttpContextAccessor _httpContextAccessor;
        public CurrentUser(IHttpContextAccessor httpContextAccessor)
            
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public int UserId => Convert.ToInt32(_httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);

        public bool IsAuthenticated => _httpContextAccessor.HttpContext.User.Identity.IsAuthenticated;

        public string Email => _httpContextAccessor.HttpContext.User
            .Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email).Value;

        public string FullName => _httpContextAccessor.HttpContext.User.
            Claims.FirstOrDefault(c => c.Type == ClaimTypes.GivenName).Value + " " +
            _httpContextAccessor.HttpContext.User.Claims.FirstOrDefault
            (c => c.Type == ClaimTypes.Surname).Value;

        public bool IsAdmin => throw new NotImplementedException();

        public bool IsSuperAdmin => throw new NotImplementedException();
        //public async Task<Purchase> PurchaseMovie(int id) {
        //    var purchase = new Purchase
        //    {
        //        MovieId = id,
        //        UserId = Convert.ToInt32(_httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value)
        //};
        //    var createPurchase = await _purchaseRepository.AddAsync(purchase);

        //    return createPurchase;
        //}
    }
}
