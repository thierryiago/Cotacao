
#region Exercício 1
Console.WriteLine("Exercício 1:");

int i, n, soma = 0;
Console.WriteLine("Entre com um número :");
n = Convert.ToInt32(Console.ReadLine());
if (n > 0)
{
    for (i = 1; i <= n; i++)
    {
        soma += i;
    }

    Console.WriteLine("Soma: " + soma);
}
else
    Console.WriteLine("O número precisa ser maior que 0");


#endregion



#region Exercício 2
Console.WriteLine("Exercício 2:");

List<string> lista = new List<string> { "abracadabra", "allottee", "assessee" };

foreach (var item in lista)
{
    Console.WriteLine("\n String inicial: " + item);
    Console.Write("String sem duplicações: ");
    var uniqueCharArray = item.ToCharArray().Distinct().ToArray();
    var resultString = new string(uniqueCharArray);

    Console.Write(resultString);
}

#endregion

