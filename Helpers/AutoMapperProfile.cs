using AutoMapper;
using glasnost_back.Entities;
using glasnost_back.Models;

namespace glasnost_back.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Empresa, EmpresaListResponse>();
            CreateMap<Empresa, EmpresaResponse>();
            CreateMap<EmpresaResponse, Empresa>();

            CreateMap<Pessoa, PessoaListResponse>();
            CreateMap<Pessoa, PessoaResponse>();
            CreateMap<PessoaResponse, Pessoa>();

        }
    }
}
