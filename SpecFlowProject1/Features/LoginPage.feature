Feature: LoginPage

User can view products and sort products on homepage

@tag1
Scenario: User can login
	Given I open Saucelabs login page
	When I enter username as standard_user and password as secret_sauce
	Then Sauce labs inventory product page opens