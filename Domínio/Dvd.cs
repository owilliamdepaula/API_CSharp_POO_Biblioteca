namespace Biblioteca.Dominio;

public class Dvd(string titulo, string autor, ClassificacaoEtaria classificacao) : ItemAcervo(titulo, autor)
{
    public ClassificacaoEtaria Classificacao { get; } = classificacao;

    public bool PodeSerEmprestadoPara(Locador locador);

    public override int PrazoDevolucao => 3;

    public override decimal MultaDiaAtrasado => 3m;
}

public enum ClassificacaoEtaria
{
    Livre = 0,
    DozeAnos = 12,
    CatorzeAnos = 14,
    DezesseisAnos = 16,
    DezoitoAnos = 18
}