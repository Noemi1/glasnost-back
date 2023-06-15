using glasnost_back.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace glasnost_back.Entities
{
    [Table("Log")]
    public class Log
    {
        public int Id { get; set; }
        public string Connection_Id { get; set; }
        public string IP { get; set; }
        public string HttpMethod { get; set; }
        public string RequestPath { get; set; }
        public string QueryString { get; set; }
        public string RequestBody { get; set; }
        public string ResponseStatus { get; set; }
        public string ResponseBody { get; set; }
        public DateTime? RequestDate { get; set; }

        public int? Account_Id { get; set; }
        public virtual Account Account { get; set; }

    }
    public class LogFiltro
    {
        public string IP { get; set; }
        public string HttpMethod { get; set; }
        public string RequestPath { get; set; }
        public string QueryString { get; set; }
        public string RequestBody { get; set; }
        public string ResponseStatus { get; set; }
        public string ResponseBody { get; set; }
        public DateTime? RequestDate { get; set; }
        public DateTime? RequestDate_De { get; set; }
        public DateTime? RequestDate_Ate { get; set; }
        public int? Account_Id { get; set; }

    }

    [Table("LogEntities")]
    public class LogEntities
    {
        public int Id { get; set; }
        public DateTime Data { get; set; }
        public string Acao { get; set; }
        public string Tabela { get; set; }
        public string Valores { get; set; }

        public int? Account_Id { get; set; }
        public virtual Account Account { get; set; }
    }

    [Table("LogError")]
    public class LogError : BaseEntity
    {
        public int Id { get; set; }
        public DateTime Data { get; set; }
        public string Descricao { get; set; }

        public int? Account_Id { get; set; }
        public virtual Account Account { get; set; }
    }
}
