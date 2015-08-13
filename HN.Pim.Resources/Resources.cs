using System.Globalization;
using Resources.Abstract;
using Resources.Concrete;

namespace HN.Pim.Resources
{
        public class Resources {
            private static IResourceProvider resourceProvider = new DbResourceProvider();

                
        /// <summary>Add person</summary>
        public static string AddPerson {
               get {
                   return (string) resourceProvider.GetResource("AddPerson", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Age</summary>
        public static string Age {
               get {
                   return (string) resourceProvider.GetResource("Age", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Must be between 10 and 130</summary>
        public static string AgeRange {
               get {
                   return (string) resourceProvider.GetResource("AgeRange", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Age is required</summary>
        public static string AgeRequired {
               get {
                   return (string) resourceProvider.GetResource("AgeRequired", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Biography</summary>
        public static string Biography {
               get {
                   return (string) resourceProvider.GetResource("Biography", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Choose your language</summary>
        public static string ChooseYourLanguage {
               get {
                   return (string) resourceProvider.GetResource("ChooseYourLanguage", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Create</summary>
        public static string Create {
               get {
                   return (string) resourceProvider.GetResource("Create", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Email</summary>
        public static string Email {
               get {
                   return (string) resourceProvider.GetResource("Email", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Email is not valid</summary>
        public static string EmailInvalid {
               get {
                   return (string) resourceProvider.GetResource("EmailInvalid", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Email is required</summary>
        public static string EmailRequired {
               get {
                   return (string) resourceProvider.GetResource("EmailRequired", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>First name</summary>
        public static string FirstName {
               get {
                   return (string) resourceProvider.GetResource("FirstName", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Must be less than 50 characters</summary>
        public static string FirstNameLong {
               get {
                   return (string) resourceProvider.GetResource("FirstNameLong", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>First name is required</summary>
        public static string FirstNameRequired {
               get {
                   return (string) resourceProvider.GetResource("FirstNameRequired", CultureInfo.CurrentUICulture.Name);
               }
            }


        /// <summary>First name</summary>
        public static string Name
        {
            get
            {
                return (string)resourceProvider.GetResource("Name", CultureInfo.CurrentUICulture.Name);
            }
        }

        /// <summary>Must be less than 50 characters</summary>
        public static string NameLong
        {
            get
            {
                return (string)resourceProvider.GetResource("NameLong", CultureInfo.CurrentUICulture.Name);
            }
        }

        /// <summary>First name is required</summary>
        public static string NameRequired
        {
            get
            {
                return (string)resourceProvider.GetResource("NameRequired", CultureInfo.CurrentUICulture.Name);
            }
        }
            
        /// <summary>Last name</summary>
        public static string LastName {
               get {
                   return (string) resourceProvider.GetResource("LastName", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Must be less than 50 characters</summary>
        public static string LastNameLong {
               get {
                   return (string) resourceProvider.GetResource("LastNameLong", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Last name is required</summary>
        public static string LastNameRequired {
               get {
                   return (string) resourceProvider.GetResource("LastNameRequired", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Log off</summary>
        public static string LogOff {
               get {
                   return (string) resourceProvider.GetResource("LogOff", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Log on</summary>
        public static string LogOn {
               get {
                   return (string) resourceProvider.GetResource("LogOn", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Register</summary>
        public static string Register {
               get {
                   return (string) resourceProvider.GetResource("Register", CultureInfo.CurrentUICulture.Name);
               }
            }

        }        
}
