using System;
using System.ComponentModel;
using System.Threading;
using System.Web;
using SubSonic;

// <auto-generated />

namespace Vietbait.Lablink.Model
{
    /// <summary>
    ///     Controller class for Sys_PrintColorDetail
    /// </summary>
    [DataObject]
    public class SysPrintColorDetailController
    {
        // Preload our schema..
        private SysPrintColorDetail thisSchemaLoad = new SysPrintColorDetail();
        private string userName = String.Empty;

        protected string UserName
        {
            get
            {
                if (userName.Length == 0)
                {
                    if (HttpContext.Current != null)
                    {
                        userName = HttpContext.Current.User.Identity.Name;
                    }
                    else
                    {
                        userName = Thread.CurrentPrincipal.Identity.Name;
                    }
                }
                return userName;
            }
        }

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public SysPrintColorDetailCollection FetchAll()
        {
            var coll = new SysPrintColorDetailCollection();
            var qry = new Query(SysPrintColorDetail.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public SysPrintColorDetailCollection FetchByID(object Id)
        {
            SysPrintColorDetailCollection coll = new SysPrintColorDetailCollection().Where("ID", Id).Load();
            return coll;
        }

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public SysPrintColorDetailCollection FetchByQuery(Query qry)
        {
            var coll = new SysPrintColorDetailCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }

        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object Id)
        {
            return (SysPrintColorDetail.Delete(Id) == 1);
        }

        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object Id)
        {
            return (SysPrintColorDetail.Destroy(Id) == 1);
        }


        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(int Id, int TestTypeId)
        {
            var qry = new Query(SysPrintColorDetail.Schema);
            qry.QueryType = QueryType.Delete;
            qry.AddWhere("Id", Id).AND("TestTypeId", TestTypeId);
            qry.Execute();
            return (true);
        }


        /// <summary>
        ///     Inserts a record, can be used with the Object Data Source
        /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
        public void Insert(int Id, int TestTypeId)
        {
            var item = new SysPrintColorDetail();

            item.Id = Id;

            item.TestTypeId = TestTypeId;


            item.Save(UserName);
        }

        /// <summary>
        ///     Updates a record, can be used with the Object Data Source
        /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
        public void Update(int Id, int TestTypeId)
        {
            var item = new SysPrintColorDetail();
            item.MarkOld();
            item.IsLoaded = true;

            item.Id = Id;

            item.TestTypeId = TestTypeId;

            item.Save(UserName);
        }
    }
}