namespace HealthMed_Agenda.Infra.MQ.Events
{
    public interface IProcessaEvento
    {
        void Processa(string mensagem);
    }
}
