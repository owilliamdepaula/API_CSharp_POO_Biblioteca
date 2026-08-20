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
    public string Nome { get; }


    public DateTime DataNascimento { get; }
    public int Idade
    {
        get
        {
            var hoje = DateTime.Today;
            var idade = hoje.Year - DataNascimento.Year;


            if (DataNascimento.Date > hoje.AddYears(-idade))
                idade--;

            return idade;
        }
    }
    public List<Emprestimo> Emprestimos { get; } = new();
    public IEnumerable<Emprestimo> EmprestimosAtivos => Emprestimos.Where(e => !e.Devolvido);
}