using AutoMapper;
using glasnost_back.Entities;
using glasnost_back.Helpers;
using glasnost_back.Models;
using glasnost_back.Utils;
using Microsoft.Extensions.Options;

namespace glasnost_back.Services
{
    public interface IPessoaService
    {
        List<PessoaListResponse> GetAll(int empresaId, bool? ativo);
        PessoaResponse Get(int Id);
        PessoaResponse Insert(PessoaResponse pessoa);
        PessoaResponse Update(PessoaResponse pessoa);
        void Delete(int Id);
        void Deactivated(int Id, bool Active);
        bool DocumentValido(int Id, long Document, bool PJ);
    }

    public class PessoaService : IPessoaService
    {
        private readonly ModelDBContext _db;
        private readonly IMapper _mapper;

        public PessoaService(
            ModelDBContext context,
            IMapper mapper)
        {
            _db = context;
            _mapper = mapper;
        }

        public List<PessoaListResponse> GetAll(int empresaId, bool? ativo)
        {
            List<Pessoa> list;

            if (ativo.HasValue)
                list = _db.Pessoa.Where(x => x.Empresa_Id == empresaId && x.DataDesativado.HasValue != ativo).OrderBy(n => n.Nome).ToList(); 
             else
                list = _db.Pessoa.Where(x => x.Empresa_Id == empresaId).OrderBy(n => n.Nome).ToList();

            var response = _mapper.Map<List<PessoaListResponse>>(list);
            return response;
        }

        public PessoaResponse Get(int Id)
        {
            Pessoa? model = _db.Pessoa.FirstOrDefault(p => p.Id == Id);
            if (model == null)
                throw new AppException(@$"Registro não encontrado");


            var response = _mapper.Map<PessoaResponse>(model);
            return response;
        }

        public PessoaResponse Insert(PessoaResponse model)
        {
            bool valid = _db.Pessoa.Any(x => x.Documento == model.Documento);
            if (valid)  throw new AppException(@$"Esse {(model.PJ ? "CNPJ" : "CPF")} já está cadastrado.");

            valid = _db.Pessoa.Any(x => x.Email == model.Email);
            if (valid) throw new AppException(@$"Esse e-mail já está cadastrado.");

            if (model.PJ) valid = Validation.ValidaCNPJ(model.Documento.ToString());
            else        valid = Validation.ValidaCPF(model.Documento.ToString());
            
            if (!valid) throw new AppException(@$"{(model.PJ ? "CNPJ" : "CPF")} inválido.");


            model.Nome = Format.ToTitleCase(model.Nome);

            Pessoa entity = _mapper.Map<Pessoa>(model);
            _db.Pessoa.Add(entity);
            _db.SaveChanges();
            var response = _mapper.Map<PessoaResponse>(entity);
            return response;
        }

        public PessoaResponse Update(PessoaResponse model)
        {
            bool valid = _db.Pessoa.Any(x => x.Documento == model.Documento && x.Id != model.Id);
            if (valid) throw new AppException(@$"Esse {(model.PJ ? "CNPJ" : "CPF")} já está cadastrado.");

            valid = _db.Pessoa.Any(x => x.Email == model.Email && x.Id != model.Id);
            if (valid) throw new AppException(@$"Esse e-mail já está cadastrado.");

            if (model.PJ) valid = Validation.ValidaCNPJ(model.Documento.ToString());
            else valid = Validation.ValidaCPF(model.Documento.ToString());

            if (!valid) throw new AppException(@$"{(model.PJ ? "CNPJ" : "CPF")} inválido.");

            valid = _db.Pessoa.Any(x => x.Id == model.Id);
            if (!valid) throw new AppException(@$"Registro não encontrado.");

            model.Nome = Format.ToTitleCase(model.Nome);

            Pessoa entity = _mapper.Map<Pessoa>(model);
            _db.Pessoa.Update(entity);
            _db.SaveChanges();
            var response = _mapper.Map<PessoaResponse>(entity);
            return response;
        }

        public void Deactivated(int Id, bool active)
        {
            var model = _db.Pessoa.Find(Id);
            if (model == null)
                 throw new AppException(@$"Registro não encontrado.");

            if (active) 
                model.DataDesativado = null;
            else
                model.DataDesativado = DateTime.Now;

            _db.Pessoa.Update(model);
            _db.SaveChanges();

            return;
        }

        public void Delete(int Id)
        {
            Pessoa? model = _db.Pessoa.FirstOrDefault(x => x.Id == Id);
            if (model == null)
                throw new AppException(@$"Registro não encontrado.");

            _db.Pessoa.Remove(model);
            _db.SaveChanges();
            return;
        }
        public bool DocumentValido(int Id, long Document, bool PJ)
        {
            var valid = true;
            if (PJ)
            {
                valid = Validation.ValidaCNPJ(Document.ToString());
                if (!valid) throw new Exception("CNPJ inválido");
            } 
            else
            {
                valid = Validation.ValidaCPF(Document.ToString());
                if (!valid) throw new Exception("CPF inválido");
            }



            Pessoa? model = _db.Pessoa.FirstOrDefault(x => x.Documento == Document && x.PJ == PJ  && x.Id != Id);
            if (model != null)
                throw new Exception($"{ (PJ ? "CNPJ" : "CPF") } já cadastrado em outro registro.");

            return true;
        }
    }
}
