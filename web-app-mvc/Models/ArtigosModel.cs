using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace web_app_mvc.Models
{
    public class ArtigosModel
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public int Quantidade { get; set; }

        public static implicit operator string(ArtigosModel v)
        {
            throw new NotImplementedException();
        }
    }
}
