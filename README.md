# csStorage
csStorage is a data storage system that allows the user to easily execute CRUD operations on csv file. 
The system maps class entieties to csv files using unique key for each record. 

## Getting started
csStorage is a lightweight package that is ready to use just after adding the nuget to your solution.

### Entity
The first step to use the package is need to create entity that inherits from csEntityBaseModel<T> and select what class property is a key which will be later used to query the data.
To do that, You need to set ```csKey``` or ```csAutoKey``` attribute to one of properties. 
    
- ```csKey``` is attribute which can be used with any type of property, and the choosen property need to exists when creating a record.
- ```csAutoKey``` is attribute which can be used only with int or Guid types of property and can be automaticly generated during creating a record.


First step is to create entity model that inherits from csEntityBaseModel<T> and set [csKey] attribute:
```
    public class Cat : csEntityBaseModel<Cat>
    {
        [csKey]
        public string? Name { get; set; }    

        public int Age { get; set; }
    }

    public class Dog : csEntityBaseModel<Dog>
    {
        [csAutoKey]
        public int Id { get; set; }    
    
        public string? Name { get; set; }    

        public int Age { get; set; }
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
