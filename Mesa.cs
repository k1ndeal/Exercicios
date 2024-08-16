using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DesafioPOO {
    internal class Mesa {

        public int NumeroMesa { get; private set; }
        public bool status = true;
        public double TotalDaMesa {  get; set; }
        List<ItemCardapio> pedido = new List<ItemCardapio>();
        Pedido PedidoDaMesa = new Pedido();

        public Mesa(int Numero ) {
            NumeroMesa = Numero;
            status = true;
        }
        
      public void AtualizarMesa(int resposta) {
            NumeroMesa = resposta;
        }

        public void FazerPedido() {
            
            string res;
            do {
                PedidoDaMesa.CriarPedido();
                Console.WriteLine("faça um pedido:");
                int p = int.Parse(Console.ReadLine()) - 1;
                pedido.Add(PedidoDaMesa.Add(p));
                foreach (var iten in pedido) {
                    Console.WriteLine(iten);
                }
                Console.WriteLine("gostaria de algo a mais?(S/N)");
                res = Console.ReadLine();
            } while (res == "s");
            if (res != "s") {
                for (int i = 0; i < pedido.Count; i++) {
                     TotalDaMesa += PedidoDaMesa.Get_Preco(i);
                }
            }
            Console.WriteLine($"O total ficou {TotalDaMesa}");

        }



        public override string ToString() {
            return $"Mesa:{NumeroMesa},Disponibilidade: {status}";

        }

    }
}
