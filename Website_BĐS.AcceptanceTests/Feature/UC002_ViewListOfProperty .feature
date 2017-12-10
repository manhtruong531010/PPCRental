Feature: UC002_ViewListOfProperty 
	Agency can see their property in admin page

@mytag
Scenario: View List Property
	Given Toi dang o home page
	When Toi bam nut login
	Then Toi dang o trang login
	When Toi dien mat khau va password
	Then Toi bam nut login va vao trang admin de thay danh sach du an
	
	