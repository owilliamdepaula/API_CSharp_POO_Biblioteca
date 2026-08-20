namespace Biblioteca.Dominio;

public class Emprestimo
{
    public ItemAcervo Item { get; private set; }

    public Locador locador { get; private set; }

    public DateTime DataEmprestimo { get; private set; } = DateTime.Today;

    public DateTime PrazoLimite { get; }

    public DateTime? DataDevolucao { get; private set; }

    public bool Devolvido => DataDevolucao.HasValue;

    private decimal? _multaCongelada;

    

    public Emprestimo(ItemAcervo item, Cliente cliente)
    {
          if (!item.PodeSerEmprestadoPara(cliente))
        {
            throw new ExcecaoDominio("Cliente não pode pq é menor...");
        }

        if (cliente.EmprestimosAtivos.Count() >= 3)
        {
            throw new ExcecaoDominio("Explodiu o limite 3 itens emprestados.");
        }
        item.MarcarComoEmprestado();
        Item = item;
        Cliente = cliente;
        PrazoLimite = DataEmprestimo.AddDays(item.PrazoDevolucao);
        cliente.Emprestimos.Add(this);

    }

    public decimal MultaAtual => Item.CalcularMulta(QtDiasAtrasados);
    public int QtDiasAtrasados
    {
        get
        {
            DateTime referencia = DataDevolucao ?? DateTime.Today;
            TimeSpan diasAtrasados = referencia - PrazoLimite;
            return diasAtrasados.Days;

        }
    }
    public void RegistrarDevolucao()
    {
        Item.MarcarComoDevolvido();
         DataDevolucao = DateTime.Today;
        _multaCongelada = Item.CalcularMulta(QtDiasAtrasados);
    }
}