using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Dynamic;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Hosting;
using System.Net;
using System.IO;
using Restaurant.Models;

namespace Restaurant.Controllers
{
    public class MasterController : Controller
    {
        Admin objAdmin = new Admin();
        clsFile cls = new clsFile();
        static SqlConnection Conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString());
        // GET: Master
        public ActionResult Index()
        {
            return View();
        }
        // GET: Category Masters
        public ActionResult Menu()
        {
            if (Session["LoggedUserName"] != null)
            {
                List<MenuDetail> MenuDetail = new List<MenuDetail>();
                List<MCategoryDetail> MCategory = new List<MCategoryDetail>();
                string str = "SELECT MCat_Id,MCat_Name FROM [dbo].[tblMCategory] ORDER BY MCat_Name ";
                DataTable dt = new DataTable();
                dt = cls.getDatatable(str);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        MCategory.Add(new MCategoryDetail() { MCat_Id = Convert.ToInt32(dr["MCat_Id"].ToString()), MCat_Name = dr["MCat_Name"].ToString() });
                    }
                }

                string str1 = "SELECT M_Id, MenuName, MCat_Id, (SELECT MCat_Name FROM[dbo].[tblMCategory] C WHERE C.MCat_Id = M.MCat_Id) as MCat_Name, MT_Id, (SELECT T.MType_Name FROM[dbo].[tblMType] T WHERE T.MT_Id=M.MT_Id) as MType_Name, Price, Discount,Active FROM [dbo].[tblMenu] M ORDER BY M.M_Id";
                DataTable dt1 = new DataTable();
                dt1 = cls.getDatatable(str1);
                if (dt1.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt1.Rows)
                    {
                        MenuDetail.Add(new MenuDetail() { M_Id = Convert.ToInt32(dr["M_Id"].ToString()), MenuName = dr["MenuName"].ToString(), MCat_Id = Convert.ToInt32(dr["MCat_Id"].ToString()), MCat_Name = dr["MCat_Name"].ToString(), MT_Id = Convert.ToInt32(dr["MT_Id"].ToString()), MType_Name = dr["MType_Name"].ToString(), Price = Convert.ToDouble(dr["Price"].ToString()), Discount = Convert.ToDouble(dr["Discount"].ToString()), Active = Convert.ToString(dr["Active"]) });
                    }
                }


                dynamic model = new ExpandoObject();
                model.MCategory = MCategory;
                model.MenuDetail = MenuDetail;
                ViewData["AllModel"] = model;
                return View("Menu");
            }
            else
            {
                return RedirectToAction("Login", "Admin");
            }
        }
        public ActionResult AddMenu()
        {
            if (Session["LoggedUserName"] != null)
            {
                List<MenuDetail> MenuDetail = new List<MenuDetail>();
                List<MCategoryDetail> MCategory = new List<MCategoryDetail>();
                string str = "SELECT MCat_Id,MCat_Name FROM [dbo].[tblMCategory] ORDER BY MCat_Name ";
                DataTable dt = new DataTable();
                dt = cls.getDatatable(str);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        MCategory.Add(new MCategoryDetail() { MCat_Id = Convert.ToInt32(dr["MCat_Id"].ToString()), MCat_Name = dr["MCat_Name"].ToString() });
                    }
                }
                if (TempData["MenuDetailByM_Id"] != null)
                {
                    dynamic model = new ExpandoObject();
                    model.MCategory = MCategory;
                    model.MenuDetail = TempData["MenuDetailByM_Id"];
                    ViewData["AllModel"] = model;
                    return View("AddMenu");
                }
                else
                {
                    dynamic model = new ExpandoObject();
                    model.MCategory = MCategory;
                    model.MenuDetail = MenuDetail;
                    ViewData["AllModel"] = model;
                    return View("AddMenu");
                }
            }
            else
            {
                return RedirectToAction("Login", "Admin");
            }
        }
        [HttpPost]
        public ActionResult JSONEditMenu(MenuDetail MD)
        {
            try
            {
                List<MenuDetail> MenuDetail = new List<MenuDetail>();
                string str1 = "SELECT M_Id, MenuName, MCat_Id, (SELECT MCat_Name FROM[dbo].[tblMCategory] C WHERE C.MCat_Id = M.MCat_Id) as MCat_Name, MT_Id, (SELECT T.MType_Name FROM[dbo].[tblMType] T WHERE T.MT_Id=M.MT_Id) as MType_Name, Price, Discount,Active FROM[dbo].[tblMenu] M WHERE M.M_Id=" + MD.M_Id;
                DataTable dt1 = new DataTable();
                dt1 = cls.getDatatable(str1);
                if (dt1.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt1.Rows)
                    {
                        MenuDetail.Add(new MenuDetail() { M_Id = Convert.ToInt32(dr["M_Id"].ToString()), MenuName = dr["MenuName"].ToString(), MCat_Id = Convert.ToInt32(dr["MCat_Id"].ToString()), MCat_Name = dr["MCat_Name"].ToString(), MT_Id = Convert.ToInt32(dr["MT_Id"].ToString()), MType_Name = dr["MType_Name"].ToString(), Price = Convert.ToDouble(dr["Price"].ToString()), Discount = Convert.ToDouble(dr["Discount"].ToString()), Active = Convert.ToString(dr["Active"]) });
                    }
                }

                TempData["MenuDetailByM_Id"] = MenuDetail;

                return Json(new
                {

                    msg = ""
                });

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpPost]
        public ActionResult JSONDeleteMenu(MenuDetail MD)
        {
            try
            {
                int irows;
                string str = "Delete from [dbo].[tblMenu] WHERE M_Id=" + MD.M_Id;
                irows = cls.Executesql(str);
                if (irows > 0)
                {
                    return Json(new
                    {

                        msg = "Delete Successfully"
                    });

                }
                else
                {

                    return Json(new
                    {

                        msg = ""
                    });
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpPost]
        public ActionResult SaveMenu(string hidM_Id1, string txtMenu, string hidMCat_Id1, string hidMT_Id1, string txtPrice, string txtDiscount, string hidActive1)
        {
            if (Session["LoggedUserName"] != null)
            {
                bool active = false;
                if (hidActive1 == "true")
                {
                    active = true;
                }
                if (Convert.ToInt32(hidM_Id1) > 0)
                {
                    string str = "UPDATE tblMenu SET MenuName = '" + txtMenu + "', MCat_Id = " + hidMCat_Id1 + ", MT_Id=" + hidMT_Id1 + " ,Price = " + txtPrice + ",Discount = " + txtDiscount + ", Active='" + active + "' WHERE (M_Id = " + Convert.ToInt32(hidM_Id1) + ")";
                    Int32 M_Id;
                    M_Id = cls.Executesql(str);
                }
                else
                {
                    string strsql = "SELECT MAX(M_Id) as MaxM_Id FROM tblMenu";
                    Int32 M_Id;
                    M_Id = cls.ExecuteScalar(strsql);
                    M_Id = M_Id + 1;

                    string str = "INSERT INTO tblMenu(MenuName,MCat_Id,MT_Id,Price,Discount,Active,Status,AppModifiedNum) VALUES ('" + txtMenu + "'," + hidMCat_Id1 + "," + hidMT_Id1 + "," + txtPrice + "," + txtDiscount + ", '" + active + "'," + 1 + ", " + 1 + ")";
                    Int32 SubCatID;
                    SubCatID = cls.Executesql(str);
                }


                return RedirectToAction("Menu");
            }
            else
            {
                return RedirectToAction("Login", "Admin");
            }
        }
        List<MTypeDetail> MTypeDetail = new List<MTypeDetail>();
        [HttpPost]
        public JsonResult GetMCategoryJson(string MCat = null)
        {
            return Json(Get_MTypeDetail(MCat));
        }
        public SelectList Get_MTypeDetail(string MCat = null)
        {
            getsubcat(MCat);
            return new SelectList(MTypeDetail, "Value", "Text", MCat);

        }

        public void getsubcat(string MCat)
        {
            clsFile cls = new clsFile();
            string str = "";
            str = "SELECT MT_Id, MType_Name FROM [dbo].[tblMType] WHERE MCat_Id = '" + MCat + "'  order by MType_Name";
            DataSet ds = cls.getDataSet(str);
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                MTypeDetail.Add(new MTypeDetail
                {
                    Text = dr["MType_Name"].ToString(),
                    Value = Convert.ToInt32(dr["MT_Id"].ToString())
                });
            }
        }
    }
}