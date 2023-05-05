# csStorage
csStorage is a data storage system that allows the user to easily execute CRUD operations on csv file. 
The system maps class entieties to csv files using unique key for each record. 

## Getting started
csStorage is a lightweight package that is ready to use just after adding the nuget to your solution.

First step is to create entity model that inherits from csEntityBaseModel<T> and set [csKey] attribute:
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

The second step is to initialize a new csContextBuilder<T> class instance:
```
    var contextBuilder = new csContextBuilder<PersonEntity>();
```

Then You can perform CRUD operations using csContextBuilder<T> methods:
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

## Contributing
Pull requests are welcome. For major changes, please open an issue first to discuss what you would like to change.

Please make sure to create tests for new features or bug fixes.

## License

[MIT](https://choosealicense.com/licenses/mit/)
