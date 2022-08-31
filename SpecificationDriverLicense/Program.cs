using System.Text.Json;
using SpecificationDriverLicense;

int edadParaEvaluar = 28;
var person = new PersonaModel
{
    Altura = 6,
    Id = 1,
    Edad = 24,
    Nombre = "Armando Ita"
};

//var result = EvaluateDriverLicenseByEdad(edadParaEvaluar, person) ? $"{person.Nombre} obtuvo la licencia" : "Licencia negada";
//Console.WriteLine(result);

bool EvaluateDriverLicenseByEdad(int edadParaEvaluar, PersonaModel personModel)
{
    var specification = new DriverLicenseBySpecification(edadParaEvaluar);
    return specification.IsCumpleReglas(personModel);

}

var personData = File.ReadAllText(@"person.json");
var persons = JsonSerializer.Deserialize<List<PersonaModel>>(personData);

var personsWithLicense = EvaluateCollectionPersonByLicenseDriver(persons, edadParaEvaluar);
personsWithLicense.ToList().ForEach(person => Console.WriteLine($"{person.Nombre} {person.Edad} obtuvó su licencia"));

IEnumerable<PersonaModel> EvaluateCollectionPersonByLicenseDriver(IEnumerable<PersonaModel> personsModel, int edadParaEvaluar)
{
    return personsModel.Where(x => EvaluateDriverLicenseByEdad(edadParaEvaluar, x));
}
