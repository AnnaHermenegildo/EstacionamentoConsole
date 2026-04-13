namespace EstacionamentoConsole.Models.Factory
{
    public static class VagaFactory
    {
        public static List<Vaga> CriarVagas(int totalCarros, int totalMotos)
        {
            var vagas = new List<Vaga>();

            for (int i = 0; i < totalCarros; i++)
                vagas.Add(new VagaCarro());

            for (int i = 0; i < totalMotos; i++)
                vagas.Add(new VagaMoto());

            return vagas;
        }
    }
}
