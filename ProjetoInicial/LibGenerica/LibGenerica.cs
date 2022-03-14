namespace ProjetoInicial.LibGenerica
{
    public class LibGenerica : ILibGenerica
    {
        public string GeraCodigo() =>
            Guid.NewGuid().ToString().ToUpper()[..8];
        
    }
}
