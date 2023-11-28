using AutoMapper;
using glasnost_back.Entities;
using glasnost_back.Helpers;
using glasnost_back.Models;
using glasnost_back.Models.Empresa;
using glasnost_back.Utils;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace glasnost_back.Services
{
    public interface IEmpresaService
    {
        List<EmpresaListResponse> GetAll();
        EmpresaResponse Get(int Id);
        List<EmpresaRiscoComplianceResponse> GetRiscoCompliance();
        List<EmpresaTipoResponse> GetTipo();
        EmpresaResponse Insert(EmpresaResponse Empresa);
        EmpresaResponse Update(EmpresaResponse Empresa);
        void Delete(int Id);
        void Deactivated(int Id, bool Active);
        bool CNPJValido(int Id, long CNPJ);
    }

    public class EmpresaService : IEmpresaService
    {
        private readonly ModelDBContext _db;
        private readonly IMapper _mapper;

        public EmpresaService(
            ModelDBContext context,
            IMapper mapper)
        {
            _db = context;
            _mapper = mapper;
        }

        public List<EmpresaListResponse> GetAll()
        {
            List<Empresa> list = _db.Empresa.OrderBy(x => x.RazaoSocial).ToList();
            var response = _mapper.Map<List<EmpresaListResponse>>(list);
            return response;
        }

        public EmpresaResponse Get(int Id)
        {
            Empresa? model = _db.Empresa
                .Include(x => x.Empresa_Cnae_Rel)
                .FirstOrDefault(x => x.Id == Id);

            if (model == null)
                throw new Exception("Registro não encontrado");


            var response = _mapper.Map<EmpresaResponse>(model);
            return response;
        }
        public List<EmpresaRiscoComplianceResponse> GetRiscoCompliance()
        {
            List<EmpresaRiscoCompliance> model = _db.EmpresaRiscoCompliance.ToList();

            var response = _mapper.Map<List<EmpresaRiscoComplianceResponse>>(model);
            return response;
        }
        public List<EmpresaTipoResponse> GetTipo()
        {
            List<EmpresaTipo> model = _db.EmpresaTipo.ToList();

            var response = _mapper.Map<List<EmpresaTipoResponse>>(model);
            return response;
        }

        public EmpresaResponse Insert(EmpresaResponse model)
        {
            bool valid = _db.Empresa.Any(x => x.CNPJ == model.CNPJ);
            if (valid) throw new Exception("CNPJ já está cadastrado.");

            valid = Validation.ValidaCNPJ(model.CNPJ.ToString());
            if (!valid) throw new Exception("CNPJ inválido.");


            model.RazaoSocial = Format.ToTitleCase(model.RazaoSocial);
            model.NomeFantasia = Format.ToTitleCase(model.NomeFantasia);

            Empresa entity = _mapper.Map<Empresa>(model);
            _db.Empresa.Add(entity);
            _db.SaveChanges();
            model.Id = entity.Id;
            var cnaes = model.Cnaes.Select(x => new EmpresaCnae_Rel
            {
                Empresa_Id = model.Id,
                Cnae_Id = x
            });

            _db.EmpresaCnae_Rel.AddRange(cnaes);
            _db.SaveChanges();


            return model;
        }


        public EmpresaResponse Update(EmpresaResponse model)
        {
            bool valid = _db.Empresa.Any(x => x.CNPJ == model.CNPJ && x.Id != model.Id);
            if (valid) throw new Exception("CNPJ já está cadastrado.");

            valid = Validation.ValidaCNPJ(model.CNPJ.ToString());
            if (!valid) throw new Exception("CNPJ inválido.");

            valid = _db.Empresa.Any(x => x.Id == model.Id);
            if (!valid) throw new Exception("Registro não encontrado.");

            model.RazaoSocial = Format.ToTitleCase(model.RazaoSocial);
            model.NomeFantasia = Format.ToTitleCase(model.NomeFantasia);

            Empresa entity = _mapper.Map<Empresa>(model);
            _db.Empresa.Update(entity);


            var cnaesEmpresa = _db.EmpresaCnae_Rel.Where(x => x.Empresa_Id == model.Id).Include(x => x.Cnae).ToList();

            var cnaes = model.Cnaes.Select(x => new EmpresaCnae_Rel
            {
                Empresa_Id = model.Id,
                Cnae_Id = x
            });

            _db.EmpresaCnae_Rel.RemoveRange(cnaesEmpresa);
            _db.EmpresaCnae_Rel.AddRange(cnaes);

            _db.SaveChanges();
            model.Id = entity.Id;

            return model;
        }

        public void Deactivated(int Id, bool active)
        {
            var model = _db.Empresa.Find(Id);
            if (model == null)
                throw new Exception("Registro não encontrado.");

            if (active)
                model.DataDesativado = null;
            else
                model.DataDesativado = DateTime.Now;

            _db.Empresa.Update(model);
            _db.SaveChanges();

            return;
        }

        public void Delete(int Id)
        {
            Empresa? model = _db.Empresa
                .Include(x => x.Empresa_Cnae_Rel)
                .FirstOrDefault(x => x.Id == Id);
            if (model == null) 
                throw new Exception("Registro não encontrado.");

            _db.EmpresaCnae_Rel.RemoveRange(model.Empresa_Cnae_Rel);
            _db.Empresa.Remove(model);
            _db.SaveChanges();
            return;
        }

        public bool CNPJValido(int Id, long CNPJ)
        {
            var valid = Validation.ValidaCNPJ(CNPJ.ToString());
            if (!valid)
                throw new Exception("CNPJ inválido");

            Empresa? model = _db.Empresa.FirstOrDefault(x => x.CNPJ == CNPJ && x.Id != Id);
            if (model != null)
                throw new Exception("CNPJ já cadastrado em outro registro.");

            return true;
        }
    }
}
