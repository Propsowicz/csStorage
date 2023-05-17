# csStorage
csStorage is a data storage system that allows the user to easily execute CRUD operations on csv file. 
The system maps class entieties to csv files using unique key for each record. 

## Getting started
csStorage is a lightweight package that is ready to use as soon as you add the nuget to your solution.

### Entity
The first step in using the package is to create an entity that inherits from csEntityBaseModel<T> and choose which class property is the key that will be used to query data later.
To do this, set the ```[csKey]``` or ```[csAutoKey]``` attribute to one of the properties.    
    
- ```csKey``` is an attribute that can be used with any type of property, and the selected property must exist when creating the record.
- ```csAutoKey``` is an attribute that can only be used with int or Guid type properties and can be generated automatically when creating a record.
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
To execute CRUD operations using csStorage You must initialize a new csContextBuilder<T> class instance.
    
```
    var contextCatBuilder = new csContextBuilder<Cat>();
```

When You need to change the path of csv file storage You can simply override a ```SetDirectoryPath()``` method.
   
```
    public class CsContextDogBuilder<Dog> : csContextBuilder<Dog>
    {              
        protected override void SetDirectoryPath()
        {
            var appDomainDir = AppDomain.CurrentDomain.BaseDirectory;

            this.DirectoryPath = Path.GetFullPath(Path.Combine(appDomainDir, @"..\..\..\csvFiles\"));
        }
    }    
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
    contextCatBuilder.Add(catEntity);       
    
    var dogEntity = new Dog {
        Name = "Dong",
        Age = 7
    }
    await contextDogBuilder.AddAsync(dogEntity);    
    var dogEntityId = contextDogBuilder.csKey;
```    

#### Get
Quering the data can be done using ```Get()``` or ```GetAsync()``` method.
To query the data you can choose between two overload types: 
- the no parameter one - query the whole data collection,
- the key parameter one - query one record using unique key (type of int, string, Guid or DateTime).
    
```
    var catsOlderThanFour = contextCatBuilder.Get().Where(x => x.Age > 4).ToList();
   
    var myDog = await contextDogBuilder.GetAsync(dogEntityId);     
```
    
#### Update 
To update record You need to query entity what needs to be updated, modify it, and use method ```Update()``` or ```UpdateAsync()``` to save changes. 
    
```
    var myDog = await contextDogBuilder.GetAsync(dogEntityId); 
    myDog.Name = "Dong Dung";
    
    await contextDogBuilder.UpdateAsync(myDog);
```

#### Delete
To Delete You only need to call ```Delete()``` or ```DeleteAsync()``` using csKey as a parameter.
 
```
    contextCatBuilder.Delete(catEntity.Name);     

    await contextDogBuilder.DeleteAsync(dogEntityId);
```
    
## Contributing
Pull requests are welcome. For major changes, please open an issue first to discuss what you would like to change.

Please make sure to create tests for new features or bug fixes.

## License

[MIT](https://choosealicense.com/licenses/mit/)
