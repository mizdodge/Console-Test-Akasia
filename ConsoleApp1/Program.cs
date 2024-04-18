// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");

using System.ComponentModel.DataAnnotations;
using System.Globalization;

bool valid = false;

var menu = new Menu();
menu.MenuList();

public class Menu
{
    public bool loop = true;
    Dictionary<int, ModelEmployee> dataGlobalisasi = new Dictionary<int, ModelEmployee>();

    public void MenuList()
    {

        dataGlobalisasi.Add(1001, new ModelEmployee
        {
            FullName = "Adit",
            BirthDate = DateTime.ParseExact("2024-04-17", "yyyy-MM-dd", CultureInfo.InvariantCulture)
        }
        );
        dataGlobalisasi.Add(1002, new ModelEmployee
        {
            FullName = "Anton",
            BirthDate = DateTime.ParseExact("2024-04-18", "yyyy-MM-dd", CultureInfo.InvariantCulture)
        }
        );
        dataGlobalisasi.Add(1003, new ModelEmployee
        {
            FullName = "Amir",
            BirthDate = DateTime.ParseExact("2024-04-19", "yyyy-MM-dd", CultureInfo.InvariantCulture)
        }
        );
        while (loop)
        {
            Console.WriteLine("\n================ Menu ====================\n1. Add Data\n2. Delete Data\n3. View Data\n4. Exit \n================ Menu ====================");
            Console.Write("Input Choice : ");
            string? choices = Console.ReadLine();
            if (choices != null)
            {
                try
                {
                    int choice = int.Parse(choices);
                    if (choice < 0 || choice > 4)
                    {
                        throw new Exception();
                    }
                    else
                    {
                        if (choice == 4)
                        {
                            return;
                        }
                        else if (choice == 3)
                        {
                            ListPerson();
                        }
                        else if (choice == 2)
                        {
                            DeletePerson();
                        }
                        else
                        {
                            AddPerson();
                        }
                    }
                }
                catch
                {
                    Console.WriteLine("Choices is not available");
                }
            }
        }
    }
    public void ListPerson()
    {
        Console.WriteLine("================ List Person ====================");

        Console.WriteLine("=================================================");
        Console.WriteLine("EmployeeId\tFullname\tBirthDate");
        Console.WriteLine("=================================================");
        foreach (var item in dataGlobalisasi)
        {
            Console.WriteLine($"{item.Key}\t{item.Value.FullName}\t{item.Value.BirthDate.ToString("dd-MMM-yy")}");
        }
        Console.WriteLine("================ List Person ====================");
    }
    public void DeletePerson()
    {
        Console.Write("Which one you want to delete ? ");
        string? choices = Console.ReadLine();
        if (choices != null)
        {
            try
            {
                int choice = int.Parse(choices);
                if (!dataGlobalisasi.ContainsKey(choice))
                {
                    throw new Exception();
                }
                else
                {
                    dataGlobalisasi.Remove(choice);
                }

                Console.WriteLine("Delete Successfully");
            }
            catch
            {
                Console.WriteLine("\nChoices is not available\n");
            }
        }
    }
    public void AddPerson()
    {
        Random random = new Random();
        bool ExitOrNot = true;
        while (ExitOrNot)
        {
            int keys = random.Next();
            if (!dataGlobalisasi.ContainsKey(keys))
            {
                bool exitOrnot2 = true;
                while (exitOrnot2)
                {
                    try
                    {
                        Console.Write("Input Fullname : ");
                        string? fullName = Console.ReadLine();
                        Console.Write("Input Birth Date (yyyy-MM-dd) : ");
                        string? birthDay = Console.ReadLine();
                        DateTime birthDate = new DateTime();
                        if (string.IsNullOrEmpty(fullName))
                        {
                            Console.WriteLine("Fullname Cannot Empty");
                        }
                        else if (string.IsNullOrEmpty(birthDay))
                        {
                            Console.WriteLine("Birthdate not correct");
                        }
                        else
                        {
                            try
                            {
                                birthDate = DateTime.ParseExact(birthDay, "yyyy-MM-dd", CultureInfo.InvariantCulture);

                                dataGlobalisasi.Add(keys, new ModelEmployee
                                {
                                    FullName = fullName,
                                    BirthDate = birthDate
                                });
                                ExitOrNot = false;
                                Console.WriteLine("Success Add New");
                                break;
                            }
                            catch
                            {
                                Console.WriteLine("Birthday not correct");
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        {
                            Console.WriteLine(ex.Message.ToString());
                        }
                    }
                }
            }
        }
    }
    public class ModelEmployeeId
    {
        public int EmployeeId { get; set; }
    }
    public class ModelEmployee
    {
        public string FullName { get; set; }
        public DateTime BirthDate { get; set; }
    }
}