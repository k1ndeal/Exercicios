using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DesafioPOO {
    internal class ItemCardapio {
        public string Nome { get; private set; }
        public double Preco { get; private set; }
        public bool Disponivel { get;  private set; }

        public ItemCardapio(string nome, double preco) {
            Nome = nome;
            Preco = preco;
        }
        public void Set_Nome(string nome)
        {
            Nome = nome;
        }

        public void Set_Preco(double preco)
        {
            Preco = preco;

        }
            public void Set_DisponivelTrue()
        {
            Disponivel = true;

        }

        public void Set_DisponivelFalse()
        {
            Disponivel = false;

        }

        public override string ToString() {
            return $"{Nome}, {Preco.ToString("c")}";
        }

    }



}
