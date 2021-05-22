using CB.Models.DTOs.Client;
using CB.Models.DTOs.Helpers;
using CB.Models.ViewModels.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CB.Infrastructure.Services.Client
{
    public interface IClientService
    {
        Task<ResponseDto> GetAll(Pagination pagination, Query query);
        Task<ClientUpdateDto> Get(int id);
        Task Create(ClientCreateDto input, string userId);
        Task Update(ClientUpdateDto input, string userId);
        Task Delete(int id, string userId);
        Task<ClientProfileVm> GetProfile(int id);
        Task<ResponseDto> GetAllAuctions(int id, Pagination pagination, Query query);
    }
}
