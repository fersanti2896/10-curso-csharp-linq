
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

/* Funciones escalares */
Console.WriteLine($"Cantidad total: { personas.Count() } de personas.");
Console.WriteLine($"Cantidad total: { personas.Count(s => s.Soltero) } de personas solteras.");
Console.WriteLine($"Suma total de edades: { personas.Sum(s => s.Edad) } años.");
Console.WriteLine($"Edad mínima: { personas.Min(e => e.Edad) } años.");
Console.WriteLine($"Edad máxima: { personas.Max(e => e.Edad) } años.");
Console.WriteLine($"Promedio de edad: { personas.Average(e => e.Edad) } años.");
Console.WriteLine();

/* Ejemplo con All */
Console.WriteLine($"¿Son todas las personas mayores de edad? { personas.All(p => p.Edad >= 18) }");
Console.WriteLine($"¿Son todas las personas solteras? { personas.All(p => p.Soltero) }");

/* Ejemplo con Any */
Console.WriteLine($"¿Existe alguna persona menor a 18 años? { personas.Any(p => p.Edad <= 18) }");
Console.WriteLine($"¿Existe alguna persona mayor a 35 años? { personas.Any(p => p.Edad >= 35) }");
Console.WriteLine($"");

/* Ejemplo con contains */
var num = Enumerable.Range(1, 20);
Console.WriteLine($"¿Está el 3 contenido en el arreglo? { num.Contains(3) }");
Console.WriteLine($"¿Está el 32 contenido en el arreglo? { num.Contains(32) }");
Console.WriteLine($"");

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

Console.WriteLine($"Nombre: { personaTercerPiso.Nombre } | Edad: { personaTercerPiso.Edad } | Fecha de Ingreso: { personaTercerPiso.FechaIngreso }\n");

/* Order By */
foreach (var persona in personas.OrderBy(p => p.Edad)) {
    Console.WriteLine($"{ persona.Nombre } tiene { persona.Edad } años.");
}

Console.WriteLine();

foreach (var persona in personas.OrderByDescending(p => p.Edad)) {
    Console.WriteLine($"{ persona.Nombre } tiene { persona.Edad } años.");
}

Console.WriteLine();

/* Proyección con Select */
/* Seleccionando una propiedad */
var nombres = personas.Select(p => p.Nombre).ToList();

foreach (var persona in nombres) {
    Console.WriteLine($"{ persona }");
}

Console.WriteLine();

/* Seleccionando varias propiedades con tipo anonimo */
var nombresFechaIngreso = personas.Select(p => new { 
                                        Nombre = p.Nombre,
                                        FechaIngreso = p.FechaIngreso
                                   }).ToList();

foreach (var persona in nombresFechaIngreso) {
    Console.WriteLine($"Nombre: { persona.Nombre } Fecha de Ingreso: { persona.FechaIngreso }");
}

Console.WriteLine();

/* Seleccionando varias propiedades a una clase */
var personaDTO = personas.Select(p => new PersonaDTO {
                            Nombre = p.Nombre,
                            Edad = p.Edad
                         }).ToList();

foreach (var persona in personaDTO) {
    Console.WriteLine($"Nombre: { persona.Nombre } Edad: { persona.Edad } años.");
}

Console.WriteLine();

/* Tomando el indice */
var indicePersona = personas.Select((per, ind) => new { Nombre = per.Nombre, Orden = ind + 1 })
                            .ToList();

foreach (var persona in indicePersona) {
    Console.WriteLine($"{ persona.Orden }.- { persona.Nombre }.");
}

Console.WriteLine();

/* Producto Cartesiano con SelectMany */
var personas2 = new List<Persona>() { 
    new Persona { Nombre = "Jessica", Telefonos = { "55-2341-3254", "55-2132-5567" } },
    new Persona { Nombre = "Maria", Telefonos = { "55-6574-3829", "55-9182-7465" } },
    new Persona { Nombre = "Wendy", Telefonos = { "55-0165-3829", "55-9876-4567" } },
    new Persona { Nombre = "Fernanda", Telefonos = { "55-2233-7788", "55-2200-8765" } },
    new Persona { Nombre = "Ingrid", Telefonos = { "55-0174-2934" } },
    new Persona { Nombre = "Ingrid", Telefonos = { "55-0174-2934" } }
};

var telefonos = personas2.SelectMany(t => t.Telefonos).ToList();

foreach (var tel in telefonos) {
    Console.WriteLine($"Telefonos: { tel }.");
}

Console.WriteLine();

var infoPersonas = personas2.SelectMany(t => t.Telefonos, (persona, telefono) => new { 
    Nombre = persona.Nombre,
    telefono = telefono
});

foreach (var per in infoPersonas) {
    Console.WriteLine($"Nombre: { per.Nombre } Telefono: { per.telefono }.");
}

Console.WriteLine();

/* Take y skip */
Console.WriteLine($"Primeros 10 números");
var lista = num.Take(10).ToList();

foreach (var numero in lista) {
    Console.WriteLine($"Número: { numero }");
}

Console.WriteLine("\nUltimos 10 números");
var lista2 = num.TakeLast(10).ToList();

foreach (var numero in lista2) {
    Console.WriteLine($"Número: { numero }");
}

Console.WriteLine("\nBloque de 10 numeros pasando los primeros 5 números");
var lista3 = num.Skip(5).Take(10).ToList();

foreach (var numero in lista3) {
    Console.WriteLine($"Número: { numero }");
}

Console.WriteLine("\nBloque de 10 numeros anticipando los ultimos 5 números");
var lista4 = num.SkipLast(5).TakeLast(10).ToList();

foreach (var numero in lista4) {
    Console.WriteLine($"Número: { numero }");
}

/* Agrupando con GroupBy */
Console.WriteLine();
var agrupamiento = personas.GroupBy(p => p.Soltero);

foreach (var grupo in agrupamiento) {
    Console.WriteLine($"Grupo de Solteros: { grupo.Key } Total de Solteros: { grupo.Count() }");
    foreach (var persona in grupo) {
        Console.WriteLine($"Nombre: { persona.Nombre }");
    }
}

Console.WriteLine();

/* Eliminando repetidos con Distinct y DistinctBy */
int[] num2 = { 1, 2, 2, 4, 2, 5, 3, 2, 1 };
var repNum = num2.Distinct();

foreach (var i in repNum) {
    Console.WriteLine($"Numero: { i }");
}
Console.WriteLine();

var repPersonas = personas2.DistinctBy(p => p.Nombre).ToList();

foreach (var persona in repPersonas) {
    Console.WriteLine($"Nombre: { persona.Nombre }");
}

Console.WriteLine();

var secciones = num2.Chunk(3);

foreach (var arreglo in secciones) {
    Console.WriteLine($"Arreglo: { arreglo }");
    foreach (var item in arreglo) {
        Console.WriteLine($"{item}");
    }
}
