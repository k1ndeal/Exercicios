using DesafioPOO;
using System.ComponentModel;
using System.Diagnostics.Tracing;
using System.Globalization;
using System.Net.Http.Headers;
using System.Runtime.InteropServices;
using System.Xml.Linq;

List<Mesa> mesas = new List<Mesa>() {
 new Mesa(1),
 new Mesa(2,true),
 new Mesa(3),
 new Mesa(4),


};
List<ItemCardapio> cardapio = new List<ItemCardapio>() {

new ("peixe",199.99),
new ("frango",199.99),
new ("Carne",199.99),
new ("escarola",199.99),

};
List<Pedido> pedidos = new List<Pedido>();

//metodos

void mesa()
{
    void addmesa()
    {
        while (true)
        {
            Console.WriteLine("escolha uma mesa");
            int numeromesa = int.Parse(Console.ReadLine());
            bool MesaExiste = mesas.Any(mesa => mesa.NumeroMesa == numeromesa);
            if (MesaExiste == false)
            {
                mesas.Add(new Mesa(numeromesa));
                break;
            }
            else
            {
                Console.WriteLine("esse numero ja existe escolha outro");
            }
        }
    }//funcionando
    void attmesa()
    {
        foreach (var item in mesas)
        {
            Console.WriteLine($"Mesa:{item}");
        }
        Console.WriteLine("Escolha o numero da mesa que deseja atualizar");
        int i = int.Parse(Console.ReadLine());
        Mesa MesaSelecionada = mesas.Where(m => m.NumeroMesa == i).FirstOrDefault();
        Console.WriteLine($"Mesa {MesaSelecionada} escolhida, insira o Numero que deseja colocar:");
        while (true)
        {

            int numeromesa = int.Parse(Console.ReadLine());
            bool MesaExiste = mesas.Any(mesa => mesa.NumeroMesa == numeromesa);
            if (MesaExiste == false)
            {
                int IndiceMesa = mesas.IndexOf(MesaSelecionada);
                mesas[IndiceMesa].AtualizarMesa(numeromesa);
                break;
            }
            else
            {
                Console.WriteLine("esse numero ja existe escolha outro");
            }
        }
    }//funcionando
    void removemesa()
    {
        Console.WriteLine("escolha a mesa que quer remover:");
        foreach (var item in mesas)
        {
            Console.WriteLine(item);
        }
        while (true)
        {
            int i = int.Parse(Console.ReadLine());
            Mesa MesaSelecionada = mesas.Where(m => m.NumeroMesa == i).FirstOrDefault();
            Console.WriteLine($"{MesaSelecionada} Selecionada, Deseja remover(1) ou mudar sua escolha(2)?");
            int respo = int.Parse(Console.ReadLine());
            if (respo == 1)
            {
                Console.WriteLine($"{MesaSelecionada} Removida!");
                mesas.Remove(MesaSelecionada);
                break;
            }

        }

    }//funcionando
    Console.Clear();

    Console.WriteLine("1-Adicionar mesa");
    Console.WriteLine("2-Atualizar mesa");
    Console.WriteLine("3-Apagar  mesa");
    Console.WriteLine("4- Sair");
    int resposta = int.Parse(Console.ReadLine());
    switch (resposta)
    {
        case 1:

            addmesa();

            break;
        case 2:

            attmesa();

            break;
        case 3:
            removemesa();
            break;
        case 4:
            break;
    }

}//completo
void Cardapio()
{
    string verification(string nome)
    {
        while (true)
        {
            ItemCardapio ItemSelecionado = cardapio.Where(i => i.Nome == nome).FirstOrDefault();
            if (ItemSelecionado == null)
            {
                Console.WriteLine($"O {ItemSelecionado} n Existe! Escolha outro");
                nome = Console.ReadLine();
            }
            else
            {
                return nome;

                break;
            }
        }
    }//funcionando
    void AddCardapio()
    {
        foreach (var item in cardapio)
        {
            Console.WriteLine(item);
        }

        while (true)
        {
            Console.WriteLine("Qual o nome?");
            string nome = Console.ReadLine();
            verification(nome);


            Console.WriteLine("Qual o valor?");
            double preco = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            cardapio.Add(new ItemCardapio(nome, preco));
            break;

        }
    }//FUNCIONANDO
    void RemoveCardapio()
    {
        foreach (var item in cardapio)
        {
            Console.WriteLine(item);
        }

        while (true)
        {
            Console.WriteLine("Qual vc gostaria de remover?");

            string nome = Console.ReadLine();
            verification(nome);
            ItemCardapio ItemSelecionado = cardapio.Where(i => i.Nome == nome).FirstOrDefault();

            {
                Console.WriteLine($"{ItemSelecionado} Selecionado! Remover(1) ou Escolher outro(2)?");
                int i = int.Parse(Console.ReadLine());
                if (i == 1)
                {
                    int IndiceCardapio = cardapio.IndexOf(ItemSelecionado);
                    Console.WriteLine($"{ItemSelecionado} removido!");
                    cardapio.Remove(ItemSelecionado);
                    break;
                }
            }
        }


    }//FUNCIONANDO
    void AttCardapio()
    {
        while (true)
        {
            foreach (var item in cardapio)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("Qual gostaria de modificar?");
            string nome = Console.ReadLine();

            verification(nome);
            ItemCardapio ItemSelecionado = cardapio.Where(i => i.Nome == nome).FirstOrDefault();


            Console.WriteLine($"{ItemSelecionado} Selecionado! Oque gostaria de modificar? Nome(1) ou Preco(2)");
            int escolha = int.Parse(Console.ReadLine());
            switch (escolha)
            {
                case 1:

                    Console.WriteLine("escolha o nome:");
                    nome = Console.ReadLine();
                    verification(nome);
                    int IndiceCardapio = cardapio.IndexOf(ItemSelecionado);
                    cardapio[IndiceCardapio].Set_Nome(nome);



                    break;
                case 2:
                    Console.WriteLine("Escolha o Preço:");
                    double preco = double.Parse(Console.ReadLine());
                    IndiceCardapio = cardapio.IndexOf(ItemSelecionado);
                    cardapio[IndiceCardapio].Set_Preco(preco);
                    break;
            }


        }
    }
    void MudarDispo()
    {
        Console.WriteLine("Qual Item gostaria de Mudar a disponibilidade??");
        string nome = Console.ReadLine();
        ItemCardapio ItemSelecionado = cardapio.Where(i => i.Nome == nome).FirstOrDefault();
        Console.WriteLine("gostaria de Deixar disponivel(1) ou Indisponivel(2)?");
        int respo = int.Parse(Console.ReadLine());

        switch (respo)
        {
            case 1:
                int IndiceCardapio = cardapio.IndexOf(ItemSelecionado);
                cardapio[IndiceCardapio].Set_DisponivelTrue();
                break;
            case 2:
                IndiceCardapio = cardapio.IndexOf(ItemSelecionado);
                cardapio[IndiceCardapio].Set_DisponivelFalse();
                break;
        }

    }

    Console.WriteLine("1-Adicionar item ao cardaio");
    Console.WriteLine("2-Remover item do cardaio");
    Console.WriteLine("3-Modificar item Do cardaio");
    Console.WriteLine("4-sair");
    int respo = int.Parse(Console.ReadLine());

    switch (respo)
    {
        case 1:
            AddCardapio();

            break;
        case 2:
            RemoveCardapio();
            break;
        case 3:
            AttCardapio();
            break;
        case 4:

            break;



    }
}//completo
void Pedido()
{
    
    string Verification(string nome)
    {
        while (true)
        {
            ItemCardapio ItemSelecionado = cardapio.Where(i => i.Nome == nome).FirstOrDefault();
            if (ItemSelecionado == null)
            {
                Console.WriteLine($"O {ItemSelecionado} n Existe! Escolha outro");
                nome = Console.ReadLine();
            }
            else
            {
                return nome;

                break;
            }
        }
    }//funcionando

    if (mesas.All(i => !i.Status))
    {
        Console.WriteLine("Todas as mesas estao ocupadas! espere fehcar o pedido!");
        Console.ReadLine();
    }
    else
    {    foreach (Mesa mesa in mesas)
        {
            if (mesa.Status)
            {
                Console.WriteLine(mesa);
            }
        }
        Console.WriteLine("Escolha uma mesa: ");
        int escolha = int.Parse(Console.ReadLine());

        Mesa Mesaselecionada = mesas.Where(i => i.NumeroMesa == escolha).FirstOrDefault();
        if (Mesaselecionada.Status)
        {

            while (true)
            {
                Console.WriteLine("Escolha um item do cardapio:");
                foreach (ItemCardapio item in cardapio)
                {
                    Console.WriteLine(item);
                }

                string Escolha = Console.ReadLine();
                while (true)
                {
                    ItemCardapio ItemSelecionad = cardapio.Where(i => i.Nome == Escolha).FirstOrDefault();
                    if (ItemSelecionad == null)
                    {
                        Console.WriteLine($"O {ItemSelecionad} n Existe! Escolha outro");
                        Escolha = Console.ReadLine();
                    }
                    else
                    {


                        break;
                    }
                }

                //Verification(Escolha);
                ItemCardapio ItemSelecionado = cardapio.Where(i => i.Nome == Escolha).FirstOrDefault();
                int i = mesas.IndexOf(Mesaselecionada);

                mesas[i].AddPedidoAMeesa(ItemSelecionado);



                Console.WriteLine("gostaria de pedir mais alguma coisa?(S/N)");
                string n = Console.ReadLine();
                if (n == "N" || n == "n")
                {
                    mesas[i].MudarDispo();
                    break;

                }
            }

        }
        else
        {
            Console.WriteLine("Mesa Indisponivel! Escolha outra:");

        }
       
    }





}//funcionando
void fecharPedido()
{
    foreach(Mesa mesa in mesas)
    {
        if (!mesa.Status )
        {
            Console.WriteLine(mesa);
        }
    }

    Console.WriteLine("Escolha a mesa que deseja fechar");
    int escolha = int.Parse(Console.ReadLine());

    Mesa m = mesas.Where(m => m.NumeroMesa == escolha).FirstOrDefault();
    Console.WriteLine(m);
    m.FechandoPedido();
    Console.WriteLine($"Ficou {m.Total.ToString("c")}");
    m.MudarDispo();
    Console.ReadLine();

}
while (true)
{
    Console.Clear();
    Console.WriteLine("1-Mesa");
    Console.WriteLine("2-Cardapio");
    Console.WriteLine("3-Criar pedido");
    Console.WriteLine("4-Fechar pedido");
    int respo = int.Parse(Console.ReadLine());
    switch (respo)
    {
        case 1:

            mesa();

            break;
        case 2:

            Cardapio();

            break;
        case 3:
            Pedido();
            break;
        case 4:
            fecharPedido(); 
            break;
    }


}


foreach (var mesinha in mesas)
{
    Console.WriteLine(mesinha);

}





/*
for (int i = 0; i < mesas.Count; i++){
    Console.WriteLine($"Mesa {mesas[i].NumeroMesa}:");
    mesas[i].FazerPedido();
    total += mesas[i].TotalDaMesa;

}

foreach(var sla in mesas) {
    Console.WriteLine(sla);
    Console.WriteLine($"total de lucro do dia {total.ToString("c")}");
}

Mesa Pedidos = new Mesa ();
double total = 0;
total = Pedidos.FazerPedido();
Console.WriteLine(total);*/
