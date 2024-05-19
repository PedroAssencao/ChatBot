
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chatbot.Infrastructure.Dtto
{
    public class MenuDttoGet
    {
        public int MenId { get; set; }
        public string? MenTitle { get; set; }
        public string? MenHeader { get; set; }
        public string? MenBody { get; set; }
        public string? MenFooter { get; set; }
        public string? MenTipo { get; set; }
        public LoginDttoGet? Login { get; set; }
        public List<OptionDttoGetForMenu>? Options { get; set; }
    }

    public class MenuDttoGetForView
    {
        public int MenId { get; set; }
        public string? MenTitle { get; set; }
        public string? MenHeader { get; set; }
        public string? MenBody { get; set; }
        public string? MenFooter { get; set; }
        public string? MenTipo { get; set; }
        public LoginDttoGetForView? Login { get; set; }
        public List<OptionDttoGetForMenu>? Options { get; set; }
    }
}
