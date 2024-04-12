namespace DoctorManager.Helper;

public class DoctorHelper
{
    /// <summary>
    /// Returns Doctor objects, where info gather from user
    /// </summary>
    /// <param name="id">Id should be generated and provided</param>
    /// <returns>fully seeded doctor object</returns>
    /// <exception cref="Exception">If the name is null</exception>
    public static Doctor GetDoctor(int id)
    {
        var doctor = new Doctor(id);
        Console.Write("Doctors Name: ");
        doctor.Name = Console.ReadLine() ?? throw new Exception("Name should not be null") ;
        
        var validInput = false;

        do
        {
            try
            {
                int experience = GetNum("experience in years");
                doctor.Experience = experience;

                int age = GetNum("age in years");
                doctor.Age = age;

                validInput = true;
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
        } while (!validInput);
        
        UpdateQualification(doctor);
        UpdateSpecialization(doctor);

        return doctor;
    }

    /// <summary>
    /// Method to filter doctors based on given speciality
    /// </summary>
    /// <param name="doctors">Array of created doctors</param>
    public static void FilterBySpeciality(Doctor[] doctors)
    {
        
        Console.WriteLine("\n\nSelect the Specializations");
        for (var i = 0; i < Doctor.Specializations.Length; i++ )
            Console.WriteLine($"{i + 1}. {Doctor.Specializations[i]}");

        var option = Console.ReadLine();
        if (!int.TryParse(option, out var optionPos) || optionPos > Doctor.Specializations.Length)
        {
            Console.WriteLine($"invalid entry {option}");
            return;
        }

        var count = 0;
        var specialization = Doctor.Specializations[optionPos - 1];
        foreach (var doctor in doctors)
        {
            if (doctor.Specialization.Contains(specialization))
            {
                doctor.Display();
                count++;
            }
            
        }

        Console.WriteLine($"\n{count} Doctors found for Speciality : {specialization}.");
    }
    
    /// <summary>
    /// For getting qualification from cli
    /// </summary>
    /// <param name="doctor"></param>

    static void UpdateQualification(Doctor doctor)
    {
        Console.WriteLine("Select the Qualifications\nin order with space separation like 2 3");
        for (var i = 0; i < Doctor.Qualifications.Length; i++ )
        {
            Console.Write($"{i + 1}. {Doctor.Qualifications[i]} | ");
        }

        foreach (var option in Console.ReadLine()?.Split(" ")!)
        {
            if (!int.TryParse(option, out var optionPos) || optionPos > Doctor.Qualifications.Length )
            {
                Console.WriteLine($"invalid entry {option}");
                continue;
            }
            
            doctor.AddQualification(Doctor.Qualifications[optionPos - 1]);
        }
    }

    /// <summary>
    /// For getting Specialization from cli
    /// </summary>
    /// <param name="doctor"></param>
    static void UpdateSpecialization(Doctor doctor)
    {
        Console.WriteLine("Select the Specializations\nwith space separation like 2 3");
        for (var i = 0; i < Doctor.Specializations.Length; i++ )
        {
            Console.WriteLine($"{i + 1}. {Doctor.Specializations[i]}");
        }

        foreach (var option in Console.ReadLine()?.Split(" ")!)
        {
            if (!int.TryParse(option, out var optionPos) || optionPos > Doctor.Specializations.Length )
            {
                Console.WriteLine($"invalid entry {option}");
                continue;
            }
            doctor.AddSpecialization(Doctor.Specializations[optionPos - 1]);
        }
       
    }

    /// <summary>
    /// For getting Int type from users, until the user enter the valid one
    /// </summary>
    /// <param name="msg">Custom msg to be displayed</param>
    /// <returns></returns>
    public static int GetNum(string msg)
    {
        int res;
        Console.Write($"Enter {msg} ");
        while(!int.TryParse(Console.ReadLine(), out res))
            Console.WriteLine($"invalid type for {msg} int");
        return res;
    }
    
}