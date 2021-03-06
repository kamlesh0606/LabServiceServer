﻿using System;
using System.Globalization;
using Vietbait.Lablink.TestResult;
using Vietbait.Lablink.Utilities;

namespace Vietbait.Lablink.Devices.Biochemistry
{
    internal class Hitachi911 : Rs232Base
    {
        public override void ProcessRawData()
        {
            try
            {
                //Nếu ký tự kết thúc bằng CR thì tiến hành xử lý
                if ((StringData.EndsWith(DeviceHelper.CR.ToString(CultureInfo.InvariantCulture))) ||
                    (StringData.EndsWith(DeviceHelper.CRLF)))
                {
                    Log.Trace("Begin Process Data");
                    Log.Trace(DeviceHelper.CRLF + StringData);
                    SendStringData(DeviceHelper.ACK.ToString(CultureInfo.InvariantCulture));
                    string[] allPatients = DeviceHelper.DeleteAllBlankLine(StringData, DeviceHelper.CR);
                    Log.Trace("Result has {0} Patients", allPatients.Length);

                    //Duyệt theo từng dòng 
                    foreach (string patient in allPatients)
                    {
                        string tempPatient = patient;
                        //Nếu đúng với các ký tự bắt đầu thì xử lý:
                        if (Validdata(patient))
                        {
                            TestResult.TestDate = DateTime.Now.ToString("dd/MM/yyyy");
                            TestResult.Barcode = tempPatient.Substring(10, 16).Trim();
                            tempPatient = tempPatient.Substring(40);
                            while (tempPatient.Length > 9)
                            {
                                string result = tempPatient.Substring(0, 9);
                                string testName = result.Substring(0, 2).Trim();
                                string testValue = result.Substring(2, 7).Trim();

                                //Xử lý các ký tự thừa trong kết quả

                                //Loại bỏ dấu "$"
                                testValue = testValue.Replace("$", "").Replace("!", "");

                                //Loại bỏ các chữ cái in hoa và in thường trong chuỗi kết quả
                                for (byte i = 65; i <= 90; i++)
                                {
                                    testValue =
                                        testValue.Replace(Convert.ToChar(i).ToString(CultureInfo.InvariantCulture), "").
                                            Replace(Convert.ToChar(i + 32).ToString(CultureInfo.InvariantCulture), "");
                                }

                                //Thêm kết quả mới
                                TestResult.Add(new ResultItem(testName, testValue));

                                //Cắt bỏ các dữ liệu vừa được xử lý
                                tempPatient = tempPatient.Substring(9);

                                //////////////Xử lý các thông số tính toán
                                ////////////double iHdlc = -1, iTrig = -1, iChol = -1, iAlb = -1, iProT = -1, iBilt = -1, iBild = -1;

                                ////////////foreach (ResultItem item in TestResult.Items)
                                ////////////{
                                ////////////    //BIL-Toàn phần
                                ////////////    if (item.TestName.Equals("10")) iBilt = TryToConvertToDouble(item.TestValue);

                                ////////////    //BIL-Trực tiếp
                                ////////////    if (item.TestName.Equals("11")) iBild = TryToConvertToDouble(item.TestValue);

                                ////////////    //Protein-T                                    
                                ////////////    if (item.TestName.Equals("12")) iProT = TryToConvertToDouble(item.TestValue);

                                ////////////    //ALB                                   
                                ////////////    if (item.TestName.Equals("15")) iAlb = TryToConvertToDouble(item.TestValue);

                                ////////////    //CHOL
                                ////////////    if (item.TestName.Equals("17")) iChol = TryToConvertToDouble(item.TestValue);

                                ////////////    //Trig
                                ////////////    if (item.TestName.Equals("16")) iTrig = TryToConvertToDouble(item.TestValue);

                                ////////////    //HDLC
                                ////////////    if (item.TestName.Equals("18")) iHdlc = TryToConvertToDouble(item.TestValue);
                                ////////////}

                                //////////////Tính toán

                                //////////////Bil-Gián tiếp:
                                ////////////if ((iBild > 0) && (iBilt > 0))
                                ////////////{
                                ////////////    testName = "47";
                                ////////////    testValue = (iBilt - iBild).ToString();
                                ////////////    TestResult.Add(new ResultItem(testName, testValue));
                                ////////////}

                                //////////////Globumin,Tỷ số A/G
                                ////////////if ((iProT > 0) && (iAlb > 0))
                                ////////////{
                                ////////////    //Globumin
                                ////////////    testName = "51";
                                ////////////    testValue = (iProT - iAlb).ToString();
                                ////////////    TestResult.Add(new ResultItem(testName, testValue));

                                ////////////    //Tỷ số A/G
                                ////////////    testName = "49";
                                ////////////    testValue = (iAlb/(iProT - iAlb)).ToString();
                                ////////////    TestResult.Add(new ResultItem(testName, testValue));
                                ////////////}

                                //////////////LDLC:
                                ////////////if ((iChol > 0) && (iHdlc > 0) && (iTrig > 0))
                                ////////////{
                                ////////////    testName = "50";
                                ////////////    testValue = (iChol - (iTrig/2.2 + iHdlc)).ToString();
                                ////////////    TestResult.Add(new ResultItem(testName, testValue));
                                ////////////}
                            }
                            ImportResults();
                            Log.Debug("Import Result Success For barocde:{0}", TestResult.Barcode);
                        }
                    }
                    ClearData();
                }
            }
            catch (Exception ex)
            {
                ClearData();
                throw ex;
            }
        }

        private bool Validdata(string record)
        {
            try
            {
                if (record.StartsWith(DeviceHelper.STX.ToString(CultureInfo.InvariantCulture) + ":s")) return true;
                if (record.StartsWith(DeviceHelper.STX.ToString(CultureInfo.InvariantCulture) + ":S")) return true;
                if (record.StartsWith(DeviceHelper.STX.ToString(CultureInfo.InvariantCulture) + ":g")) return true;
                if (record.StartsWith(DeviceHelper.STX.ToString(CultureInfo.InvariantCulture) + ":G")) return true;
                return false;
            }
            catch (Exception ex)
            {
                Log.Error("Error when check string data Exception:" + ex);
                return false;
            }
        }

        private double TryToConvertToDouble(string value)
        {
            try
            {
                return Convert.ToDouble(value);
            }
            catch (Exception)
            {
                return -1;
            }
        }
    }
}