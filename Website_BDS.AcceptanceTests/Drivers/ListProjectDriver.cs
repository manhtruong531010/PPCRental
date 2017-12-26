using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Website_BĐS.Models;
using FluentAssertions;
using Website_BDS.AcceptanceTests.Support;
using Website_BDS.AcceptanceTests.Common;
using TechTalk.SpecFlow;
using Website_BĐS.Controllers;
using System.Web.Mvc;
using Moq;
using System.IO;
using System.Web;
using TechTalk.SpecFlow.Assist;
using Website_BDS.UITests.Selenium.Config;
using Website_BĐS.Areas.Agency.Controllers;
using System.Web.Routing;

namespace PPCProject.AcceptanceTests.Drivers
{
    public class ListProjectDriver
    {

        private ActionResult _result;
        private HomeController _controller;
        private readonly CatalogContext _context;

        public ListProjectDriver(CatalogContext context)
        {
            _context = context;
        }

        public void InsertUsertoBD(Table givenUser)
        {
            using (var db = new Team33Entities())
            {
                foreach (var row in givenUser.Rows)
                {
                    var property = new USER
                    {
                        Email = row["Email"],
                        Password = row["Password"],
                        FullName = row["FullName"],
                        Phone = row["Phone"],
                        Address = row["Address"],
                        Role = row["Role"],
                        Status = Convert.ToBoolean(row["Status"])

                    };

                    db.USERs.Add(property);
                }

                db.SaveChanges();
            }
        }
        public void InsertProjecttoDB(Table givenProject)
        {

            using (var db = new Team33Entities())
            {
                foreach (var row in givenProject.Rows)
                {
                    //var district = db.DISTRICTs.ToList().FirstOrDefault(d => d.DistrictName == row["District"]);
                    var property = new PROPERTY
                    {
                        PropertyName = row["PropertyName"],
                        Avatar = row["Avarta"],
                        Images = row["Images"],
                        Content = row["Content"],
                        PropertyType_ID = db.PROPERTY_TYPE.ToList().FirstOrDefault(d => d.CodeType == row["PropertyType"]).ID,
                        Street_ID = db.STREETs.ToList().FirstOrDefault(x => x.StreetName == row["Street"]).ID,
                        Ward_ID = db.WARDs.ToList().FirstOrDefault(x => x.WardName == row["Ward"]).ID,
                        District_ID = db.DISTRICTs.ToList().FirstOrDefault(x => x.DistrictName == row["District"]).ID,
                        Price = int.Parse(row["Price"]),
                        UnitPrice = row["UnitPrice"],
                        Area = row["Area"],
                        BedRoom = int.Parse(row["BedRoom"]),
                        BathRoom = int.Parse(row["BathRoom"]),
                        PackingPlace = int.Parse(row["PackingPlace"]),
                        UserID = db.USERs.ToList().FirstOrDefault(x => x.FullName == row["UserID"]).ID,
                        Created_at = Convert.ToDateTime(row["Create_at"]),
                        Create_post = Convert.ToDateTime(row["Create_post"]),
                        Status_ID = db.PROJECT_STATUS.ToList().FirstOrDefault(x => x.Status_Name == row["Status"]).ID,
                        Note = row["Note"],
                        Updated_at = Convert.ToDateTime(row["Update_at"]),
                        Sale_ID = db.USERs.ToList().FirstOrDefault(x => x.FullName == row["Sale_ID"]).ID
                    };

                    //_context.ReferenceProject.Add(
                    //    givenProject.Header.Contains("Id") ? row["Id"] : property.PropertyName,
                    //    property);

                    db.PROPERTies.Add(property);
                }

                db.SaveChanges();
            }
        }

        public void InsertFeaturetoBD(Table givenFeature)
        {
            using (var db = new Team33Entities())
            {
                foreach (var row in givenFeature.Rows)
                {
                    var property = new PROPERTY_FEATURE
                    {

                        Property_ID = db.PROPERTies.ToList().FirstOrDefault(x => x.PropertyName == row["Property"]).ID,
                        Feature_ID = db.FEATUREs.ToList().FirstOrDefault(x => x.FeatureName == row["Feature"]).ID
                    };

                    db.PROPERTY_FEATURE.Add(property);
                }

                db.SaveChanges();
            }
        }

        //public void Navigate(string mail, string pass)
        //{
        //    //var controller = new AgencyController();
        //    //_result = controller.Login(mail, pass);

        //    var routeData = new RouteData();
        //    routeData.Values.Add("action", "Index");
        //    routeData.Values.Add("controller", "Agency");

        //    var AccountController = GetAgencyController(routeData);

        //    _result = AccountController.(mail, pass);

        //    if (((RedirectToRouteResult)_result).RouteValues["action"].Equals("Index"))
        //    {
        //        _result = HomeController.Index();

        //        var shownProperties = _result.Model<IEnumerable<PROPERTY>>();
        //        ScenarioContext.Current.Add("agencyProperty", shownProperties);
        //    }
        //}

        //private static AgencyController GetAgencyController(RouteData routedata)
        //{
        //    var controller = new AgencyController();
        //    HttpContextStub.SetupController(controller, routedata);
        //    return controller;
        //}

        //PótProject
        //public void NavigateCreateBook()
        //{
        //    _result = _controller.Create();
        //}
        //public void createProperty(Table inputBook)
        //{
        //    var row = inputBook.Rows[0];
        //    var db = new Team33Entities();

        //    var book = new PROPERTY
        //    {
        //        PropertyName = row["PropertyName"],
        //        //Avatar = row["Avarta"],
        //        //Images = row["Images"],
        //        Content = row["Content"],
        //        PropertyType_ID = db.PROPERTY_TYPE.ToList().FirstOrDefault(x => x.CodeType == (row["PropertyType"])).ID,
        //        Street_ID = db.STREETs.ToList().FirstOrDefault(x => x.StreetName == row["Street"]).ID,
        //        Ward_ID = db.WARDs.ToList().FirstOrDefault(x => x.WardName == row["Ward"]).ID,
        //        District_ID = db.DISTRICTs.ToList().FirstOrDefault(x => x.DistrictName == row["District"]).ID,
        //        Price = int.Parse(row["Price"]),
        //        UnitPrice = row["UnitPrice"],
        //        Area = row["Area"],
        //        BedRoom = int.Parse(row["BedRoom"]),
        //        BathRoom = int.Parse(row["BathRoom"]),
        //        PackingPlace = int.Parse(row["PackingPlace"]),
             
        //    };

        //    db.PROPERTies.Add(book);
        //    db.SaveChanges();

        //    //Save book item into ScenarioContext object so that we can get it in the next step (UploadImage)
        //    ScenarioContext.Current.Add("book", book);

        //    //Save the create action into ScenarioContext object so that we can get it in the next step (UploadImage)
        //    ScenarioContext.Current.Add("isCreated", "Y");
        //    //_result = _controller.Create(book);

        }

        //public void UploadImage(string uploadFiles)
        //{
        //    //Setup a fake HttpRequest
        //    Mock<HttpContextBase> moqContext = new Mock<HttpContextBase>();
        //    Mock<HttpRequestBase> moqRequest = new Mock<HttpRequestBase>();

        //    Mock<HttpFileCollectionBase> moqPostedFileCollection = new Mock<HttpFileCollectionBase>();
        //    Mock<HttpServerUtilityBase> moqServer = new Mock<HttpServerUtilityBase>();

        //    string imagePath = Path.Combine(ProjectLocation.FromFolder("PROPERTY").FullPath, @"\Images");
        //    moqServer.Setup(s => s.MapPath("~/Images/")).Returns(imagePath);
        //    moqContext.Setup(x => x.Server).Returns(moqServer.Object);
        //    moqContext.Setup(x => x.Request).Returns(moqRequest.Object);

        //    IEnumerable<string> fileNames = from t in uploadFiles.Split(',')
        //                                    select t.Trim().Trim('\'');

        //    moqPostedFileCollection.Setup(c => c.Count).Returns(fileNames.Count()); ///
        //    moqRequest.Setup(r => r.Files).Returns(moqPostedFileCollection.Object);

        //    for (int i = 0; i < fileNames.Count(); i++)
        //    {
        //        Mock<HttpPostedFileBase> moqPostedFile = new Mock<HttpPostedFileBase>();

        //        moqPostedFile.Setup(p => p.SaveAs(It.IsAny<string>())).Verifiable();

        //        moqPostedFileCollection.Setup(c => c[i]).Returns(moqPostedFile.Object); ///
        //    }

        //    //Pass the fake current HttpContext into the ControllerContext of CatalogController
        //    _controller.ControllerContext = new ControllerContext(moqContext.Object, new RouteData(), _controller);

        //    PROPERTY book = ScenarioContext.Current.Get<PROPERTY>("book");

        //    //Get the action from ScenarioContext object so that we can call the suitable action in CatalogController (Create/Edit Book)
        //    if (ScenarioContext.Current.Get<string>("isCreated") == "Y")
        //        _result = _controller.Create(book, List<>, " ");
        //    //else
        //    //    _result = _controller.Edit(book);
        //}

        //public void SaveImages()
        //{
        //    //Get the book item from ScenarioContext object (saved in the step of Create/Edit Book)
        //    PROPERTY book = ScenarioContext.Current.Get<PROPERTY>("book");

        //    //Arrange
        //    ActionResult result = _controller.Index();
        //    var bookLists = result.Model<IEnumerable<PROPERTY>>();

        //    //Get the image list of created/edited book item from table UploadFiles so that we can get the name of uploaded images 
        //    var db = new PROPERTY();
        //    var uploadFiles = db.ImageFile2.ToList().Where(u => bookLists.Where(b => b.PropertyName == book.PropertyName).Select(b => b.Id).Contains(u.p)).OrderBy(u => u.Id).ToList();

        //    //Act
        //    var moqRequest = Mock.Get<HttpRequestBase>(_controller.Request);

        //    //Assert
        //    for (int i = 0; i < uploadFiles.Count(); i++)
        //    {
        //        string filePath = Path.Combine(_controller.Server.MapPath("~/App_Data/Images/"), uploadFiles[i].Id.ToString());

        //        //Verify whether uploaded images saved on server by checking whether the fake current HttpRequest has invoked SaveAs method
        //        Mock.Get<HttpPostedFileBase>(_controller.Request.Files[i]).Verify(r => r.SaveAs(filePath));
        //    }
        //}



       // public void ShowList(Table expectednameList)
       //{
       //          //Arrange
       //          var expectedProjects = expectednameList.Rows.Select(r => r["PropertyName"]);

       //          //Actual
       //          var result = ScenarioContext.Current.Get<IEnumerable<PROPERTY>>("agencyProperty");
       //          //var actualProjects = result.Model<IEnumerable<PROPERTY>>();

       //          //Assert
       //          PropertyAssertions.HomeScreenShouldShow(result, expectedProjects);
       // }

       // public void ShowBooks(Table shownBooks)
       // {
       //     //Arrange
       //     var expectedBooks = shownBooks.CreateSet<PROPERTY>();

       //     //Act
       //     ActionResult result = _controller.Index();
       //     var actualBooks = result.Model<IEnumerable<PROPERTY>>();

       //     //Assert
       //     PropertyAssertions.BookListScreenShouldShowInOrder(actualBooks, expectedBooks);
       // }
       // public void Login(string email, string pwd)
       // {
       //     AccountController user = new AccountController();
       //     Team33Entities db = new Team33Entities();
       //     USER us = db.USERs.FirstOrDefault(d => d.Email == email);

       //     var moqContext = new Moq.Mock<ControllerContext>();
       //     var moqSession = new Moq.Mock<HttpSessionStateBase>();
       //     moqContext.Setup(c => c.HttpContext.Session).Returns(moqSession.Object);
       //     user.ControllerContext = moqContext.Object;
       //     moqSession.Setup(s => s["RoleID"]).Returns("2");

       //     us.Email = email;
       //     us.Password = pwd;
       //     us.Role = db.USERs.FirstOrDefault(d => d.Email == email).Role;
       //     us.Phone = db.USERs.FirstOrDefault(d => d.Email == email).Phone;
       //     us.Address = db.USERs.FirstOrDefault(d => d.Email == email).Address;
       //     us.Role = db.USERs.FirstOrDefault(d => d.Email == email).Role;
       //     us.ID = db.USERs.FirstOrDefault(d => d.Email == email).ID;
       //     us.Status = db.USERs.FirstOrDefault(d => d.Email == email).Status;
       //     us.FullName = db.USERs.FirstOrDefault(d => d.Email == email).FullName;
       //     user.Login(email, pwd);
        }
        //public void NavigateTOMyProject()
        //{
        //    Team33Entities get = new Team33Entities();
        //    UserController user = new UserController();

        //    var controller = new AgencyController();

        //    var moqContext = new Moq.Mock<ControllerContext>();
        //    var moqSession = new Moq.Mock<HttpSessionStateBase>();
        //    moqContext.Setup(c => c.HttpContext.Session).Returns(moqSession.Object);

        //    var us = get.USERs.FirstOrDefault(x => x.Email == "vothikimchi@gmail.com");
        //    //user.ControllerContext = moqContext.Object;

        //    controller.ControllerContext = moqContext.Object;
        //    moqSession.Setup(s => s["RoleID"]).Returns(us.Role);
        //    moqSession.Setup(s => s["UserID"]).Returns(us.ID);

        //    _result = controller.Index();
        //}
        //public void NavigateToEditPage(string namep)
        //{
        //    Team33Entities get = new Team33Entities();
        //    UserController user = new UserController();

        //    var controller = new AgencyController();

        //    var moqContext = new Moq.Mock<ControllerContext>();
        //    var moqSession = new Moq.Mock<HttpSessionStateBase>();
        //    moqContext.Setup(c => c.HttpContext.Session).Returns(moqSession.Object);

        //    var us = get.USERs.FirstOrDefault(x => x.Email == "vothikimchi@gmail.com");
        //    //user.ControllerContext = moqContext.Object;
        //    var b = get.PROPERTies.FirstOrDefault(x => x.PropertyName == namep).ID;
        //    var sid = get.PROPERTies.FirstOrDefault(x => x.PropertyName == namep).Status_ID;
        //    controller.ControllerContext = moqContext.Object;
        //    moqSession.Setup(s => s["RoleID"]).Returns(us.Role);
        //    moqSession.Setup(s => s["UserID"]).Returns(us.ID);
        //    int staid = (int)sid;
        //    var property = _context.ReferenceProject.GetById(namep);

        //    _result = controller.Edit(b, staid);

        //}
        //public void EditProjecttoDB(Table givenProject)
        //{

        //    using (var db = new Team33Entities())
        //    {
        //        foreach (var row in givenProject.Rows)
        //        {
        //            //var district = db.DISTRICTs.ToList().FirstOrDefault(d => d.DistrictName == row["District"]);
        //            var property = new PROPERTY
        //            {
        //                PropertyName = row["PropertyName"],
        //                Avatar = row["Avarta"],
        //                Images = row["Images"],
        //                Content = row["Content"],
        //                PropertyType_ID = db.PROPERTY_TYPE.ToList().FirstOrDefault(d => d.CodeType == row["PropertyType"]).ID,
        //                Street_ID = db.STREETs.ToList().FirstOrDefault(x => x.StreetName == row["Street"]).ID,
        //                Ward_ID = db.WARDs.ToList().FirstOrDefault(x => x.WardName == row["Ward"]).ID,
        //                District_ID = db.DISTRICTs.ToList().FirstOrDefault(x => x.DistrictName == row["District"]).ID,
        //                Price = int.Parse(row["Price"]),
        //                UnitPrice = row["UnitPrice"],
        //                Area = row["Area"],
        //                BedRoom = int.Parse(row["BedRoom"]),
        //                BathRoom = int.Parse(row["BathRoom"]),
        //                PackingPlace = int.Parse(row["PackingPlace"]),
        //                UserID = db.USERs.ToList().FirstOrDefault(x => x.FullName == row["UserID"]).ID,
        //                Created_at = Convert.ToDateTime(row["Create_at"]),
        //                Create_post = Convert.ToDateTime(row["Create_post"]),
        //                Status_ID = db.PROJECT_STATUS.ToList().FirstOrDefault(x => x.Status_Name == row["Status"]).ID,
        //                Note = row["Note"],
        //                Updated_at = Convert.ToDateTime(row["Update_at"]),
        //                Sale_ID = db.USERs.ToList().FirstOrDefault(x => x.FullName == row["Sale_ID"]).ID
        //            };

        //            //_context.ReferenceProject.Add(
        //            //    givenProject.Header.Contains("Id") ? row["Id"] : property.PropertyName,
        //            //    property);

        //        }

        //        db.SaveChanges();
        //    }
        //}
        //public void ShowProperty(Table expectedProperty)
        //{
        //    ShowProperty(expectedProperty.Rows.Select(r => r["PropertyName"]));
        //}
        //public void ShowProperty(IEnumerable<string> expectedTitles)
        //{
        //    //Act

        //    var shownBooks = _result.Model<IEnumerable<PROPERTY>>();

        //    //Assert
        //    //PropertyAssertions.ManageShouldShowList(shownBooks, expectedTitles);

       
    

