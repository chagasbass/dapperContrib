using Dapper.FluentMap.Mapping;
using DapperExtensions.Mapper;

namespace dapperContribTeste
{
    public class EtapaMap:EntityMap<Etapa>
    {
        public EtapaMap()
        {
            Map(etapa => etapa.Id).ToColumn("ID_ETAPA");
            Map(etapa => etapa.Descricao).ToColumn("DS_ETAPA");
            Map(etapa => etapa.ValidacaoMentoria).ToColumn("IN_VALIDACAO_MENTORIA");
            Map(etapa => etapa.Ordem).ToColumn("NU_ORDEM");
            Map(etapa => etapa.Status).ToColumn("IN_STATUS");
        }
    }
}
