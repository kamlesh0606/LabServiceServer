using System;
using System.ComponentModel;
using System.Threading;
using System.Web;
using SubSonic;

// <auto-generated />

namespace Vietbait.Lablink.Model
{
    /// <summary>
    ///     Controller class for T_TEST_TYPE_LIST
    /// </summary>
    [DataObject]
    public class TTestTypeListController
    {
        // Preload our schema..
        private TTestTypeList thisSchemaLoad = new TTestTypeList();
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
        public TTestTypeListCollection FetchAll()
        {
            var coll = new TTestTypeListCollection();
            var qry = new Query(TTestTypeList.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public TTestTypeListCollection FetchByID(object TestTypeId)
        {
            TTestTypeListCollection coll = new TTestTypeListCollection().Where("TestType_ID", TestTypeId).Load();
            return coll;
        }

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public TTestTypeListCollection FetchByQuery(Query qry)
        {
            var coll = new TTestTypeListCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }

        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object TestTypeId)
        {
            return (TTestTypeList.Delete(TestTypeId) == 1);
        }

        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object TestTypeId)
        {
            return (TTestTypeList.Destroy(TestTypeId) == 1);
        }


        /// <summary>
        ///     Inserts a record, can be used with the Object Data Source
        /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
        public void Insert(string TestTypeName, string Note, short? IntOrder, short? PrintDetail, decimal? Price,
            string Abbreviation)
        {
            var item = new TTestTypeList();

            item.TestTypeName = TestTypeName;

            item.Note = Note;

            item.IntOrder = IntOrder;

            item.PrintDetail = PrintDetail;

            item.Price = Price;

            item.Abbreviation = Abbreviation;


            item.Save(UserName);
        }

        /// <summary>
        ///     Updates a record, can be used with the Object Data Source
        /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
        public void Update(int TestTypeId, string TestTypeName, string Note, short? IntOrder, short? PrintDetail,
            decimal? Price, string Abbreviation)
        {
            var item = new TTestTypeList();
            item.MarkOld();
            item.IsLoaded = true;

            item.TestTypeId = TestTypeId;

            item.TestTypeName = TestTypeName;

            item.Note = Note;

            item.IntOrder = IntOrder;

            item.PrintDetail = PrintDetail;

            item.Price = Price;

            item.Abbreviation = Abbreviation;

            item.Save(UserName);
        }
    }
}