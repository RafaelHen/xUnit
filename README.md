Este README tem como objetivo apresentar o uso do xUnit para a criação de testes unitários juntamente com a ferramenta ItsEasyFake, que facilita a criação de objetos simulados para testes em .NET. O foco é demonstrar como realizar testes de unidade em controladores de API, simular o comportamento de repositórios e mapear objetos de forma eficiente.

Estrutura de Testes com xUnit
O que é xUnit?
xUnit é uma das bibliotecas de testes mais populares no .NET, sendo amplamente utilizada para escrever e rodar testes unitários. Ele oferece uma abordagem simples e poderosa para validar o comportamento do código, assegurando que ele funcione corretamente à medida que evolui.

Atributos principais:
[Fact]: Usado para marcar um método de teste.
[Theory]: Permite rodar o mesmo teste com diferentes dados de entrada.
Assert: Usado para validar as condições esperadas.

ItsEasyFake
O que é o ItsEasyFake?
O ItsEasyFake é uma ferramenta que facilita a criação de objetos simulados (fakes) para testes. Quando você está testando código que depende de interfaces, como repositórios ou serviços externos, o ItsEasyFake permite criar comportamentos personalizados para essas dependências sem precisar interagir com bancos de dados reais ou APIs externas.

Objetivo: Simular o comportamento de dependências para que você possa focar na lógica de sua aplicação durante os testes.
Exemplo de uso do ItsEasyFake:
csharp
Copiar código
var produtoFake = A.Fake<IProdutoRepository>();

// Simulando o comportamento do método GetProduto
A.CallTo(() => produtoFake.GetProduto(A<int>.Ignored))
    .Returns(new Produto { Id = 1, Nome = "Produto Falso" });
No exemplo acima, usamos o FakeItEasy para criar um repositório simulado. Quando o método GetProduto for chamado, ele retornará um produto falso. Esse tipo de simulação é essencial para realizar testes sem precisar de um banco de dados real.