﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace glasnost_back.Entities
{
    public class EmpresaTipo
    {
        public EmpresaTipo()
        {
            Empresa = new HashSet<Empresa>();
        }

        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public ICollection<Empresa> Empresa { get; set; }
    }
}