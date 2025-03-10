﻿//nuget.org - repositórios de bibliotecas .NET - procurar sempre a melor biblioteca, que tem mais dowload ou pesquisar no steack overflower
//verificar o "V" e pesquisar no site - get start de como fazer a instalação - .NETCli
//Um arquivo CSV é um arquivo separado por vírgulas, que é utilizado para armazenar dados de forma organizada. Ele normalmente armazena os dados em forma de tabela. 
//A maioria das organizações empresariais armazena seus dados em arquivos CSV . Em C#, podemos realizar várias operações em um arquivo CSV
using static System.Console;

CriarCsv();

WriteLine("\n\nPressione [enter] para finalizar");
ReadLine();


static void CriarCsv()
{
    var path = Path.Combine(
        Environment.CurrentDirectory,
        "Saida"
        );

    var pessoas = new List<Pessoa>(){
            new Pessoa()
            {
                Nome = "José da Silva",
                Email = "js@gmail.com",
                Telefone = 123456,
                Nascimento = new DateOnly(year: 1970, month: 2, day: 14)
            },
            new Pessoa(){
                Nome = "Pedro Paiva",
                Email = "pp@gmail.com",
                Telefone = 456789,
                Nascimento = new DateOnly(year: 2002, month: 4, day: 20)
            },
            new Pessoa()
            {
                Nome = "Maria Antonia",
                Email = "ma@gmail.com",
                Telefone = 123456,
                Nascimento = new DateOnly(year: 1982, month: 12, day: 4)
            },
            new Pessoa()
            {
                Nome = "Carla Moraes",
                Email = "cms@gmail.com",
                Telefone = 9987411,
                Nascimento = new DateOnly(year: 2000, month: 7, day: 20)
            }
        };

    var di = new DirectoryInfo(path);
    if (!di.Exists)
    {
        di.Create();
        path = Path.Combine(path, "usuarios.csv");
    }
    using var sw = new StreamWriter(path);
    sw.WriteLine("nome,email,telefone,nascimento");
    foreach (var pessoa in pessoas)
    {
        var linha = $"{pessoa.Nome},{pessoa.Email},{pessoa.Telefone},{pessoa.Nascimento}";
        sw.WriteLine(linha);
    }

}



static void LerCsv()
{
    var path = Path.Combine(
        Environment.CurrentDirectory,
        "Entrada",
        "usuarios-exportacao.csv");
    if (File.Exists(path))
    {
        using var sr = new StreamReader(path);
        var cabecalho = sr.ReadLine()?.Split(',');
        while (true)
        {
            var registro = sr.ReadLine()?.Split(',');//()?.Split(',') - caso Readline retorne Null, pra não dar erro usa-se ?
            if (registro == null) break;
            if (cabecalho.Length != registro.Length)
            {
                WriteLine("Arquivo fora do padrão");
                break;
            }
            for (int i = 0; i < registro.Length; i++)
            {
                WriteLine($"{cabecalho?[i]}:{registro[i]}");//? caso for nulo pra evitar de dar erro
            }
            WriteLine("--------------");
        }
    }
    else
    {
        WriteLine($"O arquivo {path} não existe");
    }
}

class Pessoa
{
    public string Nome { get; set; }
    public string Email { get; set; }
    public int Telefone { get; set; }
    public DateOnly Nascimento { get; set; }
}