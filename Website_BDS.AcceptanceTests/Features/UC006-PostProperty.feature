Feature: UC006-PostProperty
	I  can post property

@mytag
Scenario: UC006-PostProperty
	Given  have to homepage
	When   click login
	And   User Enter {username} and {password}
	 | field | value |
  | Username | lythihuyenchau@gmail.com |
  | Password | 123 |
		When i press create property
		And i input new information 
		And i click button post