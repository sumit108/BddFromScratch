Feature: Cart

User can add items to cart
Background: 
	Given I open Saucelabs login page
	When I enter username as standard_user and password as secret_sauce
	Then Sauce labs inventory product page opens
	
@smoke
Scenario: Add 1 item to cart
	#Given I open saucelabs webiste
	When I add Sauce Labs Backpack to cart
	Then Item shoud get added

@sanity
Scenario: Add multiple item to cart
	#Given I open saucelabs webiste
	When I add item's to cart
	| Item                    |
	| Sauce Labs Backpack     |
	| Sauce Labs Bolt T-Shirt |
	Then Item shoud get added

	
