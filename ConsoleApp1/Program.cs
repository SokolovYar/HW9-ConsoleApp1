List<Firm> Companies = new List<Firm>()
{
    new Firm("Apple", "IT", 1000, "USA, California, Coopetrino", "Voznyak", new DateTime(1976,04,01)),
    new Firm("White Food", "Food", 15, "London, Brownong street, 41", "Black Jack", new DateTime(2023,11,05)),
    new Firm("Crown tea", "Food", 150, "India, Deli", "Singur Ali", new DateTime(2020,01,01)),
    new Firm("White Rum", "Marketing", 250, "Ukraine, Odessa, Filatova, 2", "Andrey Tarasov", new DateTime(2015,09,01)),
    new Firm("Corsair White", "IT", 500, "London, Brownong street, 40", "Bob White", new DateTime(2023,10,25)),
    new Firm()
};

//Отримати інформацію про всі фірми
Console.WriteLine("Any firms in the list");
var Result = from it in Companies                                                               //LINQ way
             select it;
PrintQuery(Result);

var Result2 = Companies.Where(it2 => true);                                                     //old fashion way
PrintQuery(Result2);


//Отримати фірми, які мають у назві слово «Food».
Console.WriteLine("\nConsist Food in the name");
 Result = from it in Companies                                                               //LINQ way
             where it.Name.ToLower().IndexOf("FoOd".ToLower()) >= 0
             select it;
PrintQuery(Result);

Result2 = Companies.Where(it2 => it2.Name.ToLower().IndexOf("FoOd".ToLower()) >= 0);        //old fashion way
PrintQuery(Result2);

//Отримати фірми, які працюють у галузі маркетингу.
Console.WriteLine("\nConsist Marketing field");
Result = from it in Companies                                                               //LINQ way
         where it.Field.ToLower().IndexOf("Marketing".ToLower()) >= 0
         select it;
PrintQuery(Result);

Result2 = Companies.Where(it2 => it2.Field.ToLower().IndexOf("marketing".ToLower()) >= 0);   //old fashion way
PrintQuery(Result2);

//Отримати фірми, які працюють у галузі маркетингу або IT
Console.WriteLine("\nConsist Marketing or IT field");
Result = from it in Companies                                                               //LINQ way
         where it.Field.ToLower().IndexOf("Marketing".ToLower()) >= 0 || it.Field.ToLower().IndexOf("IT".ToLower()) >= 0
         select it;
PrintQuery(Result);

Result2 = Companies.Where(it2 => it2.Field.ToLower().IndexOf("marketing".ToLower()) >= 0 || it2.Field.ToLower().IndexOf("IT".ToLower()) >= 0);        //old fashion way
PrintQuery(Result2);

//Отримати фірми з кількістю працівників більшою, ніж 100.
Console.WriteLine("\nEmployees is more than 100");
Result = from it in Companies                                                               //LINQ way
         where it.EmployeeCount > 100
         select it;
PrintQuery(Result);

Result2 = Companies.Where(it2 => it2.EmployeeCount > 100);                                  //old fashion way
PrintQuery(Result2);


//Отримати фірми з кількістю працівників у діапазоні від 100 до 300.
Console.WriteLine("\nEmployees is more than 100 and less than 300" );
Result = from it in Companies                                                               //LINQ way
         where it.EmployeeCount > 100 && it.EmployeeCount < 300
         select it;
PrintQuery(Result);

Result2 = Companies.Where(it2 => it2.EmployeeCount > 100 && it2.EmployeeCount < 300);        //old fashion way
PrintQuery(Result2);


//Отримати фірми, які знаходяться в Лондоні.
Console.WriteLine("\nPlaced in London");
Result = from it in Companies                                                               //LINQ way
         where it.Adres.ToLower().IndexOf("London".ToLower()) >= 0
         select it;
PrintQuery(Result);

Result2 = Companies.Where(it2 => it2.Adres.ToLower().IndexOf("London".ToLower()) >= 0);      //old fashion way
PrintQuery(Result2);


//Отримати фірми, в яких прізвище директора White.
Console.WriteLine("\nCEO is Mr(s) White");
Result = from it in Companies                                                                 //LINQ way
         where it.CEO_Surname.ToLower().IndexOf("WHITE".ToLower()) >= 0
         select it;
PrintQuery(Result);

Result2 = Companies.Where(it2 => it2.CEO_Surname.ToLower().IndexOf("WHITE".ToLower()) >= 0);    //old fashion way
PrintQuery(Result2);


//Отримати фірми, які засновані більше двох років тому.
Console.WriteLine("\nFounded earlier than 2 years ago");
Result = from it in Companies                                                               //LINQ way
         where it.Foundation.Year > DateTime.Today.Year - 2
         select it;
PrintQuery(Result);

Result2 = Companies.Where(it2 => it2.Foundation.Year > DateTime.Today.Year - 2);        //old fashion way
PrintQuery(Result2);

//Отримати фірми з дня заснування яких минуло 123 дні.
Console.WriteLine("\nFounded earlier than 123 days ago");
Result = from it in Companies                                                               //LINQ way
         where it.Foundation.AddDays(123) > DateTime.Today
         select it;
PrintQuery(Result);

Result2 = Companies.Where(it2 => it2.Foundation.AddDays(123) > DateTime.Today);        //old fashion way
PrintQuery(Result2);

//Отримати фірми, в яких прізвище директора Black і мають у назві фірми слово «White».
Console.WriteLine("\nCEO is Mr(s) Black and firm consist White in the it`s name");
Result = from it in Companies                                                               //LINQ way
         where it.CEO_Surname.ToLower().IndexOf("Black".ToLower()) >= 0 && it.Name.ToLower().IndexOf("White".ToLower()) >= 0
         select it;
PrintQuery(Result);

Result2 = Companies.Where(it2 => it2.CEO_Surname.ToLower().IndexOf("Black".ToLower()) >= 0 && it2.Name.ToLower().IndexOf("White".ToLower()) >= 0);        //old fashion way
PrintQuery(Result2);




void PrintQuery (IEnumerable<Firm> _it)
{
    foreach (var result in _it)
        Console.WriteLine(result);
}
public class Firm
{
    public string Name { get; set; }
    public string Field { get; set; }
    public int EmployeeCount { get; set; }
    public string Adres { get; set; }
    public string CEO_Surname { get; set; }
    public DateTime Foundation { get; set; }

    public Firm (string name, string field, int employeeCount, string adres, string cEO_Surname, DateTime foundation)
    {
        Name = name;
        Field = field;
        EmployeeCount = employeeCount;
        Adres = adres;
        CEO_Surname = cEO_Surname;
        Foundation = foundation;
    }
    public Firm ()
    {
        Field = Adres = CEO_Surname = Name = "NoData";
        EmployeeCount = 1;
        DateTime temp = DateTime.Today;
        Foundation = temp;
    }

    public override string ToString()
    {
        return $"Firm data: {Name ?? ""}, {Field ?? ""}, {EmployeeCount} employeers, {Adres ?? ""}, {CEO_Surname ?? ""}, {Convert.ToString(Foundation)}";
    }
}