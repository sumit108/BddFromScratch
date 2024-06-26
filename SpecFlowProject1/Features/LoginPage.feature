Feature: LoginPage

User can Login

@smoke
Scenario: User can login
	Given I open Saucelabs login page
	When I enter username as standard_user and password as secret_sauce
	Then Sauce labs inventory product page opens

@sanity
Scenario Outline: User can login with multiple creds
	Given I open Saucelabs login page
	When I enter username as <Username> and password as <Password>
	Then Sauce labs inventory product page opens
	Examples: 
	| Username      | Password     |
	| standard_user | secret_sauce |
	| problem_user  | secret_sauce |
	| error_user    | secret_sauce |
	| visual_user   | secret_sauce |
