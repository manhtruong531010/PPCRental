using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using Website_BDS.AcceptanceTests.Drivers.Search;
using Website_BDS.AcceptanceTests.Drivers.PropertyDetails;

namespace Website_BDS.AcceptanceTests.StepDefinitions
{
    [Binding, Scope(Tag = "automated")]
     class UC001_FilterPropertySteps    
    {

        private readonly SearchDriver _searchDriver;

        public UC001_FilterPropertySteps(SearchDriver drivers)
        {
            _searchDriver = drivers;

        }

                [When(@"Tim property cac cum tu llll Name Quan Duong Type Min Max '(.*)','(.*)','(.*)','(.*)','(.*)','(.*)'")]
        public void WhenTimPropertyCacCumTuLlllNameQuanDuongTypeMinMax(string p0, string p1, string p2, string p3, int p4, int p5)
        {
           
           
            _searchDriver.Search(p3, p1, p2  , p0,p4.ToString(),p5.ToString());
        }

        [Then(@"Danh sach property hien ra chi nen co PropertyName chua ki tu: '(.*)'")]
        public void ThenDanhSachPropertyHienRaChiNenCoPropertyNameChuaKiTu(string p0)
        {
            _searchDriver.ShowBooks(p0);
        }

        [When(@"Khong co truong du lieu nao duoc nhap")]
        public void WhenKhongCoTruongDuLieuNaoDuocNhap()
        {
            _searchDriver.Search("", "", "", "", "","");
        }

        [Then(@"Danh sanh tat ca duoc hien thi")]
        public void ThenDanhSanhTatCaDuocHienThi(Table table)
        {
            _searchDriver.ShowBooks(table);
        }



    }
}

