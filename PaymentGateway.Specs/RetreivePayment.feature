Feature: Retrieving a payment
	As a merchant
	If I have the correct ID
	I want to be able to retreive a previous payment if it exists

Scenario: 
	Given I want to retreive a previously made payment
	When I provide a valid payment ID
	Then the payment will be returned