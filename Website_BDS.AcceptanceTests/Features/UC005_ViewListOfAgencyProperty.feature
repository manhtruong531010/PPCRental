Feature: UC005_ViewListOfAgencyProperty
	Sale can see all property of agency

@mytag
Scenario: View List Of Agency
	Given Toi dang o tai home page
	When Toi nhan chon nut login
	#Then Toi chuyen sang trang login
	When Toi nhap mat khau va password
	Then Toi nhan chon login va vao trang admin de thay danh sach du an
	When Toi chon View list property cua agency 
	
	