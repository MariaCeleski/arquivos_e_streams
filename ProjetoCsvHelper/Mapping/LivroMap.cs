//Um arquivo CSV é um arquivo separado por vírgulas, que é utilizado para armazenar dados de forma organizada. Ele normalmente armazena os dados em forma de tabela. A maioria das organizações empresariais armazena seus dados em arquivos CSV . 
//Em C#, podemos realizar várias operações em um arquivo CSV

using System.Globalization;
using CsvHelper.Configuration;
public class LivroMap : ClassMap<Livro>
{
    public LivroMap()
    {
        Map(x => x.Titulo)
            .Validate(field => field.ToString()?.Length < 10)
            .Name("titulo");
        Map(x => x.Preco)
            .Name("preço")
            .TypeConverterOption
            .CultureInfo(CultureInfo.GetCultureInfo("pt-BR"));
        Map(x => x.Autor).Name("autor");
        Map(x => x.Lancamento)
            .Name("lançamento")
            .TypeConverterOption
            .Format(new[] { "dd/MM/yyyy" });

    }

}
