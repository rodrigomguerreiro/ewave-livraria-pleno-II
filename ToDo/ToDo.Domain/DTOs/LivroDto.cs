namespace ToDo.Domain.DTOs
{
    public class LivroDto
    {
        public string Titulo { get; set; }
        public string Sinopse { get; set; }
        public string Capa { get; set; }
        public int AutorId { get; set; }
        public int GeneroId { get; set; }
        public int SituacaoLivroId { get; set; }
        public bool Ativo { get; set; }
    }
}
