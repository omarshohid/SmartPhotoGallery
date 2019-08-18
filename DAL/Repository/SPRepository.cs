
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Repository
{
    public class SPRepository : IDisposable
    {
        private DatabaseContext context;
        public SPRepository(DatabaseContext context)
        {
            this.context = context;
        }

        //*------Example------*//

        public List<Images_VM> GetApprovedImageList(ImageLoadRequest req)
        {
            string sql = string.Format(@"Exec GetApprovedImages {0},{1},'{2}','{3}','{4}','{5}'", req.PageNo, req.PageSize, req.Category ?? "", req.FileName ?? "", req.TagName ?? "",req.EventName ?? "");
            var result = context.Database.SqlQuery<Images_VM>(sql).ToList();
            return result;
        }

        public List<Images_VM> GetApprovedImageListByCategory(ImageLoadRequest req)
        {
            string sql = string.Format(@"Exec GetApprovedImagesByCategory {0},{1},'{2}'", req.PageNo, req.PageSize, req.Category ?? "");
            var result = context.Database.SqlQuery<Images_VM>(sql).ToList();
            return result;
        }

        public List<Images_VM> GetApprovedImageListByTag(ImageLoadRequest req)
        {
            string sql = string.Format(@"Exec GetApprovedImagesByTag {0},{1},'{2}'", req.PageNo, req.PageSize, req.TagName ?? "");
            var result = context.Database.SqlQuery<Images_VM>(sql).ToList();
            return result;
        }

        public List<Images_VM> GetUnapprovedImageList(ImageLoadRequest req)
        {
            string sql = string.Format(@"Exec GetUnapprovedImages {0},{1},'{2}','{3}','{4}','{5}'", req.PageNo, req.PageSize, req.Category ?? "", req.FileName ?? "", req.TagName ?? "", req.EventName ?? "");
            var result = context.Database.SqlQuery<Images_VM>(sql).ToList();
            return result;
        }

        public int GetTotalRecored(ImageLoadRequest req,int status)
        {
            string sql = string.Format(@"Exec GetTotalRecord '{0}','{1}','{2}','{3}',{4}", req.Category ?? "", req.FileName ?? "", req.TagName ?? "",req.EventName ?? "",status);
            var result = context.Database.SqlQuery<int>(sql).FirstOrDefault();
            return result;
        }

        public int GetTotalRecoredByCategory(ImageLoadRequest req, int status)
        {
            string sql = string.Format(@"Exec GetTotalRecordByCategory '{0}',{1}", req.Category ?? "", status);
            var result = context.Database.SqlQuery<int>(sql).FirstOrDefault();
            return result;
        }

        public int GetTotalRecoredByTag(ImageLoadRequest req, int status)
        {
            string sql = string.Format(@"Exec GetTotalRecoredByTag '{0}',{1}", req.TagName ?? "", status);
            var result = context.Database.SqlQuery<int>(sql).FirstOrDefault();
            return result;
        }

        public List<Category> GetCategoryList()
        {
            string sql = string.Format(@"Exec GetCategoryList");
            var result = context.Database.SqlQuery<Category>(sql).ToList();
            return result;
        }
        
        public List<Events> GetEventsList()
        {
            string sql = string.Format(@"Exec GetEventsList");
            var result = context.Database.SqlQuery<Events>(sql).ToList();
            return result;
        }

        public List<Images_VM> GetLatestImages()
        {
            string sql = string.Format(@"Exec GetLatestImages");
            var result = context.Database.SqlQuery<Images_VM>(sql).ToList();
            return result;
        }
        //*-------End-----------*//


        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
