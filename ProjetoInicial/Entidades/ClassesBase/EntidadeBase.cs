namespace ProjetoInicial.Models.ClassesBase
{
    public abstract class EntidadeBase: IPossuiId
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Codigo { get; set; }
    }
}
