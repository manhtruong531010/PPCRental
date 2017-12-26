Feature: Edit
	I can edit detail of property

@mytag
Scenario: edit property
	Given I have to homepage
	When  I click login
	And  When User Enter {username} and {password}
	 | field | value |
  | Username | dinhtrungtin@gmail.com |
  | Password | 123 |
	When when i press ViewProperty
	When when i press Edit
	And i fill up 
	And i select status
	And i click save
	