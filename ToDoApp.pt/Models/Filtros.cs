namespace ToDoApp.pt.Models
{
    public class Filtros
    {
        public Filtros(string filtrostring)
        {
            FiltroString = filtrostring ?? "todos-todos-todos";
            string[] filtros = FiltroString.Split("-");
            CategoriaId = filtros[0];
            Previsao = filtros[1];
            SituacaoId = filtros[2];
        }

        public string FiltroString { get; }
        public string CategoriaId { get; }

        public string Previsao { get; }
        public string SituacaoId { get; }
        public bool TemCategoria => CategoriaId.ToLower() != "todos";
        public bool TemPrevisao => Previsao.ToLower() != "todos";
        public bool TemSituacao => SituacaoId.ToLower() != "todos";
        public static Dictionary<string, string> FiltroPrevisaoValores =>
            new Dictionary<string, string> {
            { "futuro", "Futuro"},
            { "passado", "Passado"},
            { "hoje", "Hoje" }
        };

        public bool EPassado => Previsao.ToLower() == "passado";
        public bool EFuturo => Previsao.ToLower() == "futuro";
        public bool EHoje => Previsao.ToLower() == "hoje";
    }
}
