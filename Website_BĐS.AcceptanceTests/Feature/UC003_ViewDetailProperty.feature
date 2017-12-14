Feature: UC003_ViewDetailProperty
	I can see detail of property

Background: 
	Given the following property
	| PropertyName      | Avarta                  | Images                                                                             | PropertyType_ID | Content                                                                                 | Street_ID | Ward)ID | District_ID | Price | UnitPrice | Area  | BedRoom | BathRoom | PackingPlace | UserID | Create_at  | Create_post | Status   | Note | Update_at  | Sale_ID |
	| PIS Top Apartment | PIS_6656-Edit-stamp.jpg | a17584387317552326.jpg,AvatarNone17100766117552327.png,images1709523917552328.jpg, | 1               | The surrounding neighborhood is very much localized with a great number of local shops. | 748       | 2       | 2           | 10000 | VND       | 120m2 | 3       | 2        | 1            | 1      | 2017-11-09 | 2017-11-09  | Đã duyệt | Done | 2017-11-23 | 2       |

@automated
@web
Scenario: View Detail Property
	When I click button Chi tiet
	Then I should see property infomation
	| PropertyName                                 | Avarta                                           | Images                                                                             | PropertyType | Content                                                                                                      | Street         | Ward        | District  | Price  | UnitPrice | Area  | BedRoom | BathRoom | PackingPlace |Create_post|
	| PIS Top Apartment                            | PIS_6656-Edit-stamp.jpg                          | a17584387317552326.jpg,AvatarNone17100766117552327.png,images1709523917552328.jpg, | Apartment    | The surrounding neighborhood is very much localized with a great number of local shops.                      | Thôn Chúc Đồng | Đại Yên     | Chương Mỹ | 10000  | VND       | 120m2 | 3       | 2        | 1            |2017-11-09 |
	