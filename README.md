# Hafner.Tools.Settable
Repository Hafner.Tools.Settable (formerly Hafner.Tools.SetTracker) provides a tiny helper type of the same name that can be used to differentiate between whether a parameter/property was set to null or was not set at all. Useful for 

* Filters: 

        public class AddressFilter {

            public Settable<String> FirstName { get; set; }
            public Settable<String?> MiddleName { get; set; }
            public Settable<String> Surname { get; set; }

        } 
    
  - not set: Do not apply any filter for that property
  - null set: Return all records that have null in the particular column
  
* UpdateRecord methods:

        public void UpdatePersonData(int personId, Settable<string> firstName = default, Settable<string?> middleName = default, Settable<string> surename = default) {
            //Add firstName, middleName and surename to query if set and execute it
        }
        
  - not set: Don't change the value
  - null set: Change the value to null
  
* Data Transfer Objects (DTOs):

        public class Person {

            public int PersonId { get; set; }
            public Settable<string> FirstName { get; set; }
            public Settable<string?> MiddleName { get; set; }
            public Settable<string> Surname { get; set; }
            public Settable<string?> ChangeHistory { get; set; }
        }

  - not set: Value was not loaded (e.g. the ChangeHistory might be omitted for performance reasons)
  - null set: The value is null in the database

etc.
