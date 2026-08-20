using Biblioteca.Dominio;

ItemAcervo LivrodeEli = new Dvd("Livro de Eli", "Allen Hughes");
ItemAcervo VocêéInsubstituível = new Livro("Você é Insubstituível", "Augusto Cury");
ItemAcervo TriploX = new Dvd("TriploX", "Vin Diesel", 18);
ItemAcervo Fluir = new Revista("Fluir", "Editora Terra, Mar e Ar");
ItemAcervo VelozesEFuriosos = new Dvd("Sharknado", "sharkão", 16);
ItemAcervo AArteDaGuerra = new Livro("A arte da Guerra", "Sun Tzu");
ItemAcervo AVoltaDosQueNãoForam = new Dvd ("A volta dos que não foram", "Autor Foi", 0);

Divida.RegistrarDevolucao();


Locador locador1 = new Locador("João Silva", new DateTime(2005, 3, 15));
Locador locador2 = new Locador("Maria Santos", new DateTime(2000, 7, 22));
Locador locador3 = new Locador("Pedro Oliveira", new DateTime(2008, 11, 8));

Emprestimo emprestimo = new Emprestimo(AArteDaGuerra, locador1);
Emprestimo emprestimo1 = new Emprestimo(TriploX, locador2);
Emprestimo emprestimo2 = new Emprestimo(Fluir, locador3);


emprestimo.RegistrarDevolucao();
emprestimo1.RegistrarDevolucao();
emprestimo2.RegistrarDevolucao();

locador1 locador = new Locador(
    "William",
    new DateTime(2000, 5, 10)
);

Console.WriteLine(Locador.Idade);