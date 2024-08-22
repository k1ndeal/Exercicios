using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DesafioPOO
{
    internal class Pedido
    {
        public Mesa NumeroMesa { get; set; }
        public List<ItemCardapio> Cardapio { get; set; } = new List<ItemCardapio>();
        public double Total { get; set; }

        public Pedido(Mesa numeroMesa)
        {
            NumeroMesa = numeroMesa;
        }



        public Pedido() { }

        public void AddPedido(ItemCardapio item)
        {
            Cardapio.Add(item);
        }

        public void RemovePedido(ItemCardapio item)
        {
            Cardapio.Remove(item);
        }

        public void MostrarPediso()
        {
            foreach (ItemCardapio item in Cardapio)
            {
                Console.WriteLine(item);
            }
        }

        public void CalculoTotal()
        {
            foreach (ItemCardapio item in Cardapio)
            {
                Total += item.Preco;
            }
        }





    }
}
