using AutoMapper;
using glasnost_back.Entities;
using glasnost_back.Helpers;
using glasnost_back.Models;
using glasnost_back.Utils;
using Microsoft.Extensions.Options;

namespace glasnost_back.Services
{
    public interface ICnaeService
    {
        List<CnaeListResponse> GetAll();
    }

    public class CnaeService : ICnaeService
    {
        private readonly ModelDBContext _db;
        private readonly IMapper _mapper;

        public CnaeService(
            ModelDBContext context,
            IMapper mapper)
        {
            _db = context;
            _mapper = mapper;
        }

        public List<CnaeListResponse> GetAll()
        {
            List<EmpresaCnae> list = _db.EmpresaCnae.OrderBy(n => n.Codigo).ToList();
            var response = _mapper.Map<List<CnaeListResponse>>(list);
            return response;
        }

  
    }
}
