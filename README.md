# CreditCardValidator

1. Created two separate projects - UI and API. Please run them seperately in Visual studio (2022). You can test them using Swagger or Frontend UI. If you need to test them using the created 
UI, please run API before testing the UI.

2. Wrote unit tests for service methods.
3. Added dependency injection pattern, (SOLID) Single responsibility principle, Open-closed principle, Interface Segregation principle and dependency inversion principle.
4. SOC, KISS, DRY are used as other design principles.
5. Used a separate middleware for exceptions handling.
6. Used custom validation attributes to validate CVV and Expiry date (Additional).
7. Used an extension to add services to the pipeline (without using the program.cs).
8. UI - Used react, redux to build the UI. 
9. UI - Used the default project structure provided in Visual studio and edited the components.
10. UI - Used fetch method to communicate with API.

11. When you run the project, we need to add the correct API Url to the Home.tsx component. Since it is running on localhost, you may face with URL accessing issue unless you add the 
correct Api URL.

Ex : await fetch("http://localhost:5093/CreditCardValidator"

12. I have added some screenshots of the running product. Please check.