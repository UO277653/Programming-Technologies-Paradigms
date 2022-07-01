
using System;

namespace TPP.Laboratory.ObjectOrientation.Lab02 {

    /// <summary>
    /// Default argument values
    /// </summary>
    class DefaultArgumentValues {


        /// <summary>
        /// This method filters all the people with:
        /// - A specific first name
        /// - A specific surname name
        /// - A part of an ID number
        /// Comparison should not be case-sensitive
        /// Returns the people fulfilling the criteria
        /// </summary>
        static Person[] Filter(Person[] people, string firstName = null, string surname = null, string idNumberContains = null) {
            // * Array.Resize changes the array size 
            Person[] res = new Person[people.Length];

            for (int i = 0; i < people.Length; i++) // Copying array
            {
                res[i] = people[i];
            }

            int n = res.Length - 1;

            if(firstName != null) // We filter by firstName
            {
                for (int i = 0; i < res.Length; i++)
                {
                    if (res[i] != null)
                    {
                        if (!res[i].FirstName.Equals(firstName))
                        {
                            res[i] = null;
                        }
                    }
                }
            }

            if (surname != null)
            {
                for (int i = 0; i < res.Length; i++)
                {
                    if (res[i] != null)
                    {
                        if (!res[i].Surname.Equals(surname))
                        {
                            //res[i] = res[n];
                            //res[n] = null;
                            //n--;
                            res[i] = null;
                        }
                    }
                }
            }

            if (idNumberContains != null)
            {
                for (int i = 0; i < res.Length; i++)
                {
                    if (res[i] != null)
                    {
                        if (!res[i].IDNumber.Contains(idNumberContains))
                        {
                            res[i] = null;
                        }
                    }
                }
            }

            return res;
        }


        /// <summary>
        /// Creates a random list of people 
        /// </summary>
        /// <returns></returns>
        static Person[] CreatePeople() {
            string[] firstNames = { "María", "Juan", "Pepe", "Luis", "Carlos", "Miguel", "Cristina" };
            string[] surnames = { "Díaz", "Pérez", "Hevia", "García", "Rodríguez", "Pérez", "Sánchez" };
            int numberOfPeople = 100;

            Person[] printout = new Person[numberOfPeople];
            Random random = new Random();
            for (int i = 0; i < numberOfPeople; i++)
                printout[i] = new Person(
                    firstNames[random.Next(0, firstNames.Length)],
                    surnames[random.Next(0, surnames.Length)],
                    random.Next(9000000, 90000000) + "-" + (char)random.Next('A', 'Z')
                    );
            return printout;
        }

        /// <summary>
        /// Shows a list of people in the console
        /// </summary>
        static void Show(Person[] people) {
            foreach (Person person in people) {
                Console.WriteLine(person);
            }
            Console.WriteLine();
        }

        /// <summary>
        /// Complete the following code
        /// </summary>
        static void Main() {
            Person[] people = CreatePeople();

            Console.WriteLine("People named María:");
            // * Complete the code
            Person[] nameFilter = Filter(people, firstName: "María");
            for(int i = 0; i < nameFilter.Length; i++)
            {
                if (nameFilter[i] != null)
                {
                    Console.WriteLine(nameFilter[i].ToString());
                }
            }

            Console.WriteLine("People whose surname is Pérez:");
            // * Complete the code
            Person[] surnameFilter = Filter(surname: "Pérez", people: people);
            for (int i = 0; i < surnameFilter.Length; i++)
            {
                if (surnameFilter[i] != null)
                {
                    Console.WriteLine(surnameFilter[i].ToString());
                }
            }
            
            //Console.WriteLine(Filter(surname: "Pérez", people: people).ToString());

            Console.WriteLine("People whose ID number contains A");
            // * Complete the code
            Person[] IDFilter = Filter(people, idNumberContains: "A");
            for (int i = 0; i < IDFilter.Length; i++)
            {
                if (IDFilter[i] != null)
                {
                    Console.WriteLine(IDFilter[i].ToString());
                }
            }

            //Console.WriteLine(Filter(people, idNumberContains: "A").ToString());


        }
    }

}
