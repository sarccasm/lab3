- GET `/products`, `/products/`, `/products/index`, `/items`, `/items/index` : list
- GET `/products/{id}` : details
- GET `/products/create` or `/products/new` : create form
- POST `/products/create` or `/products/new` : create
- GET/POST `/products/edit/{id}` : edit
- GET/POST `/products/delete/{id}` : delete (GET confirms, POST deletes)
- GET `/products?search=lap&category=Electronics&minPrice=10&maxPrice=1500` : filter
- Missing product: HTTP 404 with custom page and back link
- POST `/users/index` : admin user list only with form-body field `parameter=df2323eoT`; otherwise HTTP 401. GET is always HTTP 401.


<img width="2048" height="1280" alt="image" src="https://github.com/user-attachments/assets/3dcfd93b-6e56-441c-878f-87ffd58f8901" />

<img width="2048" height="1280" alt="image" src="https://github.com/user-attachments/assets/a130c32c-ca7c-4168-99b2-50141e831687" />
