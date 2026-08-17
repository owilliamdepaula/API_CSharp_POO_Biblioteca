namespace Biblioteca.Dominio;

public enum ClassificacaoEtaria
{
    Livre = 0,
    DozeAnos = 12,
    CatorzeAnos = 14,
    DezesseisAnos = 16,
    DezoitoAnos = 18
}

public class Dvd(string titulo, string autor, ClassificacaoEtaria classificacao) : ItemAcervo(titulo, autor)

{
    public ClassificacaoEtaria Classificacao { get; } = classificacao;

    public override int PrazoDevolucao => 3;

    public override decimal MultaDiaAtrasado => 3m;

    public bool PodeSerEmprestadoPara(Locador locador)
    {
        if (Classificacao == ClassificacaoEtaria.Livre)
        {
            return true;
        }
        int idade = CalcularIdade(locador.DataNascimento);
        return idade >= (int)Classificacao;
    }

    public int CalcularIdade(DateTime dataNascimento)
    {
        DateTime hoje = DateTime.Today;
        int idade = hoje.Year - dataNascimento.Year;

        //se a pessoa ainda não fez aniversário nesse ano, retirar um ano da idade calculada.
        if (dataNascimento.Date > hoje.AddYears(-idade))
        {
            idade--;
        }
        return idade;
    }
}