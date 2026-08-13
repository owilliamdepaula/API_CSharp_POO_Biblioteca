namespace Biblioteca.Dominio;

public class Emprestimo
{
    public ItemAcervo Item { get; }
    public DateTime DataEmprestimo { get; private set; } = DateTime.Today;
    public DateTime PrazoLimite { get; private set; }
    
    public Emprestimo(ItemAcervo item)
    {
        Item = item;
    }

}