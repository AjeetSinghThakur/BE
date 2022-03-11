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
   
   <img width="929" alt="image" src="https://user-images.githubusercontent.com/9354355/157807859-d6bb6349-9309-4465-b832-7cba5323a764.png">

5. Run application 
    
    <img width="784" alt="image" src="https://user-images.githubusercontent.com/9354355/157807588-021b2964-7b77-4070-9065-1b3aed9da646.png">


