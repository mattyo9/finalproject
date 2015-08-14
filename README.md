# Final Project

Create a REST compliant `ASP.NET C#` web-service.  The web-service
will have five (5) endpoints.  The first endpoint will be a GET that
displays a page with a form that prompts a user for his username
and password.  The second will be a POST that takes a JSON payload
with the user's username and password and returns either TRUE or
FALSE based on a successful or failed login attempt.  The third
endpoint will be a GET that requests for a list of total login
attempts.  The forth will be a GET that will return a specific
login attempt with it's corresponding metadata.  The final
endpoint will be a DELETE which will delete the specified login
attempts' metadata.

First:
```
curl -X "GET" "http://api.localhost/auth" \
    -H "Authorization: Basic YXBpLXVzZXI6MTIzNHBhc3M=" \
    -H "Accept: application/json"
```   

Second:
```
curl -X "POST" "http://api.localhost/auth/user" \
    -H "Authorization: Basic YXBpLXVzZXI6MTIzNHBhc3M=" \
    -H "Accept: application/json" \
    -d $'{
  "password": "1234pass",
  "username": "fido"
}'
```

Third:
```
curl -X "GET" "http://api.localhost/logins" \
    -H "Authorization: Basic YXBpLXVzZXI6MTIzNHBhc3M=" \
    -H "Accept: application/json"
```

Forth:
```
curl -X "GET" "http://api.localhost/logins/3" \
    -H "Authorization: Basic YXBpLXVzZXI6MTIzNHBhc3M=" \
    -H "Accept: application/json"
```

Fifth:
```
curl -X "DELETE" "http://api.localhost/logins/3" \
    -H "Authorization: Basic YXBpLXVzZXI6MTIzNHBhc3M=" \
    -H "Accept: application/json"
```

The web-service it self will require authentication to use it.  The
REST client or application should use the credentials:

```
username: api-user
password: 1234pass
```

#### Rubric
| Section    | Points |
|------------|--------|
| unit-tests | pts |
| functional | pts |


**Final Project is worth 100 points**
