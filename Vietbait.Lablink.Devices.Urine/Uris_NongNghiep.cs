﻿using System;
using Vietbait.Lablink.TestResult;
using Vietbait.Lablink.Utilities;

namespace Vietbait.Lablink.Devices.Urine
{
    internal class Uri_NongNghiep : Rs232Base
    {
        public override void ProcessRawData()
        {
            try
            {
                Log.Trace("Begin Process Data");
                Log.Trace(DeviceHelper.CRLF + StringData);
                string[] allPatients = SeparatorData(StringData);

                foreach (string patient in allPatients)
                {
                    try
                    {
                        string[] tempResult = patient.Split(DeviceHelper.CR);
                        string[] tempDate = tempResult[1].Split()[0].Split('/');
                        TestResult.TestDate = string.Format("{0}/{1}/{2}", tempDate[2], tempDate[1], tempDate[0]);

                        try
                        {
                            //string tempbarcode = tempResult[3].Split(':')[1].Trim();
                            string tempbarcode = tempResult[3].Split(':')[1].Trim().Replace(".", "");
                            TestResult.Barcode = tempbarcode == "" ? "0000" : tempbarcode;
                        }
                        catch (Exception)
                        {
                            TestResult.Barcode = "0000";
                        }
                        Log.Debug(string.Format("Testdate:{0}, Barcode:{1}", TestResult.TestDate, TestResult.Barcode));

                        for (int i = 4; i < 15; i++)
                        {
                            try
                            {
                                string[] tempresultarr = DeviceHelper.DeleteAllBlankLine(tempResult[i], "");
                                if (tempresultarr.Length > 1)
                                {
                                    string testName = tempresultarr[0];
                                    string testValue = tempresultarr[1];
                                    TestResult.Add(new ResultItem(testName, testValue));
                                    Log.Debug("Add new Result: TestName = {0}, TestValue = {1}", testName, testValue);
                                }
                            }
                            catch (Exception)
                            {
                            }
                        }


                        Log.Debug("Begin Import Result");
                        ImportResults();
                        Log.Debug("Import Result Success");
                    }
                    catch (Exception)
                    {
                    }
                }
            }
            catch (Exception)
            {
                ClearData();
                throw;
            }
            finally
            {
                ClearData();
            }
        }

        private string[] SeparatorData(string stringData)
        {
            try
            {
                //Ngắt chuỗi theo ký tự CR
                string[] arrStringData = DeviceHelper.DeleteAllBlankLine(stringData, DeviceHelper.CR);

                //Biến để lưu tất cả các chuỗi kết quả.
                //Mỗi phần tử của chuỗi là một kết quả của bệnh nhân gồm các record P,O,R,C.....
                var allResult = new string[] {};

                //Biến lưu Index
                int id = 0;

                foreach (string line in arrStringData)
                {
                    if (line.StartsWith("URINALYSIS"))
                    {
                        id++;
                        Array.Resize(ref allResult, id);
                    }
                    allResult[id - 1] = allResult[id - 1] + (line[0] == '*' ? line.Substring(1) : line) +
                                        DeviceHelper.CR;
                }

                return allResult;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}