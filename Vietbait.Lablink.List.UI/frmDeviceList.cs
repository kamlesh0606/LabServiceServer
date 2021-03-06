using System;
using System.Data;
using System.Threading;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using VietBaIT.CommonLibrary;
using Vietbait.Lablink.List.Business;
using Vietbait.Lablink.Model;
using Action = Vietbait.Lablink.Utilities.UserAction;


namespace Vietbait.Lablink.List.UI
{
    public partial class frmDeviceList : Office2007Form
    {
        #region Attibutes

        private const string StrCancel = "Cancel";
        private const string StrExit = "Exit";
        private Action _myAction;
        private DataTable _tblDeviceTable = new DataTable();
        private DataTable _tblListPort = new DataTable();
        private DataTable _tblManufacture = new DataTable();
        private DataTable _tblTestTypeList = new DataTable();

        #endregion

        #region Contructor

        public frmDeviceList()
        {
            InitializeComponent();
        }

        #endregion

        #region Privated Method

        private void LoadPortList()
        {
            try
            {
                if (rdR232.Checked)
                {
                    _tblListPort = PortListBusiness.GetAllRS232();

                    cboPort.DataSource = _tblListPort.DefaultView;
                    cboPort.ValueMember = "ID";
                    cboPort.DisplayMember = "Name";
                }
                if (rdTCPIP.Checked)
                {
                    _tblListPort = PortListBusiness.GetAllTcpip();

                    cboPort.DataSource = _tblListPort.DefaultView;
                    cboPort.ValueMember = "ID";
                    cboPort.DisplayMember = "IPAddress";
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Hàm dùng để set thuộc tính cho các control
        /// </summary>
        /// <param name="pMyAction"></param>
        private void SetControlStatus(Action pMyAction)
        {
            switch (pMyAction)
            {
                case Action.Insert:
                    btnAdd.Enabled = false;
                    btnDelete.Enabled = false;
                    btnEdit.Enabled = false;
                    btnSave.Enabled = true;
                    txtDeviceID.Enabled = false;
                    txtDeviceID.Text = string.Empty;
                    txtDeviceName.Focus();
                    txtDeviceName.SelectAll();
                    grpInfor.Enabled = true;
                    cboDeviceClass.Enabled = true;
                    cboDeviceNameSpace.Enabled = true;
                    btnExit.Text = StrCancel;
                    txtComputerName.Enabled = true;
                    txtConnectorId.Enabled = true;
                    break;
                case Action.Update:
                    btnAdd.Enabled = false;
                    btnDelete.Enabled = false;
                    btnEdit.Enabled = false;
                    btnSave.Enabled = true;
                    txtDeviceName.Focus();
                    txtDeviceName.SelectAll();
                    grpInfor.Enabled = true;
                    cboDeviceClass.Enabled = true;
                    cboDeviceNameSpace.Enabled = true;
                    btnExit.Text = StrCancel;
                    txtComputerName.Enabled = true;
                    txtConnectorId.Enabled = true;
                    txtDeviceID.Enabled = false;
                    break;
                case Action.Delete:
                    break;
                case Action.Normal:
                    btnAdd.Enabled = true;
                    btnEdit.Enabled = true;
                    btnDelete.Enabled = true;
                    btnSave.Enabled = true;
                    btnExit.Enabled = true;
                    btnExit.Text = StrExit;
                    txtDeviceLib.Enabled = false;
                    txtComputerName.Enabled = false;
                    txtConnectorId.Enabled = false;
                    cboDeviceClass.Enabled = false;
                    cboDeviceNameSpace.Enabled = false;
                    grpInfor.Enabled = false;
                    txtDeviceID.Enabled = false;
                    break;
            }
        }

        /// <summary>
        /// Hàm thực hiện lệnh 
        /// </summary>
        /// <param name="pMyAction">Action pMyAction</param>
        private void PerformAction(Action pMyAction)
        {
            try
            {
                //CreateDeviceList();

                switch (pMyAction)
                {
                    case Action.Insert:
                        DevicesListBusiness.InsertDevice(CreateDeviceList());

                        break;
                    case Action.Update:
                        DevicesListBusiness.UpdateDevice(CreateDeviceList());

                        break;
                    case Action.Delete:
                        DevicesListBusiness.DeleteDevice(CreateDeviceList());
                        break;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private bool InValidata()
        {
            if (string.IsNullOrEmpty(txtDeviceName.Text))
            {
                Utility.ShowMsg("DeviceName don't empty !", "Alert");
                txtDeviceName.Focus();
                return false;
            }
            return true;
        }

        private DDeviceList CreateDeviceList()
        {
            var item = new DDeviceList();
            try
            {
                item = new DDeviceList(Convert.ToInt32(txtDeviceID.Text.Trim()));
            }
            catch (Exception)
            {
                item = new DDeviceList();
            }
            item.DeviceName = txtDeviceName.Text.Trim();
            item.ComputerName = txtComputerName.Text.Trim();
            item.ManufactureId = Convert.ToInt16(cboManufacturer.SelectedValue.ToString());
            item.TestTypeId = Convert.ToInt16(cboTest.SelectedValue.ToString());
            item.Description = txtDesc.Text.Trim();
            item.DeviceClass = cboDeviceClass.Text;
            item.DeviceNameSpace = cboDeviceNameSpace.Text;
            item.ConnectorID = Utility.ByteDbnull(txtConnectorId.Text.Trim());
            item.Valid = rdUsed.Checked ? true : false;
            item.Protocol = rdOne.Checked ? true : false;
            if (rdR232.Checked)
            {
                item.DeviceConnectorType = 1;
            }
            else if (rdTCPIP.Checked)
            {
                item.DeviceConnectorType = 0;
            }
            else
            {
                item.DeviceConnectorType = null;
            }
            return item;
        }

        /// <summary>
        /// Hàm lấy toàn bộ devices từ database đổ vào datagridview
        /// </summary>
        private void LoadAllDevices()
        {
            try
            {
                // grdDevices.SelectionChanged -= grdDevices_SelectionChanged;
                _tblDeviceTable = DevicesListBusiness.GetAllDevicesList();
                // grdDevices.DataSource = _tblDeviceTable.DefaultView;
                grdDevices.DataSource = _tblDeviceTable;
                //grdDevices.SelectionChanged += grdDevices_SelectionChanged;
                grdDevices_SelectionChanged(grdDevices, new EventArgs());
            }
            catch (Exception  ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Hàm lấy toàn bộ devices từ database đổ vào dropdownlist Manufacture
        /// </summary>
        private void LoadAllManufacture()
        {
            _tblManufacture = ManufactureBusiness.GetAllManufacture();
            cboManufacturer.DataSource = _tblManufacture.DefaultView;
            cboManufacturer.ValueMember = "ID";
            cboManufacturer.DisplayMember = "sName";
        }

        /// <summary>
        /// Hàm lấy toàn bộ danh sách T_Test_Type_List
        /// </summary>
        private void LoadAllTestTypeList()
        {
            _tblTestTypeList = TestTypeListBusiness.GetAllTestTypeList();
            cboTest.DataSource = _tblTestTypeList.DefaultView;
            cboTest.ValueMember = "TestType_ID";
            cboTest.DisplayMember = "TestType_Name";
        }

        private void SetControlPropertyThreadSafe(string propertyValue)
        {
            if (txtDeviceLib.InvokeRequired)
            {
                //control.Invoke(new SetControlPropertyThreadSafeDelegate(SetControlPropertyThreadSafe),
                //               new[] {control, propertyName, propertyValue});
                txtDeviceLib.Invoke(new SetControlPropertyThreadSafeDelegate(SetControlPropertyThreadSafe),
                                    propertyValue);
            }
            else
            {
                txtDeviceLib.Text = propertyValue;
            }

            ////if (textBox1.InvokeRequired)
            ////{
            ////    //control.Invoke(new SetControlPropertyThreadSafeDelegate(SetControlPropertyThreadSafe),
            ////    //               new[] {control, propertyName, propertyValue});
            ////    textBox1.Invoke(new SetControlPropertyThreadSafeDelegate(SetControlPropertyThreadSafe),
            ////                         propertyValue);

            ////}
            ////else
            ////{
            ////    textBox1.Text = propertyValue;
            ////}
        }

        private void CallOpenFileDialog()
        {
            var ofn = new OpenFileDialog();
            ofn.Filter = @"Dll Files (*.dll)|*.dll|All Files (*.*)|*.*";
            ofn.Title = @"Open Dll File";
            //ofn.ShowDialog();
            if (ofn.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    //SetControlProperty(txtDeviceName, "Text", ofn.FileName);
                    SetControlPropertyThreadSafe(ofn.FileNames[0]);
                    Thread.CurrentThread.Join();
                    //txtDeviceName.Text = ofn.FileName;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(@"Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }
        }

        private delegate void SetControlPropertyThreadSafeDelegate(string propertyValue);

        #endregion

        #region Event

        private void frmDeviceList_Load(object sender, EventArgs e)
        {
            LoadAllDevices();
            LoadAllManufacture();
            LoadAllTestTypeList();
            LoadPortList();
            _myAction = Action.Normal;
            SetControlStatus(_myAction);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            _myAction = Action.Insert;
            SetControlStatus(_myAction);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            _myAction = Action.Update;
            SetControlStatus(_myAction);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            _myAction = Action.Delete;
            SetControlStatus(_myAction);
            DialogResult result = MessageBox.Show("Do you sure delete this record?", "Warning",
                                                  MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (result == DialogResult.OK)
            {
                PerformAction(_myAction);
                frmDeviceList_Load(this, new EventArgs());
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SetControlStatus(_myAction);
            if (!InValidata()) return;
            PerformAction(_myAction);
            frmDeviceList_Load(this, new EventArgs());
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (_myAction == Action.Normal)
            {
                Dispose();
            }
            _myAction = Action.Normal;
            SetControlStatus(_myAction);
        }

        private void btnDeviceLibrary_Click(object sender, EventArgs e)
        {
            var thread = new Thread(CallOpenFileDialog);
            thread.TrySetApartmentState(ApartmentState.STA);
            thread.Start();
            while (!thread.IsAlive)
                Thread.Sleep(1);
            thread .Abort();

            MessageBox.Show("Finish");
        }

        private void grdDevices_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (grdDevices.CurrentRow != null)
                {
                    DataGridViewRow dr = grdDevices.CurrentRow;
                    txtDeviceName.Text = dr.Cells["clDevice_Name"].Value.ToString();
                    txtDeviceLib.Text = dr.Cells["clDeviceLibrary"].Value.ToString();
                    txtDesc.Text = dr.Cells["clDescription"].Value.ToString();
                    txtComputerName.Text = dr.Cells["clComputerName"].Value.ToString();
                    txtDeviceID.Text = dr.Cells["clDevice_ID"].Value.ToString();
                    txtConnectorId.Text = dr.Cells["clConnectorID"].Value.ToString();
                    cboTest.Text = dr.Cells["clTestName"].Value.ToString();
                    cboManufacturer.Text = dr.Cells["clManufacture_Name"].Value.ToString();


                    /*
                     Lấy về trạng thái của Cell Protocol. Nếu True thì rdOne tự động checked
                     * còn không thì rdTwo tự động được checked
                     */
                    bool protocol = Boolean.Parse(dr.Cells["clProtocol"].Value.ToString());
                    if (protocol)
                    {
                        rdOne.Checked = true;
                    }
                    else
                    {
                        rdTwo.Checked = true;
                    }


                    /*
                     Lấy về trạng thái của Cell Use xem Device đó có được sử dụng hay không.
                 * Nếu True thì rdUsed tự động checked
                     * còn không thì rdUnused tự động được checked
                     */
                    bool use = Boolean.Parse(dr.Cells["clValid"].Value.ToString());
                    if (use)
                    {
                        rdUsed.Checked = true;
                    }
                    else
                    {
                        rdUnused.Checked = true;
                    }

                    string temp = dr.Cells["clDeviceConnectorType"].Value.ToString();
                    if (temp == "0")
                    {
                        rdR232.Checked = true;
                        LoadPortList();
                    }
                    if (temp == "1")
                    {
                        rdTCPIP.Checked = true;
                        LoadPortList();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion
    }
}