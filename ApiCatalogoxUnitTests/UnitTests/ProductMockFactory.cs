using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using APICatalogo.Models;
using APICatalogo.DTOs;
using APICatalogo.Pagination;

namespace ApiCatalogoxUnitTests.UnitTests
{
	internal static class ProductMockFactory
	{
		internal static int productId { get; set; } = 1;
		internal static Produto emptyProduct { get; set; } = new Produto();
		internal static ProdutoDTO emptyProductRequestDto { get; set; } = new ProdutoDTO();
		internal static ProdutoDTOUpdateResponse emptyProductResponseDto { get; set; } = new ProdutoDTOUpdateResponse();
		internal static ProdutosFiltroPreco emptyProductFilterRequestDto { get; set; } = new ProdutosFiltroPreco { PageNumber = 1, PageSize = 10 };
		internal static IEnumerable<Produto> emptyProductList { get; set; } = Enumerable.Empty<Produto>();
		internal static IEnumerable<Produto> validProductList { get; set; } = Enumerable.Repeat(emptyProduct, 1);
		internal static List<ProdutoDTOUpdateResponse> validProductResponseDtoList { get; set; } = new List<ProdutoDTOUpdateResponse> { emptyProductResponseDto };


		//internal static ValidationResult GetValidationResult()
		//{
		//	var validationResult = new ValidationResult(new List<ValidationFailure>
		//	{
		//		new ValidationFailure("Field", "Validation failed")
		//	});

		//	return validationResult;
		//}
	}
}
