@automated
Feature: UC04_EditAgencyProject
	I want to edit agency project
Background: 
    Given the following project
	| PropertyName                                 | PropertyType | Content                                                                                                      | Street | Ward | District | Price  | Area  | BedRoom | BathRoom | PackingPlace |
	| PIS Top Apartment                            | 1            | The surrounding neighborhood is very much localized with a great number of local shops.                      | 748    | 2    | 2        | 10000  | 120m2 | 3       | 2        | 1            |
	| ViLa Q7                                      | 2            | Brand new apartments with unbelievable river and city view, completely renovated and tastefully furnished.   | 750    | 3    | 2        | 70000  | 120m2 | 3       | 4        | 1            |
	| PIS Serviced Apartment – Style               | 3            | The well equipped kitchen is opened on a cozy living room and a dining area with table and chairs..          | 749    | 4    | 2        | 30000  | 130m2 | 2       | 3        | 1            |
	| Vinhomes Central Park L2 – Duong’s Apartment | 2            | Vinhomes Central Park is a new development that is in the heart of everything that Ho Chi Minh has to offer. | 755    | 33   | 3        | 110000 | 150m2 | 4       | 2        | 1            |
	| Saigon Pearl Ruby Block                      | 1            | Studio apartment at central of CBD, nearby Ben Thanh market, Bui Vien Backpacker Area, 23/9 park…            | 758    | 35   | 3        | 30000  | 130m2 | 3       | 5        | 1            |

@mytag
Scenario: Successfull UC06_EditAgencyProject
	When I input following project
    | PropertyName | PropertyType | Content            | Street | Ward | District | Price   | Area  | BedRoom | BathRoom | PackingPlace |
	| Nhà Quận 7   | 1            | Rộng và thoáng mát | 748    | 2    | 2        | 100000  | 120m2 | 5       | 5        | 2            |
	Then I want see list my project
	| PropertyName                                 | PropertyType | Content                                                                                                      | Street | Ward | District | Price  | Area  | BedRoom | BathRoom | PackingPlace |
	| Nhà Quận 7                                   | 1            | Rộng và thoáng mát                                                                                           | 748    | 2    | 2        | 100000 | 120m2 | 5       | 5        | 2            |
	| ViLa Q7                                      | 2            | Brand new apartments with unbelievable river and city view, completely renovated and tastefully furnished.   | 750    | 3    | 2        | 70000  | 120m2 | 3       | 4        | 1            |
	| PIS Serviced Apartment – Style               | 3            | The well equipped kitchen is opened on a cozy living room and a dining area with table and chairs..          | 749    | 4    | 2        | 30000  | 130m2 | 2       | 3        | 1            |
	| Vinhomes Central Park L2 – Duong’s Apartment | 2            | Vinhomes Central Park is a new development that is in the heart of everything that Ho Chi Minh has to offer. | 755    | 33   | 3        | 110000 | 150m2 | 4       | 2        | 1            |
	| Saigon Pearl Ruby Block                      | 1            | Studio apartment at central of CBD, nearby Ben Thanh market, Bui Vien Backpacker Area, 23/9 park…            | 758    | 35   | 3        | 30000  | 130m2 | 3       | 5        | 1            |