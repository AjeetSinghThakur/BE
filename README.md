How to run the project locally.

1.Point BE.WebApi project appsetting.json to following connection string

    "ConnectionStrings": {
        "Default": "server=(localdb)\\MSSQLLocalDB;database=BE;Trusted_Connection=True;MultipleActiveResultSets=true"
    }
2. Execute the DB scripts provided in assignment to create the DB tables inside database BE.
   
   <img width="408" alt="image" src="https://user-images.githubusercontent.com/9354355/157807455-825937a3-442b-4d2b-aef0-ae23c75a0c23.png">

3. Once it is done, please select the BE.WebApi and BE.Web as startup projects.

   <img width="586" alt="image" src="https://user-images.githubusercontent.com/9354355/157807307-9ea5bc03-f46a-4acd-9c6b-f1791779c516.png">

4. Check BE.WebApi is running on background and accessible  by swagger UI.
   
   <img width="666" alt="image" src="https://user-images.githubusercontent.com/9354355/157807748-5802a1d8-aa2e-41ef-936e-20719b225500.png">
   
   <img width="932" alt="image" src="https://user-images.githubusercontent.com/9354355/157808641-349779ab-d588-4ed0-be3c-adcff75eb7b1.png">

5. Run application 
    
    <img width="758" alt="image" src="https://user-images.githubusercontent.com/9354355/157808553-d1dc8f90-893c-4237-8906-5a3845de61de.png">

6. Add new record and save it to DB screen.
   
   <img width="701" alt="image" src="https://user-images.githubusercontent.com/9354355/157808462-d3f53145-5912-4b89-aa7a-bf7bd0011ac5.png">



