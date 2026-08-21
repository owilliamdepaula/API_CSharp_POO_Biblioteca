namespace Biblioteca.Dominio;

public abstract class ItemAcervo
{
    private static int _proximoId =1;
    public int Id { get; }
    protected ItemAcervo(string titulo, string autor)
    {
        if (string.IsNullOrWhiteSpace(titulo))
        {
            throw new ExcecaoDominio("O título é obrigatório.");
        }
        Titulo = titulo;
        Autor = autor;
        Id = _proximoId++;
    }
    public string Titulo { get; private set; } = string.Empty;
    public string Autor { get; private set; } = string.Empty;
    public bool Disponibilidade { get; private set; } = true;

    public virtual ClassificacaoEtaria Classificacao { get; }
    public abstract int PrazoDevolucao { get; }
    public abstract decimal MultaDiaAtrasado { get; }
    public decimal CalcularMulta(int diasAtrasados)
    {
        return diasAtrasados >= 0 ? diasAtrasados * MultaDiaAtrasado : 0;
    }

    public void MarcarComoDevolvido()
    {
        if (Disponibilidade)
        {
            throw new ExcecaoDominio("Não está emprestado");
        }
        Disponibilidade = true;
    }
    public void MarcarComoEmprestado()
    {
        if (!Disponibilidade)
        {
            throw new ExcecaoDominio("Não está emprestado");
        }
        Disponibilidade = false;
    }

    public bool PodeSerEmprestadoPara(Locador locador)
    {
        if (Classificacao == ClassificacaoEtaria.Livre)
        {
            return true;
        }
        int idade = CalcularIdade(locador.DataNascimento);
        return idade >= (int)Classificacao;
    }

    private static int CalcularIdade(DateTime dataNascimento)
    {
        var hoje = DateTime.Today;
        int idade = hoje.Year - dataNascimento.Year;

        if (dataNascimento.Date > hoje.AddYears(-idade))
        {
            idade--;
        }

        return idade;
    }

}