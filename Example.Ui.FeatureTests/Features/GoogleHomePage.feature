Feature: GoogleHomePage

Scenario: Google homepage should include a search box
	Given I have launched a browser and loaded google
	Then the search box should be visible
