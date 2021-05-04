using CB.Models.DTOs.Helpers;
using CB.Models.DTOs.Supervisor;
using System.Threading.Tasks;

namespace CB.Infrastructure.Services.Supervisor
{
    public interface ISupervisorService
    {
        Task<ResponseDto> GetAll(Pagination pagination, Query query);
        Task<SupervisorUpdateDto> Get(string id);
        Task Create(SupervisorCreateDto input , string userId);
        Task Update(SupervisorUpdateDto input, string userId);
        Task Delete(string id, string userId);
    }
}
