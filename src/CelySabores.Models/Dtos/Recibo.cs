using System;
using System.Collections.Generic;

namespace CelySabores.Models.Dtos
{
    /// <summary>
    /// Linha do recibo. O preco unitario e o pratico no momento do pedido,
    /// por isso nunca muda se o preco do prato for alterado depois.
    /// </summary>
    public class ReciboItem
    {
        public string Prato { get; set; }
        public int Quantidade { get; set; }
        public decimal PrecoUnitario { get; set; }
        public decimal Subtotal { get; set; }
        public string Observacao { get; set; }
    }

    /// <summary>
    /// Recibo de um pedido finalizado. Nao inclui forma de pagamento: o sistema
    /// so regista o valor recebido e o troco (requisito 8 e 9).
    /// </summary>
    public class Recibo
    {
        public int NumeroPedido { get; set; }
        public int NumeroMesa { get; set; }
        public string NomeCliente { get; set; }
        public DateTime DataHora { get; set; }
        public string FuncionarioNome { get; set; }
        public decimal Total { get; set; }
        public decimal ValorRecebido { get; set; }
        public decimal Troco { get; set; }

        /// <summary>Data/hora em que o recibo foi reimpresso, se for o caso.</summary>
        public DateTime? ReimpressoEm { get; set; }

        public IList<ReciboItem> Itens { get; set; }

        public Recibo()
        {
            Itens = new List<ReciboItem>();
        }

        public int NumeroItens
        {
            get
            {
                int total = 0;
                foreach (var item in Itens)
                {
                    total += item.Quantidade;
                }

                return total;
            }
        }
    }
}
