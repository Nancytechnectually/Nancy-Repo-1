Feature: TMFeature

As an admin, we want to login into Turnup portal and create the Time and 
Material record with valid data and then edit and delete my Created Record.


Scenario: Checking if we can create a new record successfully
	Given I can login successfully into turnup portal
	And I navigated to the time and material page 
	When  I have created new record 
	Then I can see the new entered record on last page


	
Scenario Outline: Checking if we can Edit description of record successfully 
	Given I can login successfully into turnup portal
	And I navigated to the time and material page 
	When I Update '<Description>' , '<Code>' and '<Price>' of existing record with valid data
	Then I checked the updated '<Description>' , '<Code>' and '<Price>'is present on Time and material page

	Examples: 
	| Description   | Code     | Price |
	| My First Test | My Code  | 21    |
	| 2nd Test      | 2nd Code | 33    |
	| ThirdTest     | Code red | 333   |





