# PoetryAPI

PoetryAPI is an ASP.NET Core Web Api which utilises the PoetryDB API and was developed to meet the specifications of the MSA Phase 2 Backend. It implements CRUD operations for poems (title, author, and lines) and utilises Swagger to produce a UI. NUnit and NSubstitute are used to mock HttpClient and enable effective testing.

### Middleware via Dependency Injection
PoetryAPI uses dependency injection to implement HttpClient. This makes it much easier to unit test because we are able to mock HttpClient and thereby produce consistent responses. It also makes it possible to change the HttpClient implementation without modifying the classes that rely on HttpClient.

### How middleware libraries made testing easier
PoetryAPI uses NUnit and NSubstitute for testing. These middleware libraries enable testing without requiring an excessive amount of helper code, and they provide more certainty when developing the tests since their functionality is guaranteed. Without them we would have to write all the testing functionality ourselves and in more complicated instances the testing helper code may itself need to be tested.

NUnit enables the use of Assertions which can be used to succinctly enforce requirements, such as the equality of two values, the emptyness of a string, the sameness of two references, etc. 
NSubstitute enables the use of Substitutes which can essentially be used as a mock instance of a type. PoetryAPI usus it to create a substitute for IHttpClientFactory which is much easier than making our own mock class.
