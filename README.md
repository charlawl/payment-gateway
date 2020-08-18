# Payment Gateway

### Build Status
[![charlawl](https://circleci.com/gh/charlawl/payment-gateway.svg?style=shield)](https://app.circleci.com/pipelines/github/charlawl)

### Application Flow
The payment gateway acts as a intermediary between the merchant and financial institution and providing the status of the payment when requested. 

### Getting started


### To Do
- Containerized [x]
- RabbitMQ for event driven architecture [x]
- Build pipeline [x]
- Logging 
  - Serilog would probably be the best choice here for simple logging
- Validation of card details
  - Checking credit card numbers match the type submitted
  - CVV numbers for different providers
  - Expiry date isn't in the past
- Full end-to-end acceptance tests

