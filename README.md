FractionalCalculator
================
Is an MVC & Web API based application that helps you with Fractional Arithmetic.
------------
```
Getting Started: Open up the solution (FractionalCalculator.sln) in Visual Studio 2015. Hit the Run Button after selecting either Debug
or Release mode.

The home page of this MVC app. opens up. On the landing page enter a Fractional Expression with the supported operations (+, -, *, /, ^) giving spaces between the operators & operands. Hit the Calculate button & the response is returned in the Result Text Box.
```

**Urls**
```
Release: http://localhost:55260/

Debug: http://localhost:55260/
```
----------

There is a Web API that is exposed as well besides the MVC UI for Fractional Calculator. The methods supported are as described below.
------

Add two Fractions
==============
This method adds two Fractions. (1/2 + 1/3 = 5/6)

POST api/Fractions/Add
------
**Request**

Http Headers
```
Content-Type: application/json; charset=utf-8
```

Example
```json
{
  "Fraction1": {
    "Numerator": 1,
    "Denominator": 2
  },
  "Fraction2": {
    "Numerator": 1,
    "Denominator": 3
  }
}
```


------
**Response**

Http Headers
```
HTTP/1.1 200 OK
Content-Type: application/json; charset=utf-8
```

Example
```json
{
  "Fraction": {
    "Numerator": 5,
    "Denominator": 6
  }
}
```

Subtract two Fractions
==============
This method subtracts two Fractions. (1/2 - 1/3 = 1/6)

POST api/Fractions/Subtract
------
**Request**

Http Headers
```
Content-Type: application/json; charset=utf-8
```

Example
```json
{
  "Fraction1": {
    "Numerator": 1,
    "Denominator": 2
  },
  "Fraction2": {
    "Numerator": 1,
    "Denominator": 3
  }
}
```


------
**Response**

Http Headers
```
HTTP/1.1 200 OK
Content-Type: application/json; charset=utf-8
```

Example
```json
{
  "Fraction": {
    "Numerator": 1,
    "Denominator": 6
  }
}
```

Multiply two Fractions
==============
This method multiplies two Fractions. (1/2 * 1/3 = 1/6)

POST api/Fractions/Multiply
------
**Request**

Http Headers
```
Content-Type: application/json; charset=utf-8
```

Example
```json
{
  "Fraction1": {
    "Numerator": 1,
    "Denominator": 2
  },
  "Fraction2": {
    "Numerator": 1,
    "Denominator": 3
  }
}
```


------
**Response**

Http Headers
```
HTTP/1.1 200 OK
Content-Type: application/json; charset=utf-8
```

Example
```json
{
  "Fraction": {
    "Numerator": 1,
    "Denominator": 6
  }
}
```

Divide two Fractions
==============
This method divides two Fractions. (1/2 / 1/3 = 3/2)

POST api/Fractions/Divide
------
**Request**

Http Headers
```
Content-Type: application/json; charset=utf-8
```

Example
```json
{
  "Fraction1": {
    "Numerator": 1,
    "Denominator": 2
  },
  "Fraction2": {
    "Numerator": 1,
    "Denominator": 3
  }
}
```


------
**Response**

Http Headers
```
HTTP/1.1 200 OK
Content-Type: application/json; charset=utf-8
```

Example
```json
{
  "Fraction": {
    "Numerator": 3,
    "Denominator": 2
  }
}
```

Power a Fraction
==============
This method powers (exponentiates) a Fraction. (1/2 ^ 3 = 1/8)

POST api/Fractions/Power
------
**Request**

Http Headers
```
Content-Type: application/json; charset=utf-8
```

Example
```json
{
  "Fraction": {
    "Numerator": 1,
    "Denominator": 2
  },
  "Power": 3
}
```


------
**Response**

Http Headers
```
HTTP/1.1 200 OK
Content-Type: application/json; charset=utf-8
```

Example
```json
{
  "Fraction": {
    "Numerator": 1,
    "Denominator": 8
  }
}
```

------
**Expected Http Response Codes**

|Code|Scenario|
|----|--------|
|200|Fractional Operations successfully completed.|
|400|Fractions passed are invalid or malformed. (eg. 5/0)|
|500|Resulting Fraction is invalid or malformed or Something went wrong (eg. 2/3 / 0/5)|

------
