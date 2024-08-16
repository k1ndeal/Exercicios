using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DesafioPOO {
    internal class Pedido {
        public int NumeroMesa { get; set; }
        public List<ItemCardapio> itens { get; set; } = new List<ItemCardapio>() {
         new ("frango",2500.00),
         new ("carne",4000.00),
         new ("dooce",500.00),
         new ("beringela",1200.00),


        };

        
        


        public double Total { get; set; }


        public void CriarPedido() {
            Console.WriteLine("faca um pedido");
            Console.WriteLine("itens do cardapio:");
            int i = 1;
            foreach (var item in itens) {

                Console.WriteLine($"({i}){item.ToString()}");
                i++;

            }
        }

        public ItemCardapio Add(int escolha) {
            return itens[escolha];

        }
        public double Get_Preco(int i) {
            return itens[i].Preco;
        }
    }
}
