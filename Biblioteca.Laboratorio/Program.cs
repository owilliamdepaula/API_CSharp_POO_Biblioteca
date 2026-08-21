using Biblioteca.Dominio;

ItemAcervo LivrodeEli = new Dvd("Livro de Eli", "Allen Hughes", ClassificacaoEtaria.DezesseisAnos);
ItemAcervo VocêéInsubstituível = new Livro("Você é Insubstituível", "Augusto Cury");
ItemAcervo TriploX = new Dvd("TriploX", "Vin Diesel", ClassificacaoEtaria.DezoitoAnos);
ItemAcervo Fluir = new Revista("Fluir", "Editora Terra, Mar e Ar");
ItemAcervo VelozesEFuriosos = new Dvd("Sharknado", "sharkão", ClassificacaoEtaria.CatorzeAnos);
ItemAcervo AArteDaGuerra = new Livro("A arte da Guerra", "Sun Tzu");
ItemAcervo AVoltaDosQueNãoForam = new Dvd ("A volta dos que não foram", "Autor Foi", ClassificacaoEtaria.Livre);

Locador locador1 = new Locador("João Silva", new DateTime(2005, 3, 15));
Locador locador2 = new Locador("Maria Santos", new DateTime(2000, 7, 22));
Locador locador3 = new Locador("Pedro Oliveira", new DateTime(2008, 11, 8));

Emprestimo emprestimo = new Emprestimo(AArteDaGuerra, locador1);
Emprestimo emprestimo1 = new Emprestimo(TriploX, locador2);
Emprestimo emprestimo2 = new Emprestimo(Fluir, locador3);


emprestimo.RegistrarDevolucao();
emprestimo1.RegistrarDevolucao();
emprestimo2.RegistrarDevolucao();

Locador locador = new Locador(
    "William",
    new DateTime(2000, 5, 10)
);

Console.WriteLine(locador.Idade);

var livroNovo = new Livro("O Cortiço", "Aluísio Azevedo");
var revistaNova = new Revista("Piauí", "Alvinegra");
Console.WriteLine($"Cena 6 - {livroNovo.Titulo} e o Id {livroNovo.Id}, " +
                  $"{revistaNova.Titulo} e o Id {revistaNova.Id}");