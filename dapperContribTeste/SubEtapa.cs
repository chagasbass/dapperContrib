using System;
using System.Collections.Generic;
using System.Text;

namespace dapperContribTeste
{
    public class SubEtapa
    {
        public long Id { get; private set; }
        public string Descricao { get; private set; }
        public int Ordem { get; private set; }
        public int Status { get; private set; }
        public long EtapaId { get; private set; }
        public Etapa Etapa { get; private set; }

        protected SubEtapa() { }
        public SubEtapa(string descricao, int ordem, int status, long etapaId)
        {
            Descricao = descricao;
            Ordem = ordem;
            Status = status;
            EtapaId = etapaId;
        }

        public void InserirEtapa(Etapa etapa) => Etapa = etapa;
    }
}
