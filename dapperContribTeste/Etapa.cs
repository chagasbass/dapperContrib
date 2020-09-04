namespace dapperContribTeste
{
    public class Etapa
    {
        public long Id { get; private set; }
        public string Descricao { get; private set; }
        public bool ValidacaoMentoria { get; private set; }
        public int Ordem { get; private set; }
        public int Status { get; private set; }

        protected Etapa()
        {

        }

        public Etapa(string descricao, bool validacaoMentoria, int ordem, int status)
        {
            Descricao = descricao;
            ValidacaoMentoria = validacaoMentoria;
            Ordem = ordem;
            Status = status;
        }
    }
}
