Feature: SpecFlowFeature1
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@mytag
Scenario: Add two numbers
	Given I have entered 50 into the calculator
	And I have entered 70 into the calculator
	When I press add
	Then the result should be 120 on the screen
#@automated
#Feature: UC005_ViewListOfAgencyProperty
#	Sale can see all property of agency
#
#Background: 
#	Given the following property list
#	| PropertyName       | Avarta                         | Images                                                                             | PropertyType_ID | Content                                                                                                                                                                            | Street_ID | Ward_ID | District_ID | Price  | UnitPrice | Area  | BedRoom | BathRoom | PackingPlace | UserID | Create_at  | Create_post | Status_ID | Note | Update_at  |
#	| PIS Top Apartment  | PIS_6656-Edit-stamp.jpg        | a17584387317552326.jpg,AvatarNone17100766117552327.png,images1709523917552328.jpg, | 1               | The surrounding neighborhood is very much localized with a great number of local shops.                                                                                            | 748       | 2       | 2           | 10000  | VND       | 120m2 | 3       | 2        | 1            | 1      | 2017-11-09 | 2017-11-09  | 3         | Done | 2017-11-23 |
#	| Sunshine Ben Thanh | PIS_7319-Edit-stamp1731229.jpg | NULL                                                                               | 1               | It’s nearby Bui Vien Backpacker Area, Duc Ba church, Ben Thanh market, 23/9 park,… Take a look, you will feel the warm in every single square centimeter in the art in the design. | 748       | 2       | 2           | 400000 | Vnd       | 300m2 | 3       | 2        | 2            | 2      | 2017-11-09 | 2017-11-09  | 3		   | Done | 2017-11-30 |
#
#Scenario: View List Of Agency Property
#	When I click button ListOfAgency
#	Then I should see property infomation
#	| PropertyName      | Avarta                  | Images                                                                             | PropertyType | Content                                                                                 | Street | Ward | District | Price | UnitPrice | Area  | BedRoom | BathRoom | PackingPlace | Create_post |
#	| PIS Top Apartment | PIS_6656-Edit-stamp.jpg | a17584387317552326.jpg,AvatarNone17100766117552327.png,images1709523917552328.jpg, | Apartment    | The surrounding neighborhood is very much localized with a great number of local shops. | 748    | 2    | 2        | 10000 | VND       | 120m2 | 3       | 2        | 1            | 2017-11-09  |
#	| 15	Sunshine Ben Thanh | PIS_7319-Edit-stamp1731229.jpg | NULL                                                                               | 1	You can’t imagine you can live in a large apartment  in the central of the central Saigon with just 600$.| It’s nearby Bui Vien Backpacker Area, Duc Ba church, Ben Thanh market, 23/9 park,… Take a look, you will feel the warm in every single square centimeter in the art in the design. | 7795      | 40      | 54          | 400000| Vnd       | 300   | 3       | 2          | 2            | 2      | 2017-11-09 | 2017-11-09  | 3		   | Done | 2017-11-30 |
