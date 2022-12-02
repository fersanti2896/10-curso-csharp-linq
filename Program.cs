
using Linq.Clases;

Console.WriteLine("¡LINQ!");

int[] numeros = Enumerable.Range(0, 21)
                          .ToArray();

/* Sentencia Linq */
var pares = numeros.Where(n => n % 2 == 0 && n > 0)
                   .ToList();

foreach (var par in pares) {
    Console.WriteLine($"Número par: {par}");
}

Console.WriteLine();

/* Por Query */
/*var pares2 = (from n in numeros
              where n % 2 == 0
              select n).ToList();

foreach (var par in pares2) {
    Console.Write($"{par} ");
}*/

var impares = numeros.Where(n => n % 2 == 1 && n > 0)
                   .ToList();

foreach (var impar in impares) {
    Console.WriteLine($"Número impar: {impar}");
}

Console.WriteLine();

/* Filtrado con Where */
var personas = new List<Persona>() {
    new Persona { Nombre = "Fernando Nicolás", Edad = 25, FechaIngreso = new DateTime(2022, 04, 19), Soltero = true },
    new Persona { Nombre = "Maria Dae", Edad = 22, FechaIngreso = new DateTime(2022, 02, 28), Soltero = true },
    new Persona { Nombre = "Marisol Contreras", Edad = 25, FechaIngreso = new DateTime(2022, 10, 12), Soltero = false },
    new Persona { Nombre = "Luis Nicolás", Edad = 31, FechaIngreso = new DateTime(2014, 01, 25), Soltero = true },
    new Persona { Nombre = "Wendy Torres", Edad = 24, FechaIngreso = new DateTime(2022, 09, 07), Soltero = true }
};

var porEdad = personas.Where(p => p.Edad <= 25)
                      .ToList();

foreach (var persona in porEdad) {
    Console.WriteLine($"{ persona.Nombre } tiene { persona.Edad } años.");
}

Console.WriteLine();

var solteros = personas.Where(p => p.Soltero).ToList();

foreach (var persona in solteros) {
    Console.WriteLine($"{ persona.Nombre } es soltero/a.");
}

/* First y FirstOrDefault */
var primeraPersona = personas.First();
var primeraPersona2 = personas.FirstOrDefault();

Console.WriteLine($"Nombre: { primeraPersona.Nombre } | Edad: { primeraPersona.Edad } | Fecha de Ingreso: { primeraPersona.FechaIngreso }");
Console.WriteLine($"Nombre: { primeraPersona2.Nombre } | Edad: { primeraPersona2.Edad } | Fecha de Ingreso: { primeraPersona2.FechaIngreso }");

var paises = new List<string>();

// var primerPais = paises.First();
var primerPais2 = paises.FirstOrDefault();

Console.WriteLine($"Pais: { primerPais2 }");

var mayorDeEdad = personas.First(p => p.Edad >= 18);
Console.WriteLine($"Nombre: { mayorDeEdad.Nombre } | Edad: { mayorDeEdad.Edad } | Fecha de Ingreso: { mayorDeEdad.FechaIngreso }");

var mayorDeEdad100 = personas.FirstOrDefault(p => p.Edad > 100);

if (mayorDeEdad100 is null) {
    Console.WriteLine($"No hay persona mayor a 100 años.");
}

var personaTercerPiso = personas.Where(p => p.Edad >= 30)
                                .FirstOrDefault();

Console.WriteLine($"Nombre: { personaTercerPiso.Nombre } | Edad: { personaTercerPiso.Edad } | Fecha de Ingreso: { personaTercerPiso.FechaIngreso }");

Console.WriteLine();