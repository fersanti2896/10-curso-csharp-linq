
Console.WriteLine("¡LINQ!");

int[] numeros = Enumerable.Range(0, 20)
                          .ToArray();

/* Sentencia Linq */
var pares = numeros.Where(n => n % 2 == 0)
                   .ToList();

foreach (var par in pares) {
    Console.Write($"{par} ");
}

Console.WriteLine();

/* Por Query */
var pares2 = (from n in numeros
              where n % 2 == 0
              select n).ToList();

foreach (var par in pares2) {
    Console.Write($"{par} ");
}