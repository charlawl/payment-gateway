Feature: Process payment
	As a merchant
	I want to be able to process a payment
	By submitting it to the payment gateway

Scenario: 
	Given I want to process a payment
	When I submit a request to the payment gateway with the appropriate fields
	Then the payment will be validated and a status will be returned