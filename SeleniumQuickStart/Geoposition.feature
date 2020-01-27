Feature: Geoposition

Scenario: Autodetect geoposition
	Given I am on lamoda website
	When I select region block
	And click on autodetect button
	Then it was detected place 'г. Москва'

Scenario: Save autodetected place
	Given I am on lamoda website
	When I select region block
	And save autodetected place
	Then region selector was closed