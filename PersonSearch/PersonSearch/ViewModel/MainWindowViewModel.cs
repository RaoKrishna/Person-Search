using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using PersonSearch.Command;
using PersonSearch.Model;

namespace PersonSearch.ViewModel
{
    /// <summary>
    /// The ViewModel class that manipulates the commands in the View and interacts with the model 
    /// </summary>
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private string personID;
        private string firstName;
        private string lastName;
        private string address;
        private string age;
        private string interests;
        private string searchName;
        private string addStatus;
        private string pathName;
        private string exceptionMsg;
        private string fetchMsg;
        private string seedDataMsg;
        private System.Windows.Visibility visStatus;
        private System.Windows.Visibility gridVisibility;
        private System.Windows.Visibility visFetchStatus;

        /// <summary>
        /// Instantiates all the Command classes
        /// </summary>
        public MainWindowViewModel()
        {
            SearchPersonCommand = new SearchCommand(this);
            AddPersonCommand = new AddCommand(this);
            PersonIDCommand = new IDCommand(this);
            BrowseImageCommand = new BrowseImageCommand(this);
            SeedPersonDataCommand = new SeedDataCommand(this);
            VisibilityStatus = Visibility.Visible;
            VisibilityFetchStatus = Visibility.Collapsed;
            GridVisibility = Visibility.Collapsed;
            GridPerson = new ObservableCollection<Person>();

            #region Alternate Method For Commands
            // This alternate method can be used to eliminate different classes for the commands and we can declare all commands
            // in the viewModel itself. This requires use of Prism Package which contains the method DelegateCommand
            // Using DelegateCommand, we can specify the methods for CanExecute and Execute in its constructor itself as shown below:
            //
            // SearchPersonCommand = new DelegateCommand<object>(this.FetchPersonDetails, this.CanSearch);
            //
            // Both the methods should take object as a parameter. 
            // This approach is useful while creating a full fledged application
            #endregion
        }

        #region PROPERTIES

        /// <summary>
        /// Command Property for Searching the person
        /// </summary>
        public ICommand SearchPersonCommand
        {
            get;
            private set;
        }

        /// <summary>
        /// Command Property for seeding the data
        /// </summary>
        public ICommand SeedPersonDataCommand
        {
            get;
            private set;
        }

        /// <summary>
        /// Command Property for adding the person
        /// </summary>
        public ICommand AddPersonCommand
        {
            get;
            private set;
        }

        /// <summary>
        /// Command Property for fetching the person Id
        /// </summary>
        public ICommand PersonIDCommand
        {
            get;
            private set;
        }

        /// <summary>
        /// Command Property for browsing the image
        /// </summary>
        public ICommand BrowseImageCommand
        {
            get;
            private set;
        }

        /// <summary>
        /// Command Property for the Person ID field
        /// </summary>
        public string PersID
        {
            get 
            {
                return personID;
            }
            set 
            {
                personID = value;
                OnPropertyChanged("PersID");
            }
        }

        /// <summary>
        /// Command Property for the Address field
        /// </summary>
        public string PAddress
        {
            get
            {
                return address;
            }
            set
            {
                address = value;
                OnPropertyChanged("PAddress");
            }
        }

        /// <summary>
        /// Command Property for the First Name field
        /// </summary>
        public string FName
        {
            get
            {
                return firstName;
            }
            set
            {
                firstName = value;
                OnPropertyChanged("FName");
            }
        }

        /// <summary>
        /// Command Property for the Last Name field
        /// </summary>
        public string LName
        {
            get
            {
                return lastName;
            }
            set
            {
                lastName = value;
                OnPropertyChanged("LName");
            }
        }

        /// <summary>
        /// Command Property for manipulating the visibility of the AddStatus Message
        /// </summary>
        public System.Windows.Visibility VisibilityStatus
        {
            get
            {
                return visStatus;
            }
            set
            {
                visStatus = value;
                OnPropertyChanged("VisibilityStatus");
            }
        }

        /// <summary>
        /// Command Property for manipulating the visibility of the FetchStatus Message
        /// </summary>
        public System.Windows.Visibility VisibilityFetchStatus
        {
            get
            {
                return visFetchStatus;
            }
            set
            {
                visFetchStatus = value;
                OnPropertyChanged("VisibilityFetchStatus");
            }
        }

        /// <summary>
        /// Command Property for manipulating the visibility of the FetchStatus Message
        /// </summary>
        public System.Windows.Visibility GridVisibility
        {
            get
            {
                return gridVisibility;
            }
            set
            {
                gridVisibility = value;
                OnPropertyChanged("GridVisibility");
            }
        }

        /// <summary>
        /// Command Property for the Age field
        /// </summary>
        public string PAge
        {
            get
            {
                int s;
                if (age == null || age == "")
                {
                    VisibilityStatus = Visibility.Visible;
                    return age;
                }
                if (int.TryParse(age, out s))
                {
                    VisibilityStatus = Visibility.Visible;
                    AddStatus = "All the fields are compulsory.";
                    return age;
                }
                else
                {
                    VisibilityStatus = Visibility.Visible;
                    AddStatus = "Please enter numeric value for Age.";
                    return "";
                }
            }
            set
            {
                age = value;
                OnPropertyChanged("PAge");
            }
        }

        /// <summary>
        /// Command Property for the Interests field
        /// </summary>
        public string PInterests
        {
            get
            {
                return interests;
            }
            set
            {
                interests = value;
                OnPropertyChanged("PInterests");
            }
        }

        /// <summary>
        /// Command Property for the source of the grid displaying the Person details
        /// </summary>
        public ObservableCollection<Person> GridPerson 
        {
            get; 
            private set; 
        }

        /// <summary>
        /// Command Property for the Search field for searching the name of the person
        /// </summary>
        public string SrchName
        {
            get
            {
                return searchName;
            }
            set
            {
                searchName = value;
                OnPropertyChanged("SrchName");
            }
        }

        /// <summary>
        /// Status of Adding the person. Also displays the validation errors in the Add Screen
        /// </summary>
        public string AddStatus
        {
            get
            {
                return addStatus;
            }
            set
            {
                addStatus = value;
                OnPropertyChanged("AddStatus");
            }
        }

        /// <summary>
        /// Command Property for the Path Name for the image field
        /// </summary>
        public string PathName
        {
            get
            {
                return pathName;
            }
            set
            {
                pathName = value;
                OnPropertyChanged("PathName");
            }
        }

        /// <summary>
        /// Command Property for the Exception Message
        /// </summary>
        public string ExceptionMessage
        {
            get
            {
                return exceptionMsg;
            }
            set
            {
                exceptionMsg = value;
                OnPropertyChanged("ExceptionMessage");
            }
        }

        /// <summary>
        /// Command Property for the status of the Fetch Message
        /// </summary>
        public string FetchMessage
        {
            get
            {
                return fetchMsg;
            }
            set
            {
                fetchMsg = value;
                OnPropertyChanged("FetchMessage");
            }
        }

        /// <summary>
        /// Command Property for the status of the Fetch Message
        /// </summary>
        public string SeedDataStatus
        {
            get
            {
                return seedDataMsg;
            }
            set
            {
                seedDataMsg = value;
                OnPropertyChanged("SeedDataStatus");
            }
        }
        
        /// <summary>
        /// Property that enables or disables the Search button
        /// </summary>
        public bool CanSearch
        {
            get
            {
                return !String.IsNullOrWhiteSpace(SrchName);
            }
        }

        /// <summary>
        /// Property that enables or disables the Add button
        /// </summary>
        public bool CanAdd
        {
            get
            {
                bool retValue = true;
                if (String.IsNullOrWhiteSpace(FName))
                    retValue = false;
                if (String.IsNullOrWhiteSpace(LName))
                    retValue = false;
                if (String.IsNullOrWhiteSpace(PAddress))
                    retValue = false;
                if (String.IsNullOrWhiteSpace(PAge))
                    retValue = false;
                if (String.IsNullOrWhiteSpace(PInterests))
                    retValue = false;
                if (String.IsNullOrWhiteSpace(PathName))
                    retValue = false;

                return retValue;
            }
        }

        #endregion

        #region METHODS

        /// <summary>
        /// Calls the  method in the model to fetch the list of people
        /// </summary>
        public void FetchPersonDetails()
        {
            try
            {
                List<Person> lisPerson = Person.FetchPersonDetails(SrchName);
                GridPerson.Clear();

                if (lisPerson.Count == 0)
                {
                    FetchMessage = "No such records exist! Please verify the name";
                    VisibilityFetchStatus = Visibility.Visible;
                    GridVisibility = Visibility.Collapsed;
                }
                else
                {
                    GridVisibility = Visibility.Visible;
                    VisibilityFetchStatus = Visibility.Collapsed;
                    FetchMessage = "";

                    // Binds the data in the list to the DataGrid
                    foreach (Person p in lisPerson)
                    {
                        MemoryStream mStream = new MemoryStream(p.PImage);
                        BitmapImage bImage = new BitmapImage();
                        bImage.BeginInit();
                        bImage.StreamSource = mStream;
                        bImage.EndInit();
                        p.ImagePath = bImage;
                        GridPerson.Add(p);
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionMessage = "Could not search the person! Please try again!! Technical Message : " + ex;
            }
        }

        /// <summary>
        /// Calls the  method in the model to add the input Person into the database
        /// </summary>
        public void AddPerson()
        {
            try
            {
                // Image is converted into array of bytes before inserting into SQL Database
                FileStream fStream = new FileStream(PathName, FileMode.Open, FileAccess.Read);
                StreamReader sReader = new StreamReader(fStream);
                Byte[] image = new Byte[fStream.Length - 1];
                fStream.Read(image, 0, (int)fStream.Length - 1);
                
                // Person object to be added
                Person person = new Person
                {
                    FirstName = FName,
                    LastName = LName,
                    Address = PAddress,
                    Age = Int32.Parse(PAge),
                    Interests = PInterests,
                    PImage = image
                };

                Person.AddPerson(person);

                // Clears the screen after adding the person
                AddStatus = "Person Added successfully!! Please click Add Person menu button to add another person";
                PersID = "";
                FName = "";
                LName = "";
                PAddress = "";
                PAge = "";
                PInterests = "";
                PathName = "";
            }
            catch (Exception ex)
            {
                AddStatus = "Some exception occured! Please try again!!";
                ExceptionMessage = "Could not add the person! Please try again!! Technical Message : " + ex;
            }
        }

        /// <summary>
        /// Calls the  method in the model to fetch the next ID of the person
        /// </summary>
        public void FetchNextID()
        {
            try
            {
                GridVisibility = Visibility.Collapsed;
                VisibilityFetchStatus = Visibility.Collapsed;
                int nextID = Person.FetchNextID();
                PersID = nextID.ToString();
                AddStatus = "All the fields are compulsory.";
            }
            catch (Exception ex)
            {
                ExceptionMessage = "Could not fetch the Person ID! Please try again!! Technical Message : " + ex;
            }
        }

        /// <summary>
        /// Opens the Folder browser to select the image to be added
        /// </summary>
        public void BrowsePics()
        {
            try
            {
                // Shows only Images of .jpg, .jpeg, .png, .gif format
                Microsoft.Win32.OpenFileDialog file = new Microsoft.Win32.OpenFileDialog() { Filter = "JPEG Files (*.jpeg)|*.jpeg|PNG Files (*.png)|*.png|JPG Files (*.jpg)|*.jpg|GIF Files (*.gif)|*.gif" };
                bool? selected = file.ShowDialog();

                // Sets the Path for the image
                if (selected == true)
                {
                    string path = file.FileName;
                    PathName = path;
                }
            }
            catch (Exception ex)
            {
                ExceptionMessage = "Could not browse the pics! Please try again!! Technical Message : " + ex;
            }
        }

        /// <summary>
        /// Adds details of ten people into the database
        /// </summary>
        public void SeedData()
        {
            try
            {
                List<Person> lisPerson = new List<Person>
                {
                    new Person 
                    { FirstName = "Beast", LastName = "McCoy", Address = "Illinois", Age = 52, Interests = "Adventurer"
                        , PImage = ConvertImage(Directory.GetCurrentDirectory() + "\\Images\\Beast.jpg")},
                    new Person 
                    { FirstName = "Black", LastName = "Widow", Address = "Stalingrad", Age = 51, Interests = "Licensed super hero"
                        , PImage = ConvertImage(Directory.GetCurrentDirectory() + "\\Images\\BlackWidow.jpg")},
                    new Person 
                    { FirstName = "Captain", LastName = "America", Address = "New York", Age = 75, Interests = "Police Officer"
                        , PImage = ConvertImage(Directory.GetCurrentDirectory() + "\\Images\\CaptainAmerica.jpg")},
                    new Person 
                    { FirstName = "Wolverine", LastName = "Howlett", Address = "Canada", Age = 41, Interests = "Spy"
                        , PImage = ConvertImage(Directory.GetCurrentDirectory() + "\\Images\\Wolverine.jpg")},
                    new Person 
                    { FirstName = "Incredible", LastName = "Hulk", Address = "Ohio", Age = 53, Interests = "Former Nuclear Physicist"
                        , PImage = ConvertImage(Directory.GetCurrentDirectory() + "\\Images\\Hulk.jpg")},
                    new Person 
                    { FirstName = "Human", LastName = "Torch", Address = "New York", Age = 54, Interests = "Fire Fighter"
                        , PImage = ConvertImage(Directory.GetCurrentDirectory() + "\\Images\\HumanTorch.jpg")},
                    new Person 
                    { FirstName = "Invisible", LastName = "Woman", Address = "Illinois", Age = 54, Interests = "Former Actor"
                        , PImage = ConvertImage(Directory.GetCurrentDirectory() + "\\Images\\InvisibleWoman.jpg")},
                    new Person 
                    { FirstName = "Iron", LastName = "Man", Address = "New York", Age = 53, Interests = "CEO of Stark Industries"
                        , PImage = ConvertImage(Directory.GetCurrentDirectory() + "\\Images\\IronMan.jpg")},
                    new Person 
                    { FirstName = "Spider", LastName = "Man", Address = "New York", Age = 53, Interests = "Former Photographer"
                        , PImage = ConvertImage(Directory.GetCurrentDirectory() + "\\Images\\SpiderMan.jpg")},
                    new Person 
                    { FirstName = "Mighty", LastName = "Thor", Address = "Norway", Age = 64, Interests = "Warrior"
                        , PImage = ConvertImage(Directory.GetCurrentDirectory() + "\\Images\\Thor.jpg")}
                };

                Person.SeedData(lisPerson);
                SeedDataStatus = "Ten people were added in the database. Their first names are Beast, Black,\nCaptain,"
                               + "Wolverine, Incredible, Human, Invisible, Iron, Spider and Mighty.";

                GridVisibility = Visibility.Collapsed;
                VisibilityFetchStatus = Visibility.Collapsed;
                                    
            }
            catch (Exception ex)
            {
                ExceptionMessage = "Could not seed the data! Please try again!! Technical Message : " + ex;
            }
        }

        /// <summary>
        /// Converts the image into an array of bytes
        /// </summary>
        /// <param name="PathName">Path of the image</param>
        /// <returns>Array of Bytes representing the image</returns>
        public Byte[] ConvertImage(string PathName)
        {
            try
            {
                FileStream fStream = new FileStream(PathName, FileMode.Open, FileAccess.Read);
                StreamReader sReader = new StreamReader(fStream);
                Byte[] image = new Byte[fStream.Length - 1];
                fStream.Read(image, 0, (int)fStream.Length - 1);
                return image;
            }
            catch (Exception ex)
            {
                ExceptionMessage = "Could not convert the image! Please try again!! Technical Message : " + ex;
                return null;
            }
        }

        #endregion

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;

            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion
    }
}
