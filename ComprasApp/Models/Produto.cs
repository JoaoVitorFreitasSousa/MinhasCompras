using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace ComprasApp.Models
{
    public class Produto
    {
        string? _descricao;
        double _quantidade;
        double _preco;

        [AutoIncrement, PrimaryKey]
        public int Id { get; set; }

        public string? Descricao
        {
            get => _descricao; // retorna descricao
            set
            {
                if (value == null) // valor nulo = lança exceção
                {
                    throw new Exception("Descrição inválida");
                }

                _descricao = value; // Caso contrario, define valor
            }
        }

        public double Quantidade
        {
            get => _quantidade; //retorna quantidade
            set
            {   // converte valor para double, se falhar define como 0
                if (!double.TryParse(value.ToString(), out _quantidade))
                {
                    _quantidade = 0;
                }

                if (value <= 0) // menor ou igual a zero, lança exceção
                {
                    throw new Exception("Quantidade inválida");
                }

                _quantidade = value; // Caso contrario, define valor
            }
        }

        public double Preco //retorna preço
        {
            get => _preco;
            set
            {   // tenta converter para double, se falhar define como 0
                if (!double.TryParse(value.ToString(), out _preco))
                {
                    _preco = 0;
                }

                if (value <= 0) // menor ou igual a zero, lança exceção
                {
                    throw new Exception("Preço inválido");
                }

                _preco = value; // Caso contrario, define valor
            }
        }

        public double Total
        {
            get => Preco * Quantidade; // retorna o total calculado
        }
    }
}
