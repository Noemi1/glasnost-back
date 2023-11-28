using AutoMapper;
using glasnost_back.Entities;
using glasnost_back.Models;
using glasnost_back.Models.Empresa;

namespace glasnost_back.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            // CreateMap<Source, Destination>();

            CreateMap<Empresa, EmpresaListResponse>();
            CreateMap<Empresa, EmpresaResponse>()
                .ForMember(dest => dest.Cnaes, m => m.MapFrom(source => source.Empresa_Cnae_Rel.Select(x => x.Cnae_Id).ToList()));
            CreateMap<EmpresaResponse, Empresa>();

            CreateMap<EmpresaCnae, CnaeListResponse>();
            CreateMap<EmpresaRiscoCompliance, EmpresaRiscoComplianceResponse>();
            CreateMap<EmpresaTipo, EmpresaTipoResponse>();


            CreateMap<Pessoa, PessoaListResponse>();
            CreateMap<Pessoa, PessoaResponse>();
            CreateMap<PessoaResponse, Pessoa>();

        }
    }
}
