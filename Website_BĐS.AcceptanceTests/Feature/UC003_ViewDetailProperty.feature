@automated
Feature: UC003_ViewDetailProperty
	I can see detail of property

Background: 
	Given the following property
	| PropertyName      | Avatar                  | Images                                                                             | PropertyType_ID | Content                                                                                 | Street_ID | Ward_ID | District_ID | Price | UnitPrice | Area  | BedRoom | BathRoom | PackingPlace | UserID | Created_at | Create_post | Status_ID | Note | Updated_at | Sale_ID |
	| PIS Top Apartment | PIS_6656-Edit-stamp.jpg | a17584387317552326.jpg,AvatarNone17100766117552327.png,images1709523917552328.jpg, | 1               | The surrounding neighborhood is very much localized with a great number of local shops. | 748       | 2       | 2           | 10000 | VND       | 120m2 | 3       | 2        | 1            | 1      | 2017-11-09 | 2017-11-09  | 3         | Done | 2017-11-23 | 2       |


Scenario: View Detail Property
	When I click button Chi tiet 'PIS Top Apartment'
	Then I should see property infomation
	| PropertyName      | Avatar                 | Images                                                                             | PropertyType_ID | Content                                                                                 | Street_ID | Ward_ID | District_ID | Price | UnitPrice | Area  | BedRoom | BathRoom | PackingPlace | Create_post |
	| PIS Top Apartment | PIS_6656-Edit-stamp.jpg | a17584387317552326.jpg,AvatarNone17100766117552327.png,images1709523917552328.jpg, | 1               | The surrounding neighborhood is very much localized with a great number of local shops. | 748       | 2       | 2           | 10000 | VND       | 120m2 | 3       | 2        | 1            | 2017-11-09  |
	