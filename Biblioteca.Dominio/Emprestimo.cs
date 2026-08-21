namespace Biblioteca.Dominio;

public class Emprestimo
{
    public ItemAcervo Item { get; private set; }

    public Locador Locador { get; private set; }

    public DateTime DataEmprestimo { get; private set; } = DateTime.Today;

    public DateTime PrazoLimite { get; }

    public DateTime? DataDevolucao { get; private set; }

    public bool Devolvido => DataDevolucao.HasValue;

    private decimal? _multaCongelada;



    public Emprestimo(ItemAcervo item, Locador locador)
    {
        if (!item.PodeSerEmprestadoPara(locador))
        {
            throw new ExcecaoDominio("Impossível, cliente menor de idade!");
        }

        if (locador.EmprestimosAtivos.Count() >= 3)
        {
            throw new ExcecaoDominio("Limite de 3 itens excedido!");
        }
        item.MarcarComoEmprestado();
        Item = item;
        Locador = locador;
        PrazoLimite = DataEmprestimo.AddDays(item.PrazoDevolucao);
        locador.Emprestimos.Add(this);

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