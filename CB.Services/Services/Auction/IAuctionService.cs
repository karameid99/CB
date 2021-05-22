using CB.Models.DTOs.Auction;
using CB.Models.DTOs.Helpers;
using System.Threading.Tasks;

namespace CB.Infrastructure.Services.Auction
{
    public interface IAuctionService
    {
        Task<ResponseDto> GetAll(Pagination pagination, Query query, int? id = null); 
        Task Create(AuctionCreateDto input, string userId);
    }
}
