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
        public bool Status { get; private set; } = false;
        public double TotalDaMesa {  get; set; }
        List<ItemCardapio> Pedido = new List<ItemCardapio>();
        public double Total { get; private set; } = 0;
        public Mesa(int Numero ) {
            NumeroMesa = Numero;
        }

        public Mesa(int numeroMesa, bool status) : this(numeroMesa)
        {
           Status = status;
        }

        public void MudarDispo()
        {
            if (Status)
            {
                Status = false;

            }
            else
            {
                Status = true;
            }
        }

            public void AtualizarMesa(int resposta) {
            NumeroMesa = resposta;
        }

        /*public void FazerPedido() {
            
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

        }*/

           public void AddPedidoAMeesa(ItemCardapio pedido)
        {
            Pedido.Add(pedido);
        }
            public void FechandoPedido()
        {
            foreach (ItemCardapio item in Pedido)
            {
                Total += item.Preco;
            }
        }

        public override string ToString() {
            return $"Mesa:{NumeroMesa},Disponibilidade: {Status}";

        }

    }
}
