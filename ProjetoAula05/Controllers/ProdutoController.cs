﻿using ProjetoAula05.Entities;
using ProjetoAula05.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoAula05.Controllers
{
    public class ProdutoController
    {
        //método para capturar os dados de um produto
        //informado pelo usuário do DOS e atraves do
        //repositorio, grava-lo no banco de dados
        public void CadastrarProduto()
        {
            try
            {
                Console.WriteLine("\n *** CADASTRO DE PRODUTO *** \n");

                var produto = new Produto();

                //gerando o ID e data de cadastro do produto
                produto.IdProduto = Guid.NewGuid();
                produto.DataCadastro = DateTime.Now;

                Console.Write("Entre com o nome do produto........: ");
                produto.Nome = Console.ReadLine();

                Console.Write("Entre com o preço do produto.......: ");
                produto.Preco = decimal.Parse(Console.ReadLine());

                Console.Write("Entre com a quantidade do produto..: ");
                produto.Quantidade = int.Parse(Console.ReadLine());

                //cadastrando no banco de dados
                var produtoRepository = new ProdutoRepository();
                produtoRepository.Create(produto);

                Console.WriteLine("\nPRODUTO CADASTRADO COM SUCESSO NO BANCO DE DADOS!");
            }
            catch (Exception e)
            {
                Console.WriteLine($"\nFalha ao cadastrar produto: {e.Message}");
            }
        }

        //método para atualizar os dados de um produto
        public void AtualizarProduto()
        {
            try
            {
                Console.WriteLine("\n *** ATUALIZAÇÃO DE PRODUTO *** \n");

                Console.Write("Entre com o ID do produto desejado.....: ");
                var idProduto = Guid.Parse(Console.ReadLine());

                var produtoRepository = new ProdutoRepository();
                var produto = produtoRepository.GetById(idProduto);

                //verificar o produto foi encontrado
                if (produto != null)
                {
                    Console.Write("Entre com o novo nome do produto.......: ");
                    produto.Nome = Console.ReadLine();

                    Console.Write("Entre com o novo preço do produto......: ");
                    produto.Preco = decimal.Parse(Console.ReadLine());

                    Console.Write("Entre com a nova quantidade do produto.: ");
                    produto.Quantidade = int.Parse(Console.ReadLine());

                    produtoRepository.Update(produto);

                    Console.WriteLine("\nPRODUTO ATUALIZADO COM SUCESSO NO BANCO DE DADOS!");
                }
                else
                {
                    Console.WriteLine("\nProduto não encontrado, verifique o ID informado.");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"\nFalha ao atualizar produto: {e.Message}");
            }
        }

        //Método para excluir um produto no banco de dados
        public void ExcluirProduto()
        {
            try
            {
                Console.WriteLine("\n *** EXCLUSÃO DE PRODUTO *** \n");

                Console.Write("Entre com o ID do produto desejado.....: ");
                var idProduto = Guid.Parse(Console.ReadLine());

                var produtoRepository = new ProdutoRepository();
                var produto = produtoRepository.GetById(idProduto);

                if (produto != null)
                {
                    produtoRepository.Delete(produto);

                    Console.WriteLine("\nPRODUTO EXCLUÍDO COM SUCESSO NO BANCO DE DADOS!");
                }
                else
                {
                    Console.WriteLine("\nProduto não encontrado, verifique o ID informado.");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"\nFalha ao excluir produto: {e.Message}");
            }
        }

        //Método para consultar todos os produtos no banco de dados
        public void ConsultarProdutos()
        {
            try
            {
                Console.WriteLine("\n *** CONSULTA DE PRODUTOS *** \n");

                var produtoRepository = new ProdutoRepository();
                var produtos = produtoRepository.GetAll();

                foreach (var item in produtos)
                {
                    Console.WriteLine($"Id do Produto.........: {item.IdProduto}");
                    Console.WriteLine($"Nome do Produto.......: {item.Nome}");
                    Console.WriteLine($"Quantidade do Produto.: {item.Quantidade}");
                    Console.WriteLine($"Preço do Produto......: {item.Preco}");
                    Console.WriteLine($"Data/Hora de cadastro.: {item.DataCadastro}");
                    Console.WriteLine("...");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"\nFalha ao excluir produto: {e.Message}");
            }
        }

    }
}



