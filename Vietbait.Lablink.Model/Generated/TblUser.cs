using System;
using System.ComponentModel;
using System.Data;
using System.Reflection;
using System.Threading;
using System.Web;
using System.Web.UI.WebControls;
using System.Xml.Serialization;
using SubSonic;

// <auto-generated />

namespace Vietbait.Lablink.Model
{
    /// <summary>
    ///     Strongly-typed collection for the TblUser class.
    /// </summary>
    [Serializable]
    public class TblUserCollection : ActiveList<TblUser, TblUserCollection>
    {
        /// <summary>
        ///     Filters an existing collection based on the set criteria. This is an in-memory filter
        ///     Thanks to developingchris for this!
        /// </summary>
        /// <returns>TblUserCollection</returns>
        public TblUserCollection Filter()
        {
            for (int i = Count - 1; i > -1; i--)
            {
                TblUser o = this[i];
                foreach (Where w in wheres)
                {
                    bool remove = false;
                    PropertyInfo pi = o.GetType().GetProperty(w.ColumnName);
                    if (pi.CanRead)
                    {
                        object val = pi.GetValue(o, null);
                        switch (w.Comparison)
                        {
                            case Comparison.Equals:
                                if (!val.Equals(w.ParameterValue))
                                {
                                    remove = true;
                                }
                                break;
                        }
                    }
                    if (remove)
                    {
                        Remove(o);
                        break;
                    }
                }
            }
            return this;
        }
    }

    /// <summary>
    ///     This is an ActiveRecord class which wraps the tbl_Users table.
    /// </summary>
    [Serializable]
    public class TblUser : ActiveRecord<TblUser>, IActiveRecord
    {
        #region .ctors and Default Settings

        public TblUser()
        {
            SetSQLProps();
            InitSetDefaults();
            MarkNew();
        }

        public TblUser(bool useDatabaseDefaults)
        {
            SetSQLProps();
            if (useDatabaseDefaults)
                ForceDefaults();
            MarkNew();
        }

        public TblUser(object keyID)
        {
            SetSQLProps();
            InitSetDefaults();
            LoadByKey(keyID);
        }

        public TblUser(string columnName, object columnValue)
        {
            SetSQLProps();
            InitSetDefaults();
            LoadByParam(columnName, columnValue);
        }

        private void InitSetDefaults()
        {
            SetDefaults();
        }

        protected static void SetSQLProps()
        {
            GetTableSchema();
        }

        #endregion

        #region Schema and Query Accessor	

        public static TableSchema.Table Schema
        {
            get
            {
                if (BaseSchema == null)
                    SetSQLProps();
                return BaseSchema;
            }
        }

        public static Query CreateQuery()
        {
            return new Query(Schema);
        }

        private static void GetTableSchema()
        {
            if (!IsSchemaInitialized)
            {
                //Schema declaration
                var schema = new TableSchema.Table("tbl_Users", TableType.Table, DataService.GetInstance("ORM"));
                schema.Columns = new TableSchema.TableColumnCollection();
                schema.SchemaName = @"dbo";
                //columns

                var colvarPkSuid = new TableSchema.TableColumn(schema);
                colvarPkSuid.ColumnName = "PK_sUID";
                colvarPkSuid.DataType = DbType.String;
                colvarPkSuid.MaxLength = 50;
                colvarPkSuid.AutoIncrement = false;
                colvarPkSuid.IsNullable = false;
                colvarPkSuid.IsPrimaryKey = true;
                colvarPkSuid.IsForeignKey = false;
                colvarPkSuid.IsReadOnly = false;
                colvarPkSuid.DefaultSetting = @"";
                colvarPkSuid.ForeignKeyTableName = "";
                schema.Columns.Add(colvarPkSuid);

                var colvarFpSBranchID = new TableSchema.TableColumn(schema);
                colvarFpSBranchID.ColumnName = "FP_sBranchID";
                colvarFpSBranchID.DataType = DbType.String;
                colvarFpSBranchID.MaxLength = 10;
                colvarFpSBranchID.AutoIncrement = false;
                colvarFpSBranchID.IsNullable = false;
                colvarFpSBranchID.IsPrimaryKey = true;
                colvarFpSBranchID.IsForeignKey = true;
                colvarFpSBranchID.IsReadOnly = false;
                colvarFpSBranchID.DefaultSetting = @"";

                colvarFpSBranchID.ForeignKeyTableName = "tbl_ManagementUnit";
                schema.Columns.Add(colvarFpSBranchID);

                var colvarSPwd = new TableSchema.TableColumn(schema);
                colvarSPwd.ColumnName = "sPwd";
                colvarSPwd.DataType = DbType.String;
                colvarSPwd.MaxLength = 50;
                colvarSPwd.AutoIncrement = false;
                colvarSPwd.IsNullable = true;
                colvarSPwd.IsPrimaryKey = false;
                colvarSPwd.IsForeignKey = false;
                colvarSPwd.IsReadOnly = false;
                colvarSPwd.DefaultSetting = @"";
                colvarSPwd.ForeignKeyTableName = "";
                schema.Columns.Add(colvarSPwd);

                var colvarSFullName = new TableSchema.TableColumn(schema);
                colvarSFullName.ColumnName = "sFullName";
                colvarSFullName.DataType = DbType.String;
                colvarSFullName.MaxLength = 100;
                colvarSFullName.AutoIncrement = false;
                colvarSFullName.IsNullable = true;
                colvarSFullName.IsPrimaryKey = false;
                colvarSFullName.IsForeignKey = false;
                colvarSFullName.IsReadOnly = false;
                colvarSFullName.DefaultSetting = @"";
                colvarSFullName.ForeignKeyTableName = "";
                schema.Columns.Add(colvarSFullName);

                var colvarSDepart = new TableSchema.TableColumn(schema);
                colvarSDepart.ColumnName = "sDepart";
                colvarSDepart.DataType = DbType.String;
                colvarSDepart.MaxLength = 100;
                colvarSDepart.AutoIncrement = false;
                colvarSDepart.IsNullable = true;
                colvarSDepart.IsPrimaryKey = false;
                colvarSDepart.IsForeignKey = false;
                colvarSDepart.IsReadOnly = false;
                colvarSDepart.DefaultSetting = @"";
                colvarSDepart.ForeignKeyTableName = "";
                schema.Columns.Add(colvarSDepart);

                var colvarTDateCreated = new TableSchema.TableColumn(schema);
                colvarTDateCreated.ColumnName = "tDateCreated";
                colvarTDateCreated.DataType = DbType.DateTime;
                colvarTDateCreated.MaxLength = 0;
                colvarTDateCreated.AutoIncrement = false;
                colvarTDateCreated.IsNullable = true;
                colvarTDateCreated.IsPrimaryKey = false;
                colvarTDateCreated.IsForeignKey = false;
                colvarTDateCreated.IsReadOnly = false;
                colvarTDateCreated.DefaultSetting = @"";
                colvarTDateCreated.ForeignKeyTableName = "";
                schema.Columns.Add(colvarTDateCreated);

                var colvarISecurityLevel = new TableSchema.TableColumn(schema);
                colvarISecurityLevel.ColumnName = "iSecurityLevel";
                colvarISecurityLevel.DataType = DbType.Int16;
                colvarISecurityLevel.MaxLength = 0;
                colvarISecurityLevel.AutoIncrement = false;
                colvarISecurityLevel.IsNullable = true;
                colvarISecurityLevel.IsPrimaryKey = false;
                colvarISecurityLevel.IsForeignKey = false;
                colvarISecurityLevel.IsReadOnly = false;
                colvarISecurityLevel.DefaultSetting = @"";
                colvarISecurityLevel.ForeignKeyTableName = "";
                schema.Columns.Add(colvarISecurityLevel);

                var colvarSDesc = new TableSchema.TableColumn(schema);
                colvarSDesc.ColumnName = "sDesc";
                colvarSDesc.DataType = DbType.String;
                colvarSDesc.MaxLength = 255;
                colvarSDesc.AutoIncrement = false;
                colvarSDesc.IsNullable = true;
                colvarSDesc.IsPrimaryKey = false;
                colvarSDesc.IsForeignKey = false;
                colvarSDesc.IsReadOnly = false;
                colvarSDesc.DefaultSetting = @"";
                colvarSDesc.ForeignKeyTableName = "";
                schema.Columns.Add(colvarSDesc);

                BaseSchema = schema;
                //add this schema to the provider
                //so we can query it later
                DataService.Providers["ORM"].AddSchema("tbl_Users", schema);
            }
        }

        #endregion

        #region Props

        [XmlAttribute("PkSuid")]
        [Bindable(true)]
        public string PkSuid
        {
            get { return GetColumnValue<string>(Columns.PkSuid); }
            set { SetColumnValue(Columns.PkSuid, value); }
        }

        [XmlAttribute("FpSBranchID")]
        [Bindable(true)]
        public string FpSBranchID
        {
            get { return GetColumnValue<string>(Columns.FpSBranchID); }
            set { SetColumnValue(Columns.FpSBranchID, value); }
        }

        [XmlAttribute("SPwd")]
        [Bindable(true)]
        public string SPwd
        {
            get { return GetColumnValue<string>(Columns.SPwd); }
            set { SetColumnValue(Columns.SPwd, value); }
        }

        [XmlAttribute("SFullName")]
        [Bindable(true)]
        public string SFullName
        {
            get { return GetColumnValue<string>(Columns.SFullName); }
            set { SetColumnValue(Columns.SFullName, value); }
        }

        [XmlAttribute("SDepart")]
        [Bindable(true)]
        public string SDepart
        {
            get { return GetColumnValue<string>(Columns.SDepart); }
            set { SetColumnValue(Columns.SDepart, value); }
        }

        [XmlAttribute("TDateCreated")]
        [Bindable(true)]
        public DateTime? TDateCreated
        {
            get { return GetColumnValue<DateTime?>(Columns.TDateCreated); }
            set { SetColumnValue(Columns.TDateCreated, value); }
        }

        [XmlAttribute("ISecurityLevel")]
        [Bindable(true)]
        public short? ISecurityLevel
        {
            get { return GetColumnValue<short?>(Columns.ISecurityLevel); }
            set { SetColumnValue(Columns.ISecurityLevel, value); }
        }

        [XmlAttribute("SDesc")]
        [Bindable(true)]
        public string SDesc
        {
            get { return GetColumnValue<string>(Columns.SDesc); }
            set { SetColumnValue(Columns.SDesc, value); }
        }

        #endregion

        #region PrimaryKey Methods		

        protected override void SetPrimaryKey(object oValue)
        {
            base.SetPrimaryKey(oValue);

            SetPKValues();
        }


        public TblRolesForUserCollection TblRolesForUsers()
        {
            return new TblRolesForUserCollection().Where(TblRolesForUser.Columns.FpSBranchID, PkSuid).Load();
        }

        public TblRolesForUserCollection TblRolesForUsersFromTblUser()
        {
            return new TblRolesForUserCollection().Where(TblRolesForUser.Columns.SUID, PkSuid).Load();
        }

        #endregion

        #region ForeignKey Properties

        /// <summary>
        ///     Returns a TblManagementUnit ActiveRecord object related to this TblUser
        /// </summary>
        public TblManagementUnit TblManagementUnit
        {
            get { return TblManagementUnit.FetchByID(FpSBranchID); }
            set { SetColumnValue("FP_sBranchID", value.PkSBranchID); }
        }

        #endregion

        #region Many To Many Helpers

        public TblManagementUnitCollection GetTblManagementUnitCollection()
        {
            return GetTblManagementUnitCollection(PkSuid);
        }

        public static TblManagementUnitCollection GetTblManagementUnitCollection(string varPkSuid)
        {
            var cmd =
                new QueryCommand(
                    "SELECT * FROM [dbo].[tbl_ManagementUnit] INNER JOIN [tbl_RolesForUsers] ON [tbl_ManagementUnit].[PK_sBranchID] = [tbl_RolesForUsers].[FP_sBranchID] WHERE [tbl_RolesForUsers].[FP_sBranchID] = @FP_sBranchID",
                    Schema.Provider.Name);
            cmd.AddParameter("@FP_sBranchID", varPkSuid, DbType.String);
            IDataReader rdr = DataService.GetReader(cmd);
            var coll = new TblManagementUnitCollection();
            coll.LoadAndCloseReader(rdr);
            return coll;
        }

        public static void SaveTblManagementUnitMap(string varPkSuid, TblManagementUnitCollection items)
        {
            var coll = new QueryCommandCollection();
            //delete out the existing
            var cmdDel =
                new QueryCommand(
                    "DELETE FROM [tbl_RolesForUsers] WHERE [tbl_RolesForUsers].[FP_sBranchID] = @FP_sBranchID",
                    Schema.Provider.Name);
            cmdDel.AddParameter("@FP_sBranchID", varPkSuid, DbType.String);
            coll.Add(cmdDel);
            DataService.ExecuteTransaction(coll);
            foreach (TblManagementUnit item in items)
            {
                var varTblRolesForUser = new TblRolesForUser();
                varTblRolesForUser.SetColumnValue("FP_sBranchID", varPkSuid);
                varTblRolesForUser.SetColumnValue("FP_sBranchID", item.GetPrimaryKeyValue());
                varTblRolesForUser.Save();
            }
        }

        public static void SaveTblManagementUnitMap(string varPkSuid, ListItemCollection itemList)
        {
            var coll = new QueryCommandCollection();
            //delete out the existing
            var cmdDel =
                new QueryCommand(
                    "DELETE FROM [tbl_RolesForUsers] WHERE [tbl_RolesForUsers].[FP_sBranchID] = @FP_sBranchID",
                    Schema.Provider.Name);
            cmdDel.AddParameter("@FP_sBranchID", varPkSuid, DbType.String);
            coll.Add(cmdDel);
            DataService.ExecuteTransaction(coll);
            foreach (ListItem l in itemList)
            {
                if (l.Selected)
                {
                    var varTblRolesForUser = new TblRolesForUser();
                    varTblRolesForUser.SetColumnValue("FP_sBranchID", varPkSuid);
                    varTblRolesForUser.SetColumnValue("FP_sBranchID", l.Value);
                    varTblRolesForUser.Save();
                }
            }
        }

        public static void SaveTblManagementUnitMap(string varPkSuid, string[] itemList)
        {
            var coll = new QueryCommandCollection();
            //delete out the existing
            var cmdDel =
                new QueryCommand(
                    "DELETE FROM [tbl_RolesForUsers] WHERE [tbl_RolesForUsers].[FP_sBranchID] = @FP_sBranchID",
                    Schema.Provider.Name);
            cmdDel.AddParameter("@FP_sBranchID", varPkSuid, DbType.String);
            coll.Add(cmdDel);
            DataService.ExecuteTransaction(coll);
            foreach (string item in itemList)
            {
                var varTblRolesForUser = new TblRolesForUser();
                varTblRolesForUser.SetColumnValue("FP_sBranchID", varPkSuid);
                varTblRolesForUser.SetColumnValue("FP_sBranchID", item);
                varTblRolesForUser.Save();
            }
        }

        public static void DeleteTblManagementUnitMap(string varPkSuid)
        {
            var cmdDel =
                new QueryCommand(
                    "DELETE FROM [tbl_RolesForUsers] WHERE [tbl_RolesForUsers].[FP_sBranchID] = @FP_sBranchID",
                    Schema.Provider.Name);
            cmdDel.AddParameter("@FP_sBranchID", varPkSuid, DbType.String);
            DataService.ExecuteQuery(cmdDel);
        }


        public TblRoleCollection GetTblRoleCollection()
        {
            return GetTblRoleCollection(PkSuid);
        }

        public static TblRoleCollection GetTblRoleCollection(string varPkSuid)
        {
            var cmd =
                new QueryCommand(
                    "SELECT * FROM [dbo].[tbl_Roles] INNER JOIN [tbl_RolesForUsers] ON [tbl_Roles].[FP_sBranchID] = [tbl_RolesForUsers].[FP_sBranchID] WHERE [tbl_RolesForUsers].[FP_sBranchID] = @FP_sBranchID",
                    Schema.Provider.Name);
            cmd.AddParameter("@FP_sBranchID", varPkSuid, DbType.String);
            IDataReader rdr = DataService.GetReader(cmd);
            var coll = new TblRoleCollection();
            coll.LoadAndCloseReader(rdr);
            return coll;
        }

        public static void SaveTblRoleMap(string varPkSuid, TblRoleCollection items)
        {
            var coll = new QueryCommandCollection();
            //delete out the existing
            var cmdDel =
                new QueryCommand(
                    "DELETE FROM [tbl_RolesForUsers] WHERE [tbl_RolesForUsers].[FP_sBranchID] = @FP_sBranchID",
                    Schema.Provider.Name);
            cmdDel.AddParameter("@FP_sBranchID", varPkSuid, DbType.String);
            coll.Add(cmdDel);
            DataService.ExecuteTransaction(coll);
            foreach (TblRole item in items)
            {
                var varTblRolesForUser = new TblRolesForUser();
                varTblRolesForUser.SetColumnValue("FP_sBranchID", varPkSuid);
                varTblRolesForUser.SetColumnValue("FP_sBranchID", item.GetPrimaryKeyValue());
                varTblRolesForUser.Save();
            }
        }

        public static void SaveTblRoleMap(string varPkSuid, ListItemCollection itemList)
        {
            var coll = new QueryCommandCollection();
            //delete out the existing
            var cmdDel =
                new QueryCommand(
                    "DELETE FROM [tbl_RolesForUsers] WHERE [tbl_RolesForUsers].[FP_sBranchID] = @FP_sBranchID",
                    Schema.Provider.Name);
            cmdDel.AddParameter("@FP_sBranchID", varPkSuid, DbType.String);
            coll.Add(cmdDel);
            DataService.ExecuteTransaction(coll);
            foreach (ListItem l in itemList)
            {
                if (l.Selected)
                {
                    var varTblRolesForUser = new TblRolesForUser();
                    varTblRolesForUser.SetColumnValue("FP_sBranchID", varPkSuid);
                    varTblRolesForUser.SetColumnValue("FP_sBranchID", l.Value);
                    varTblRolesForUser.Save();
                }
            }
        }

        public static void SaveTblRoleMap(string varPkSuid, long[] itemList)
        {
            var coll = new QueryCommandCollection();
            //delete out the existing
            var cmdDel =
                new QueryCommand(
                    "DELETE FROM [tbl_RolesForUsers] WHERE [tbl_RolesForUsers].[FP_sBranchID] = @FP_sBranchID",
                    Schema.Provider.Name);
            cmdDel.AddParameter("@FP_sBranchID", varPkSuid, DbType.String);
            coll.Add(cmdDel);
            DataService.ExecuteTransaction(coll);
            foreach (long item in itemList)
            {
                var varTblRolesForUser = new TblRolesForUser();
                varTblRolesForUser.SetColumnValue("FP_sBranchID", varPkSuid);
                varTblRolesForUser.SetColumnValue("FP_sBranchID", item);
                varTblRolesForUser.Save();
            }
        }

        public static void DeleteTblRoleMap(string varPkSuid)
        {
            var cmdDel =
                new QueryCommand(
                    "DELETE FROM [tbl_RolesForUsers] WHERE [tbl_RolesForUsers].[FP_sBranchID] = @FP_sBranchID",
                    Schema.Provider.Name);
            cmdDel.AddParameter("@FP_sBranchID", varPkSuid, DbType.String);
            DataService.ExecuteQuery(cmdDel);
        }

        #endregion

        #region ObjectDataSource support

        /// <summary>
        ///     Inserts a record, can be used with the Object Data Source
        /// </summary>
        public static void Insert(string varPkSuid, string varFpSBranchID, string varSPwd, string varSFullName,
            string varSDepart, DateTime? varTDateCreated, short? varISecurityLevel, string varSDesc)
        {
            var item = new TblUser();

            item.PkSuid = varPkSuid;

            item.FpSBranchID = varFpSBranchID;

            item.SPwd = varSPwd;

            item.SFullName = varSFullName;

            item.SDepart = varSDepart;

            item.TDateCreated = varTDateCreated;

            item.ISecurityLevel = varISecurityLevel;

            item.SDesc = varSDesc;


            if (HttpContext.Current != null)
                item.Save(HttpContext.Current.User.Identity.Name);
            else
                item.Save(Thread.CurrentPrincipal.Identity.Name);
        }

        /// <summary>
        ///     Updates a record, can be used with the Object Data Source
        /// </summary>
        public static void Update(string varPkSuid, string varFpSBranchID, string varSPwd, string varSFullName,
            string varSDepart, DateTime? varTDateCreated, short? varISecurityLevel, string varSDesc)
        {
            var item = new TblUser();

            item.PkSuid = varPkSuid;

            item.FpSBranchID = varFpSBranchID;

            item.SPwd = varSPwd;

            item.SFullName = varSFullName;

            item.SDepart = varSDepart;

            item.TDateCreated = varTDateCreated;

            item.ISecurityLevel = varISecurityLevel;

            item.SDesc = varSDesc;

            item.IsNew = false;
            if (HttpContext.Current != null)
                item.Save(HttpContext.Current.User.Identity.Name);
            else
                item.Save(Thread.CurrentPrincipal.Identity.Name);
        }

        #endregion

        #region Typed Columns

        public static TableSchema.TableColumn PkSuidColumn
        {
            get { return Schema.Columns[0]; }
        }


        public static TableSchema.TableColumn FpSBranchIDColumn
        {
            get { return Schema.Columns[1]; }
        }


        public static TableSchema.TableColumn SPwdColumn
        {
            get { return Schema.Columns[2]; }
        }


        public static TableSchema.TableColumn SFullNameColumn
        {
            get { return Schema.Columns[3]; }
        }


        public static TableSchema.TableColumn SDepartColumn
        {
            get { return Schema.Columns[4]; }
        }


        public static TableSchema.TableColumn TDateCreatedColumn
        {
            get { return Schema.Columns[5]; }
        }


        public static TableSchema.TableColumn ISecurityLevelColumn
        {
            get { return Schema.Columns[6]; }
        }


        public static TableSchema.TableColumn SDescColumn
        {
            get { return Schema.Columns[7]; }
        }

        #endregion

        #region Columns Struct

        public struct Columns
        {
            public static string PkSuid = @"PK_sUID";
            public static string FpSBranchID = @"FP_sBranchID";
            public static string SPwd = @"sPwd";
            public static string SFullName = @"sFullName";
            public static string SDepart = @"sDepart";
            public static string TDateCreated = @"tDateCreated";
            public static string ISecurityLevel = @"iSecurityLevel";
            public static string SDesc = @"sDesc";
        }

        #endregion

        #region Update PK Collections

        public void SetPKValues()
        {
        }

        #endregion

        #region Deep Save

        public void DeepSave()
        {
            Save();
        }

        #endregion
    }
}