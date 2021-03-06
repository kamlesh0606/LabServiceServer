using System;
using System.ComponentModel;
using System.Threading;
using System.Web;
using SubSonic;

// <auto-generated />

namespace Vietbait.Lablink.Model
{
    /// <summary>
    ///     Controller class for D_DEVICE_LIST
    /// </summary>
    [DataObject]
    public class DDeviceListController
    {
        // Preload our schema..
        private DDeviceList thisSchemaLoad = new DDeviceList();
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
        public DDeviceListCollection FetchAll()
        {
            var coll = new DDeviceListCollection();
            var qry = new Query(DDeviceList.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public DDeviceListCollection FetchByID(object DeviceId)
        {
            DDeviceListCollection coll = new DDeviceListCollection().Where("Device_ID", DeviceId).Load();
            return coll;
        }

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public DDeviceListCollection FetchByQuery(Query qry)
        {
            var coll = new DDeviceListCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }

        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object DeviceId)
        {
            return (DDeviceList.Delete(DeviceId) == 1);
        }

        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object DeviceId)
        {
            return (DDeviceList.Destroy(DeviceId) == 1);
        }


        /// <summary>
        ///     Inserts a record, can be used with the Object Data Source
        /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
        public void Insert(int? DeviceType, int? TestTypeId, string DeviceName, int? PortId, short? ManufactureId,
            bool? DeviceControl, bool? Valid, string Description, string BarcodeType, short SendType)
        {
            var item = new DDeviceList();

            item.DeviceType = DeviceType;

            item.TestTypeId = TestTypeId;

            item.DeviceName = DeviceName;

            item.PortId = PortId;

            item.ManufactureId = ManufactureId;

            item.DeviceControl = DeviceControl;

            item.Valid = Valid;

            item.Description = Description;

            item.BarcodeType = BarcodeType;

            item.SendType = SendType;


            item.Save(UserName);
        }

        /// <summary>
        ///     Updates a record, can be used with the Object Data Source
        /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
        public void Update(decimal DeviceId, int? DeviceType, int? TestTypeId, string DeviceName, int? PortId,
            short? ManufactureId, bool? DeviceControl, bool? Valid, string Description, string BarcodeType,
            short SendType)
        {
            var item = new DDeviceList();
            item.MarkOld();
            item.IsLoaded = true;

            item.DeviceId = DeviceId;

            item.DeviceType = DeviceType;

            item.TestTypeId = TestTypeId;

            item.DeviceName = DeviceName;

            item.PortId = PortId;

            item.ManufactureId = ManufactureId;

            item.DeviceControl = DeviceControl;

            item.Valid = Valid;

            item.Description = Description;

            item.BarcodeType = BarcodeType;

            item.SendType = SendType;

            item.Save(UserName);
        }
    }
}