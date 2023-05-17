# csStorage
csStorage is a data storage system that allows the user to easily execute CRUD operations on csv file. 
The system maps class entieties to csv files using unique key for each record. 

## Getting started
csStorage is a lightweight package that is ready to use just after adding the nuget to your solution.

### Entity
The first step to use the package is need to create entity that inherits from csEntityBaseModel<T> and select what class property is a key which will be later used to query the data.
To do that, You need to set ```[csKey]``` or ```[csAutoKey]``` attribute to one of properties. 
    
- ```csKey``` is attribute which can be used with any type of property, and the choosen property need to exists when creating a record.
- ```csAutoKey``` is attribute which can be used only with int or Guid types of property and can be automaticly generated during creating a record.

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

### Builder
To execute CRUD operations using csStorage You need to initialize a new csContextBuilder<T> class instance.
    
```
    var contextCatBuilder = new csContextBuilder<Cat>();
```

When You need to change the path of csv file storage You can just override a ```SetDirectoryPath()``` method.
   
```
    public class CsContextDogBuilder<Dog> : csContextBuilder<Dog>
    {              
        protected override void SetDirectoryPath()
        {
            var appDomainDir = AppDomain.CurrentDomain.BaseDirectory;

            this.DirectoryPath = Path.GetFullPath(Path.Combine(appDomainDir, @"..\..\..\csvFiles\"));
        }
    }
    ///
    var contextDogBuilder = new CsContextDogBuilder<Dog>();
```    

### Data operations
The package allows You to execute basic operations on data sets.

    
#### Create
To create a new record in csv file You just need to create a new instance of entity and use ```Add()``` or ```AddAsync()``` method. 
    
```
    var catEntity = new Cat {
        Name = "Ding",
        Age = 5
    }    
    await contextCatBuilder.AddAsync(catEntity);
    
    ///
    
    var dogEntity = new Dog {
        Name = "Dong",
        Age = 7
    }
    await contextDogBuilder.AddAsync(dogEntity);    
```    


## Contributing
Pull requests are welcome. For major changes, please open an issue first to discuss what you would like to change.

Please make sure to create tests for new features or bug fixes.

## License

[MIT](https://choosealicense.com/licenses/mit/)
