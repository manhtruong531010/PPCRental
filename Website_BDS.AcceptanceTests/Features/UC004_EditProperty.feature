@automated
Feature: Edit
	I can edit detail of property

Background: 
	Given the following for user
	| Email                    | Password | FullName    | Phone       | Address       | Role | Status |
	| lythihuyenchau@gmail.com | 123456   | Lý Châu     | 0999580654  | Trần Hưng Đạo | 1    | True   |
	| Manhtruong@gmail.com     | 123456   | Mạnh Trương | 01687631718 | Cô Giang      | 0    | True   |
	And the following project
	| PropertyName                                 | Avarta                                           | Images                                                                            | PropertyType | Content                                                                                                      | Street          | Ward        | District | Price  | UnitPrice | Area  | BedRoom | BathRoom | PackingPlace | UserID       | Create_at  | Create_post | Status   | Note | Update_at  | Sale_ID        |
	| PIS Top Apartment                            | PIS_6656-Edit-stamp.jpg                          | a17584387317552326.jpg,AvatarNone17100766117552327.png,images1709523917552328.jpg | Apartment    | The surrounding neighborhood is very much localized with a great number of local shops.                      | Cô Bắc          | P.Cô Giang  | Q.1      | 10000  | VND       | 120m2 | 3       | 2        | 1            | Lý Châu      | 2017-11-09 | 2017-11-09  | Lưu nháp | Done | 2017-11-23 | Chi Võ         |
	| ViLa Q7                                      | images172300301.jpg                              | images172300301.jpg                                                               | Villa        | Brand new apartments with unbelievable river and city view, completely renovated and tastefully furnished.   | Nguyễn Thị Thập | P.Phú Mỹ    | Q.7      | 70000  | VND       | 120m2 | 3       | 4        | 1            | Lý Châu      | 2017-11-09 | 2017-11-09  | Đã duyệt | Done | 2017-11-23 | Chi Võ         |
	| PIS Serviced Apartment – Style               | sunshine-benthanh-cityhome-10-stamp174228283.jpg | a - Copy17095239.jpg,images (1) - Copy17095242.jpg,images17095242.jpg             | Office       | The well equipped kitchen is opened on a cozy living room and a dining area with table and chairs..          | Bền Văn Đồn     | P.03        | Q.4      | 30000  | VND       | 130m2 | 2       | 3        | 1            | Sơn Lê       | 2017-11-09 | 2017-11-09  | Đã duyệt | Done | 2017-11-23 | Khá Trần       |
	| Vinhomes Central Park L2 – Duong’s Apartment | PIS_7389-Edit-stamp.jpg                          | images1702244617042862.jpg                                                        | Villa        | Vinhomes Central Park is a new development that is in the heart of everything that Ho Chi Minh has to offer. | Bà Hạt          | P.02        | Q.10     | 110000 | VND       | 150m2 | 4       | 2        | 1            | Lý Châu      | 2017-11-09 | 2017-11-09  | Đã duyệt | Done | 2017-11-23 | Khá Trần       |
	| Saigon Pearl Ruby Block                      | PIS_7319-Edit-stamp.jpg                          | images17423697317334243.jpg,PIS_4622-Edit17463610217334244.jpg                    | Apartment    | Studio apartment at central of CBD, nearby Ben Thanh market, Bui Vien Backpacker Area, 23/9 park…            | Chu Văn An      | P.Long Bình | Q.9      | 30000  | VND       | 130m2 | 3       | 5        | 1            | Sơn Lê       | 2017-11-09 | 2017-11-09  | Đã duyệt | Done | 2017-11-23 | Chi Võ         | 
	And the following property_feature
	| Property                                     | Feature           |
	| PIS Top Apartment                            | Vườn              |
	| PIS Top Apartment                            | Hồ bơi            |
	| ViLa Q7                                      | Chỗ đậu xe        |
	| ViLa Q7                                      | Phòng tập Gym     |
	| ViLa Q7                                      | Hồ bơi            |
	| PIS Serviced Apartment – Style               | Thang máy         |
	| Vinhomes Central Park L2 – Duong’s Apartment | Sàn gỗ            |
	| Vinhomes Central Park L2 – Duong’s Apartment | Cho nuôi thú cưng |
	| Saigon Pearl Ruby Block                      | Vườn              |


Scenario: Edit Agency Project
	Given I enterd 'Manhtruong@gmail.com' and '123456' into Login page
	And I have navigate to View List of Agency Project
	And I clicked edit of 'Saigon Pearl Ruby Block'
	And I edit my properties like the following
	| PropertyName                                 | Avarta                                           | Images                                                                             | PropertyType | Content                                                                                                      | Street          | Ward        | District | Price  | UnitPrice | Area  | BedRoom | BathRoom | PackingPlace | UserID       | Create_at  | Create_post | Status   | Note | Update_at  | Sale_ID        |
    | Saigon Pearl Ruby Block 2                    | PIS_7319-Edit-stamp.jpg                          | images17423697317334243.jpg,PIS_4622-Edit17463610217334244.jpg                     | Apartment    | Studio apartment at central of CBD, nearby Ben Thanh market, Bui Vien Backpacker Area, 23/9 park…            | Chu Văn An      | P.Long Bình | Q.9      | 30000  | VND       | 130m2 | 3       | 5        | 1            | Sơn Lê       | 2017-11-09 | 2017-11-09  | Lưu nháp | Done | 2017-11-23 | Chi Võ         | 
	And I have navigate to View List of Agency Project
	Then I should see my project
	| PropertyName                                 | Avarta                                           | Images                                                                             | PropertyType | Content                                                                                                      | Street          | Ward        | District | Price  | UnitPrice | Area  | BedRoom | BathRoom | PackingPlace | UserID       | Create_at  | Create_post | Status   | Note | Update_at  | Sale_ID        |
    | PIS Top Apartment                            | PIS_6656-Edit-stamp.jpg                          | a17584387317552326.jpg,AvatarNone17100766117552327.png,images1709523917552328.jpg  | Apartment    | The surrounding neighborhood is very much localized with a great number of local shops.                      | Cô Bắc          | P.Cô Giang  | Q.1      | 100000  | VND      | 120m2 | 100     | 100      | 100          | Lý Châu      | 2017-11-09 | 2017-11-09  | Lưu nháp | Done | 2017-11-23 | Chi Võ         |
	| ViLa Q7                                      | images172300301.jpg                              | images172300301.jpg                                                                | Villa        | Brand new apartments with unbelievable river and city view, completely renovated and tastefully furnished.   | Nguyễn Thị Thập | P.Phú Mỹ    | Q.7      | 70000  | VND       | 120m2 | 3       | 4        | 1            | Lý Châu      | 2017-11-09 | 2017-11-09  | Đã duyệt | Done | 2017-11-23 | Chi Võ         |
	| PIS Serviced Apartment – Style               | sunshine-benthanh-cityhome-10-stamp174228283.jpg | a - Copy17095239.jpg,images (1) - Copy17095242.jpg,images17095242.jpg              | Office       | The well equipped kitchen is opened on a cozy living room and a dining area with table and chairs..          | Bền Văn Đồn     | P.03        | Q.4      | 30000  | VND       | 130m2 | 2       | 3        | 1            | Sơn Lê       | 2017-11-09 | 2017-11-09  | Đã duyệt | Done | 2017-11-23 | Khá Trần       |
	| Vinhomes Central Park L2 – Duong’s Apartment | PIS_7389-Edit-stamp.jpg                          | images1702244617042862.jpg                                                         | Villa        | Vinhomes Central Park is a new development that is in the heart of everything that Ho Chi Minh has to offer. | Bà Hạt          | P.02        | Q.10     | 110000 | VND       | 150m2 | 4       | 2        | 1            | Lý Châu      | 2017-11-09 | 2017-11-09  | Đã duyệt | Done | 2017-11-23 | Khá Trần       |
	| Saigon Pearl Ruby Block 2                    | 2.jpg                                            | 1.jpg,2.jpg,3.jpg                                                                  | Apartment    | Studio apartment at central of CBD, nearby Ben Thanh market, Bui Vien Backpacker Area, 23/9 park…            | Chu Văn An      | P.Long Bình | Q.9      | 30000  | VND       | 130m2 | 3       | 5        | 1            | Sơn Lê       | 2017-11-09 | 2017-11-09  | Lưu nháp | Done | 2017-11-23 | Chi Võ         | 


	