using AutoMapper;
using glasnost_back.Entities;
using glasnost_back.Helpers;
using glasnost_back.Models;
using glasnost_back.Utils;
using Microsoft.Extensions.Options;

namespace glasnost_back.Services
{
    public interface IEmpresaService
    {
        List<EmpresaListResponse> GetAll(bool? ativo);
        EmpresaResponse Get(int Id);
        EmpresaResponse Insert(EmpresaResponse Empresa);
        EmpresaResponse Update(EmpresaResponse Empresa);
        void Delete(int Id);
        void Deactivated(int Id, bool Active);
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

        public List<EmpresaListResponse> GetAll(bool? ativo)
        {
            List<Empresa> list;

            if (ativo.HasValue)
                list = _db.Empresa.Where(x => x.DataDesativado.HasValue == ativo).OrderBy(n => n.RazaoSocial).ToList();
            else
                list = _db.Empresa.OrderBy(n => n.RazaoSocial).ToList();

            var response = _mapper.Map<List<EmpresaListResponse>>(list);
            return response;
        }

        public EmpresaResponse Get(int Id)
        {
            Empresa? model = _db.Empresa.FirstOrDefault(p => p.Id == Id);

            if (model == null)
                throw new AppException(@$"Registro não encontrado");


            var response = _mapper.Map<EmpresaResponse>(model);
            return response;
        }

        public EmpresaResponse Insert(EmpresaResponse model)
        {
            bool valid = _db.Empresa.Any(x => x.CNPJ == model.CNPJ);
            if (valid) throw new AppException(@$"CNPJ já está cadastrado.");

            valid = Validation.ValidaCNPJ(model.CNPJ.ToString());
            if (!valid) throw new AppException(@$"CNPJ inválido.");


            model.RazaoSocial = Format.ToTitleCase(model.RazaoSocial);
            model.NomeFantasia = Format.ToTitleCase(model.NomeFantasia);

            Empresa entity = _mapper.Map<Empresa>(model);
            _db.Empresa.Add(entity);
            _db.SaveChanges();
            var response = _mapper.Map<EmpresaResponse>(entity);
            return response;
        }


        public EmpresaResponse Update(EmpresaResponse model)
        {
            bool valid = _db.Empresa.Any(x => x.CNPJ == model.CNPJ && x.Id != model.Id);
            if (valid) throw new AppException(@$"CNPJ já está cadastrado.");

            valid = Validation.ValidaCNPJ(model.CNPJ.ToString());
            if (!valid) throw new AppException(@$"CNPJ inválido.");

            valid = _db.Empresa.Any(x => x.Id == model.Id);
            if (!valid) throw new AppException(@$"Registro não encontrado.");

            model.RazaoSocial = Format.ToTitleCase(model.RazaoSocial);
            model.NomeFantasia = Format.ToTitleCase(model.NomeFantasia);

            Empresa entity = _mapper.Map<Empresa>(model);
            _db.Empresa.Update(entity);
            _db.SaveChanges();
            var response = _mapper.Map<EmpresaResponse>(entity);
            return response;
        }

        public void Deactivated(int Id, bool active)
        {
            var model = _db.Empresa.Find(Id);
            if (model == null)
                throw new AppException(@$"Registro não encontrado.");

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
            Empresa? model = _db.Empresa.FirstOrDefault(x => x.Id == Id);
            if (model == null) 
                throw new AppException(@$"Registro não encontrado.");

            _db.Empresa.Remove(model);
            _db.SaveChanges();
            return;
        }
    }
}
