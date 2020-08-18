# Payment Gateway

### Build Status
[![charlawl](https://circleci.com/gh/charlawl/payment-gateway.svg?style=shield)](https://app.circleci.com/pipelines/github/charlawl)

### Application Info
The payment gateway acts as a intermediary between the merchant and financial institution and providing the status of the payment when requested. Technology used to build this solution are:
- Application -> .NET Core 3.1
- Mock Bank -> Wiremock (http://wiremock.org/)
- Messaging -> RabbitMQ
- Docker


### Getting started
#### Running the app
To get the application running locally follow these steps:
Build and start the application in docker compose:
```docker-compose up -d --build```

#### Request body
This is the stucture of the request that I have assumed is coming from the Merchant. 
```json
{
    "Amount": 9.99,
    "Currency": "USD",
    "PaymentMethod": {
        "Type": "Amex",
        "Number": "4111111111111111",
        "ExpirationMonth": "10",
        "ExpirationYear": "20",
        "Cvv": "123"
    
    },
    "MerchantId": "1"
 }
 ```
#### Queues
To access RabbitMQ to view the queue the messages are being published to and consumed from go to:

```http://localhost:15672```

#### Testing 
I have included a postman collection which includes tests to show the flow of a payment being accepted and declined.
Accepted:
- All payment types except Amex
- Status will be Submitted -> Accepted 

Declined
- Payment type of Amex (just to show a failure state - in future this would be based on the real response from the bank)
- Status will be Submitted -> Declined 

### To Do
A list of features I am currently working on adding 
- Containerized [x]
- RabbitMQ for event driven architecture [x]
- Build pipeline [x]
- Retry policies for application dependencies
- Logging 
  - Serilog would probably be the best choice here for simple logging
- Validation of card details
  - Checking credit card numbers match the type submitted
  - CVV numbers for different providers
  - Expiry date isn't in the past
- Full end-to-end acceptance tests

