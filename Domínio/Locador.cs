namespace Biblioteca.Dominio;

public class Locador
{
    public string Nome { get; set; }
    public DateTime DataNascimento { get; set; }

    public Locador(string nome, DateTime dataNascimento)
    {
        Nome = nome;
        DataNascimento = dataNascimento;
    }
}