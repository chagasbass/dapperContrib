using Dapper;
using Dapper.Contrib.Extensions;
using Dapper.FluentMap;
using Microsoft.Data.SqlClient;
using System;
using System.Text;

namespace dapperContribTeste
{
    class Program
    {

        static void Main(string[] args)
        {

            try
            {
                FluentMapper.Initialize(config =>
                {
                    config.AddMap(new EtapaMap());
                    config.AddMap(new SubEtapaMap());
                });

                Console.WriteLine("inserindo nova etapa");
                //var etapa = new Etapa("teste do dapper", true, 10, 1);
                
                
                ListarSubetapa(8);
                //InserirEtapa(etapa);
                //ListarEtapas();
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                var e = ex.Message;
                throw;
            }
        }

        

        public static void ListarEtapas()
        {
            var conn = @"Server=44.230.73.6;Database=DB_SEBRAE_NI_TESTE;User Id = sa; Password=!tobrasil2018;";

            using var conexao = new SqlConnection(conn);

            var etapas = conexao.Query<Etapa>("SELECT ID_ETAPA, DS_ETAPA, IN_VALIDACAO_MENTORIA, NU_ORDEM, IN_STATUS FROM dbo.TB_ETAPA_MODELO_NEGOCIO");

            foreach (var etapa in etapas)
            {
                Console.WriteLine("Etapas");
                Console.WriteLine("----------------------");
                Console.WriteLine($"id: {etapa.Id}, descricao:{etapa.Descricao}");
            }
        }

        public static void ListarSubetapa(long idEtapa)
        {
            var conn = @"Server=44.230.73.6;Database=DB_SEBRAE_NI_TESTE;User Id = sa; Password=!tobrasil2018;";

            using var conexao = new SqlConnection(conn);

            var query = new StringBuilder();
            query.AppendLine(" SELECT s.ID_SUBETAPA, s.ID_ETAPA, s.DS_SUBETAPA, s.NU_ORDEM, s.IN_STATUS,");
            query.AppendLine(" e.ID_ETAPA, e.DS_ETAPA,e.IN_VALIDACAO_MENTORIA, e.NU_ORDEM, e.IN_STATUS");
            query.AppendLine(" FROM dbo.TB_SUBETAPA_MODELO_NEGOCIO s JOIN");
            query.AppendLine(" TB_ETAPA_MODELO_NEGOCIO e");
            query.AppendLine(" ON e.ID_ETAPA = s.ID_ETAPA");
            query.AppendLine(" WHERE s.ID_ETAPA = @idEtapa");

            var subetapas = conexao.Query<SubEtapa, Etapa, SubEtapa>
                (query.ToString(),
                map: (subEtapa, etapa) =>
                {
                    subEtapa.InserirEtapa(etapa);
                    return subEtapa;
                },
                splitOn:"ID_ETAPA",
                param: new { @idEtapa = idEtapa });

            Console.WriteLine("teste");
        }
    }
}
    

   





