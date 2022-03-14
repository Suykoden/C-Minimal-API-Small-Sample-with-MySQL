using ProjetoInicial.Models.ClassesBase;

namespace ProjetoInicial.Models.Entidades
{
    public class Usuario : EntidadeBase
    {
        public string Idade { get; set; }
        public bool Ativo { get; set; }
    }
}
