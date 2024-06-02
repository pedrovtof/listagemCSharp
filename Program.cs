using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
//List<string> arrayGroup = new List<string>();

Dictionary<string, List<int>> arrayGroup = new Dictionary<string, List<int>>();

void MenuOpt()
{
    Console.Clear();
    string choseOpt;
    int convertChoseOpt;

    Console.WriteLine(@"
    ╔═══╦═══╦═══╦═══╦═══╦╗──╔╦═══╦════╦═══╗
    ║╔═╗║╔══╩╗╔╗║╔═╗║╔═╗║╚╗╔╝║╔═╗║╔╗╔╗║╔══╝
    ║╚═╝║╚══╗║║║║╚═╝║║─║╠╗║║╔╣║─║╠╝║║╚╣╚══╗
    ║╔══╣╔══╝║║║║╔╗╔╣║─║║║╚╝║║║─║║─║║─║╔══╝
    ║║──║╚══╦╝╚╝║║║╚╣╚═╝║╚╗╔╝║╚═╝║─║║─║║
    ╚╝──╚═══╩═══╩╝╚═╩═══╝─╚╝─╚═══╝─╚╝─╚╝
        ");
    Console.WriteLine("\nDigite 1 para adicionar registros de uma grupo");
    Console.WriteLine("Digite 2 para mostrar todos os grupos que possuo");
    Console.WriteLine("Digite 3 para avaliar um grupo");
    Console.WriteLine("Digite 4 para exibir a média de uma");
    Console.WriteLine("Digite -1 para sair");
    Console.Write("\nDigite a sua opcao: ");

    choseOpt = Console.ReadLine()!;

    convertChoseOpt = int.Parse(choseOpt);

    switch (convertChoseOpt) 
    {
        case 1: InputGroup();
            break;
        case 2: ListGroup();
            break;
        case 3: FeedbackGroup();
            break;
        case 4: AvgFeedbackGroup();
            break;
        case -1: Console.WriteLine("Encerrando :0 " + choseOpt);
            break;
        default: Console.WriteLine("Ops! Acho que voce digitou errado");
            break;

    }
}

void InputGroup()
{
    Console.WriteLine("Registro de grupo \nDigite o nome do grupo que deseja registrar");
    string name = Console.ReadLine();
    arrayGroup.Add(name, new List<int>());
    Console.WriteLine($"O grupo {name} foi registrado");
    Thread.Sleep(2000);
    MenuOpt();
}

void ListGroup(){
    foreach (var key in arrayGroup.Keys) 
    {
        Console.WriteLine($"{key} \n");
    }
    Console.WriteLine("Clique qualquer tecla para retornar");
    Console.ReadKey();
    MenuOpt();
}

void FeedbackGroup(){
    Console.WriteLine("Digite nome da grupo que deseja avaliar");
    string name = Console.ReadLine();
    if (arrayGroup.ContainsKey(name))
    {
        Console.Write($"De uma nota de 0 a 10 para {name}: ");
        int groupFeedback = int.Parse(Console.ReadLine());
        arrayGroup[name].Add(groupFeedback);
        Console.WriteLine("Registrado com sucesso");
        Thread.Sleep(2000);
    }
    else 
    {
        Console.WriteLine($"A banda {name} nao foi encontrada \nDigite qualquer tecla para retornar ao menu");
        Console.ReadKey();
    }
    MenuOpt();
}

void AvgFeedbackGroup(){

    Console.WriteLine("Digite nome do grupo que deseja avaliar");
    string name = Console.ReadLine();

    if (arrayGroup.ContainsKey(name))
    {
        arrayGroup.TryGetValue(name, out List<int> newList);
        double media = newList.Average();
        Console.WriteLine($"A media do grupo {name} é {media}");
        Console.WriteLine("Aperte qualquer tecla para retornar");
        Console.ReadKey();
    }
    else 
    {
        Console.WriteLine($"A banda {name} nao foi encontrada \nDigite qualquer tecla para retornar ao menu");
        Console.ReadKey();
    }
    MenuOpt();
}

MenuOpt();

