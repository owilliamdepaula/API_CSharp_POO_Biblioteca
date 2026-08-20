using Biblioteca.Dominio;

Console.WriteLine("Hello, World!");

ItemAcervo LivrodeEli = new Dvd("Livro de Eli", "Allen Hughes", default(ClassificacaoEtaria));

ItemAcervo VocêéInsubstituível = new Livro("Você é Insubstituível", "Augusto Cury");

Emprestimo Divida = new Emprestimo(LivrodeEli);

Divida.RegistrarDevolucao();