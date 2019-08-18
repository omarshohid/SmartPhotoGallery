using DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DAL.Models;
using System.Security.Principal;
using System.Runtime.InteropServices;
using System.IO;
using System.Drawing;
using System.Data.Entity;

namespace BDCO.Web.Controllers
{
    public class HomeController : Controller
    {
        UnitOfWork unitOfWork = new UnitOfWork();

        IntPtr admin_token = default(IntPtr);
        WindowsIdentity wid_current = WindowsIdentity.GetCurrent();
        WindowsIdentity wid_admin = null;
        WindowsImpersonationContext wic = null;

        [Authorize]
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult LandingPage()
        {
            return View();
        }

        [HttpGet]
        public JsonResult LoadApprovedImages(ImageLoadRequest req)
        {
            try
            {
                var result = unitOfWork.SPRepository.GetApprovedImageList(req);
                var totalRecored = unitOfWork.SPRepository.GetTotalRecored(req, 1);
                return Json(new { success = true, Data = result, TotalRecord = totalRecored }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, Data = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public JsonResult LoadApprovedImagesByCategory(ImageLoadRequest req)
        {
            try
            {
                var result = unitOfWork.SPRepository.GetApprovedImageListByCategory(req);
                var totalRecored = unitOfWork.SPRepository.GetTotalRecoredByCategory(req, 1);
                return Json(new { success = true, Data = result, TotalRecord = totalRecored }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, Data = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public JsonResult LoadApprovedImagesByTag(ImageLoadRequest req)
        {
            try
            {
                var result = unitOfWork.SPRepository.GetApprovedImageListByTag(req);
                var totalRecored = unitOfWork.SPRepository.GetTotalRecoredByTag(req, 1);
                return Json(new { success = true, Data = result, TotalRecord = totalRecored }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, Data = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }





        [HttpGet]
        public JsonResult LoadUnapprovedImages(ImageLoadRequest req)
        {
            try
            {
                var result = unitOfWork.SPRepository.GetUnapprovedImageList(req);
                var totalRecored = unitOfWork.SPRepository.GetTotalRecored(req, 0);
                return Json(new { success = true, Data = result, TotalRecord = totalRecored }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, Data = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        [Authorize]
        [HttpGet]
        public ActionResult PendingList()
        {
            return View();
        }


        [Authorize]
        [HttpGet]
        public ActionResult ApprovedList()
        {
            return View();
        }


        [HttpGet]
        public JsonResult LoadCategory()
        {
            try
            {
                var result = unitOfWork.SPRepository.GetCategoryList();
                return Json(new { success = true, Data = result }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, Data = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public JsonResult LoadEvents()
        {
            try
            {
                var result = unitOfWork.SPRepository.GetEventsList();
                return Json(new { success = true, Data = result }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, Data = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }



        [HttpGet]
        public JsonResult LoadLatestImages()
        {
            try
            {
                var result = unitOfWork.SPRepository.GetLatestImages();
                return Json(new { success = true, Data = result }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, Data = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        [Authorize]
        public JsonResult ApproveImage(List<Images_VM> data)
        {
            try
            {
                foreach (var item in data)
                {
                    var image = unitOfWork.Repositories<Images>().Get(x => x.ImageId == item.ImageId).FirstOrDefault();
                    image.ImageTitle = item.ImageTitle;
                    image.ImageTag = item.ImageTag;
                    image.ImageDetails = item.ImageDetails;
                    image.IsApproved = 1;
                    image.ApprovedBy = User.Identity.Name;
                    image.ApproveDate = DateTime.Now;
                    unitOfWork.Repositories<Images>().Update(image);
                }
                unitOfWork.Save();
                return Json(new { success = true, Data = "Data Verified Successfully" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, Data = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        [Authorize]
        public JsonResult DeleteImage(List<Images_VM> data)
        {
            try
            {
                foreach (var item in data)
                {
                    var image = unitOfWork.Repositories<Images>().Get(x => x.ImageId == item.ImageId).FirstOrDefault();
                    if(image != null)
                    {
                        unitOfWork.Repositories<Images>().Delete(image);
                    }                   
                }
                unitOfWork.Save();
                return Json(new { success = true, Data = "Data Deleted Successfully" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, Data = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }


        [HttpGet]
        public JsonResult LoadPopularTags()
        {
            try
            {
                var result = unitOfWork.Repositories<PopularTags>().Get().ToList().Take(10).OrderBy(x => x.Id);
                return Json(new { success = true, Data = result }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, Data = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public JsonResult LoadAllTags(string Prefix)
        {
            try
            {
                var result = unitOfWork.Repositories<PopularTags>().Get().ToList();
                var TagList = (from N in result
                               where N.TagName.StartsWith(Prefix)
                               select new { N.TagName });
                return Json(TagList, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, Data = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult DownloadImage(int id)
        {
            byte[] fileBytes = null;
            try
            {

                if (LogonUserA("rimroseadmin", "dhaka", "Welcome1", 9, 0, ref admin_token) != 0)
                {
                    wid_admin = new WindowsIdentity(admin_token);
                    wic = wid_admin.Impersonate();
                    string imageName = "";
                    var imageInfo = unitOfWork.Repositories<Images>().Get().FirstOrDefault(x => x.ImageId == id);
                    if (imageInfo != null)
                    {
                        DatabaseContext context = new DatabaseContext();
                        imageInfo.NoOfDownload = (imageInfo.NoOfDownload ?? 0) + 1;
                        context.Images.Attach(imageInfo);
                        context.Entry(imageInfo).State = EntityState.Modified;
                        context.SaveChanges();

                        imageName = imageInfo.ImageUrl.Split('/').Last();
                        imageInfo.ImageUrl = imageInfo.ImageUrl.Replace("http://mediagallery.scibd.info/", "");
                        imageInfo.ImageUrl = "\\\\10.12.0.3\\SCI Event\\" + imageInfo.ImageUrl.Replace("/", "\\");
                        imageInfo.ImageUrl = imageInfo.ImageUrl.Replace("amp;", "");
                        
                    }
                    string contentType = "Image/jpeg";

                    fileBytes = System.IO.File.ReadAllBytes(imageInfo.ImageUrl);
                    return File(fileBytes, contentType, imageName);
                }
                else
                {
                    return Json(new { Success = false, Message = "Authentication failed! Unable to download image!" }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (System.Exception se)
            {
                return Json(new { Success = false, Message = se.Message }, JsonRequestBehavior.AllowGet);
            }
            finally
            {
                if (wic != null)
                {
                    wic.Undo();
                }
            }
            //Image newImage;
            //using (var fs = new FileStream("ABC.jpg", FileMode.Create, FileAccess.Write))
            //{
            //    fs.Write(fileBytes, 0, fileBytes.Length);
            //    newImage = Image.FromStream(fs, true);
            //}
            
            // var f = new File().WriteAllBytes(fileBytes);


           // return newImage;
        }


        #region Impersionation global variables
        public const int LOGON32_LOGON_INTERACTIVE = 2;
        public const int LOGON32_PROVIDER_DEFAULT = 0;

        WindowsImpersonationContext impersonationContext;
        [DllImport("advapi32.DLL", SetLastError = true)]


        public static extern int LogonUserA(String lpszUserName,
            String lpszDomain,
            String lpszPassword,
            int dwLogonType,
            int dwLogonProvider,
            ref IntPtr phToken);
        [DllImport("advapi32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern int DuplicateToken(IntPtr hToken,
            int impersonationLevel,
            ref IntPtr hNewToken);

        [DllImport("advapi32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern bool RevertToSelf();

        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        public static extern bool CloseHandle(IntPtr handle);

        #endregion

    }
}