# csStorage
csStorage is a data storage system that allows the user to easily execute CRUD operations on csv file. 
The system maps class entieties to csv files using unique key for each record. 

## Getting started
csStorage is a lightweight package that is ready to use just after adding the nuget to your solution.
First step is to create entity Model that inherits from csEntityBaseModel<T> and set [csKey] attribute.
```
public class PersonEntity : csEntityBaseModel<PersonEntity>
    {
        [csKey]
        public Guid Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime BirthDate { get; set; }

        public Address Address { get; set; }
    }

    public class Address
    {
        public string City { get; set; }

        public string Country { get; set; }
    }
```

## License 

The second step is to initialize a new ContextBuilder<T> class:
```
    var contextBuilder = new csContextBuilder<PersonEntity>();
```

Then You can perform CRUD operations using ContextBuilder<T> methods:
```
    var person = new PersonEntity {
      ///
    }
    var result = contextBuilder.Add(person);
    ///
    var personRecord = contextBuilder.Get(person.Id);
    ///
    var allPersonRecords = contextBuilder.Get().ToList();
    ///
    person.LastName = "Smith";
    var result = contextBuilder.Update(person);
    ///
    contextBuilder.Delete(person);
```


