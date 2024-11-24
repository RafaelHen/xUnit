using APICatalogo.Controllers;
using APICatalogo.DTOs;
using APICatalogo.Repositories;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using FakeItEasy;
using AutoMapper;
using APICatalogo.Models;
using System.Net;

namespace ApiCatalogoxUnitTests.UnitTests
{
    public class PostProdutoUnitTests
    {
		private readonly IMapper _mapper;
		private readonly ProdutosController _produtoController;
		private readonly IProdutoRepository _produtoRepository;

		public PostProdutoUnitTests()
		{
			_mapper = A.Fake<IMapper>();
			_produtoController = A.Fake<ProdutosController>();
			_produtoRepository = A.Fake<IProdutoRepository>();
		}

		//metodos de testes para POST
		[Fact]
		public async Task PostProduto_Return_CreatedStatusCode()
		{
			// Arrange
			var produtoRequest = new ProdutoDTO
			{
				Nome = "Novo Produto",
				Descricao = "Descrição do Novo Produto",
				Preco = 10.99m,
				ImagemUrl = "imagemfake1.jpg",
				CategoriaId = 1
			};

			var produtoCriado = new Produto
			{
				Nome = "Novo Produto",
				Descricao = "Descrição do Novo Produto",
				Preco = 10.99m,
				ImagemUrl = "imagemfake1.jpg",
				CategoriaId = 1
			};

			// Configurando o comportamento do serviço
			A.CallTo(() => _produtoRepository.Create(A<Produto>.Ignored))
				.Returns((produtoCriado)); // Retorna Task<Produto>


			A.CallTo(() => _mapper.Map<Produto>(produtoRequest))
				.Returns(new Produto());

			A.CallTo(() => _mapper.Map<ProdutoDTO>(produtoCriado))
				.Returns(new ProdutoDTO
				{
					Nome = produtoCriado.Nome,
					Descricao = produtoCriado.Descricao,
					Preco = produtoCriado.Preco,
					ImagemUrl = produtoCriado.ImagemUrl,
					CategoriaId = produtoCriado.CategoriaId
				});

			// Act
			try
			{
				var result = await _produtoController.Post(produtoRequest);

				result.Should().BeAssignableTo<ActionResult<ProdutoDTO>>();

				// Verifica o tipo de result, que deve ser um CreatedAtRouteResult
				var createdResult = result.Result.Should().BeOfType<CreatedAtRouteResult>().Subject;

				// Verifica se o StatusCode é 201 (Created)
				createdResult.StatusCode.Should().Be(201);

			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.InnerException);
			}
		}
	}
}

		//[Fact]
  //      public async Task PostProduto_Return_BadRequest()
  //      {
  //          ProdutoDTO prod = null;

  //          // Act              
  //          var data = await _controller.Post(prod);

  //          // Assert  
  //          var badRequestResult = data.Result.Should().BeOfType<BadRequestResult>();
  //          badRequestResult.Subject.StatusCode.Should().Be(400);
  //      }

