using Dapper.FluentMap.Mapping;

namespace dapperContribTeste
{
    public class SubEtapaMap: EntityMap<SubEtapa>
    {
        public SubEtapaMap()
        {
            Map(etapa => etapa.Id).ToColumn("ID_SUBETAPA");
            Map(etapa => etapa.Descricao).ToColumn("DS_SUBETAPA");
            Map(etapa => etapa.EtapaId).ToColumn("ID_ETAPA");
            Map(etapa => etapa.Ordem).ToColumn("NU_ORDEM");
            Map(etapa => etapa.Status).ToColumn("IN_STATUS");
        }
    }
}
