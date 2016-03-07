using System;
using System.Linq;
using System.Collections.Generic;
using System.Windows.Media.Imaging;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using PersonSearch.ViewModel;

namespace PersonSearch.Model
{
    /// <summary>
    /// Class to access person details and methods to communicate with database
    /// </summary>
    public class Person
    {
        private int personID;

        [Required]
        [StringLength(10)]
        private string firstName;
        private string lastName;
        private string address;
        private int age;
        private string interests;
        private byte[] pImage;
        private BitmapImage imagePath;

        #region PROPERTIES

        /// <summary>
        /// Person Id - This is the primary key of the generated table
        /// </summary>
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity), Key()]
        public int PersonID
        {
            get
            {
                return personID;
            }
            set
            {
                personID = value;
            }
        }

        /// <summary>
        /// First Name of the Person
        /// </summary>
        public string FirstName 
        {
            get
            {
                return firstName;
            }
            set
            {
                firstName = value;
            }
        }

        /// <summary>
        /// Last Name of the Person
        /// </summary>
        public string LastName
        {
            get
            {
                return lastName;
            }
            set
            {
                lastName = value;
            }
        }

        /// <summary>
        /// Address of the Person
        /// </summary>
        public string Address 
        {
            get
            {
                return address;
            }
            set
            {
                address = value;
            }
        }

        /// <summary>
        /// Age of the Person
        /// </summary>
        public int Age 
        {
            get
            {
                return age;
            }
            set
            {
                age = value;
            }
        }

        /// <summary>
        /// Interests of the Person
        /// </summary>
        public string Interests 
        {
            get
            {
                return interests;
            }
            set
            {
                interests = value;
            }
        }

        /// <summary>
        /// Image of the Person. It is stored as array of bytes in the database
        /// </summary>
        public byte[] PImage
        {
            get
            {
                return pImage;
            }
            set
            {
                pImage = value;
            }
        }

        /// <summary>
        /// This field is for mapping the source path of the image on the screen
        /// </summary>
        [NotMapped]
        public BitmapImage ImagePath
        {
            get
            {
                return imagePath;
            }
            set
            {
                imagePath = value;
            }
        }

        #endregion

        #region METHODS

        /// <summary>
        /// Fetches List of people whose first or last name matches the given name
        /// </summary>
        /// <param name="subname">Input name to be searched</param>
        /// <returns>List of people</returns>
        public static List<Person> FetchPersonDetails(string subname)
        {
            List<Person> lisPerson = new List<Person>();
            try
            {
                // Create context of Entity to fetch details
                using (var context = new PersonContextContainer())
                {
                    var results = (from res in context.Persons
                                   where res.FirstName.Equals(subname) || res.LastName.Equals(subname)
                                   select res);
                    foreach (Person person in results)
                    {
                        lisPerson.Add(person);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return lisPerson;
        }

        /// <summary>
        /// Adds the given person into the database
        /// </summary>
        /// <param name="person">Person to be added</param>
        public static void AddPerson(Person person)
        {
            try
            {
                // Create context of Entity to add the person
                using (var contxt = new PersonContextContainer())
                {
                    contxt.Persons.Add(person);
                    contxt.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        /// <summary>
        /// Fetches the Person ID of the person to be added
        /// </summary>
        /// <returns>Next Person ID</returns>
        public static int FetchNextID()
        {
            int nextID;
            try
            {
                // Create context of Entity to fetch the Id
                using (var context = new PersonContextContainer())
                {
                    var lis = (from res in context.Persons
                               select res.PersonID);
                    if (lis.Count() > 0)
                        nextID = lis.Max();
                    else
                        nextID = 0;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return ++nextID;
        }

        /// <summary>
        /// Adds the list of persons into the database
        /// </summary>
        /// <param name="lisPerson"></param>
        public static void SeedData(List<Person> lisPerson)
        {
            try
            {
                // Create context of Entity to add the person
                using (var contxt = new PersonContextContainer())
                {
                    foreach (Person person in lisPerson)
                    {
                        contxt.Persons.Add(person);
                    }
                    contxt.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

    }
}
