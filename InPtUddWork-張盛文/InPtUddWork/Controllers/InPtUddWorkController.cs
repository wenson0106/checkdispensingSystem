using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using InPtUddWork.Models;
using InPtUddWork.ViewModels;
using System.Web.Script.Serialization;

namespace InPtUddWork.Controllers
{
    public class InPtUddWorkController : Controller
    {
        // GET: InPtUddWork
        InPtUddWorkData.Ward ward = new InPtUddWorkData.Ward();
        InPtUddWorkData.UddData uddData = new InPtUddWorkData.UddData();
        InPtUddWorkData.Bed bed = new InPtUddWorkData.Bed();
        InPtUddWorkData.DrugSet drugSet = new InPtUddWorkData.DrugSet();
        InPtUddWorkData.PRNOrder pRNOrder = new InPtUddWorkData.PRNOrder();
        InPtUddWorkData.LabReport labReport = new InPtUddWorkData.LabReport();
        public List<Models.Ward> GetWardData()
        {
            string result = ward.GetData();
            List<Models.Ward> wardList = new JavaScriptSerializer().Deserialize<List<Models.Ward>>(result);
            return wardList;
        }

        public List<Models.UddData> GetUddData()
        {
            string result = uddData.GetData();
            List<Models.UddData> uddDataList = new JavaScriptSerializer().Deserialize<List<Models.UddData>>(result);
            return uddDataList;
        }

        public List<Models.Bed> GetBedData()
        {
            string result = bed.GetData();
            List<Models.Bed> bedList = new JavaScriptSerializer().Deserialize<List<Models.Bed>>(result);
            return bedList;
        }
        public Models.DrugSet GetDrugData()
        {
            string result = drugSet.GetData();
            Models.DrugSet drugList = new JavaScriptSerializer().Deserialize<Models.DrugSet>(result);
            return drugList;
        }
        public List<Models.PRNOrder> GetPRNData()
        {
            string result = pRNOrder.GetData();
            List<Models.PRNOrder> PRN = new JavaScriptSerializer().Deserialize<List<Models.PRNOrder>>(result);
            return PRN;
        }
        public Models.LabReport GetLabData()
        {
            string result = labReport.GetData();
            Models.LabReport lab = new JavaScriptSerializer().Deserialize<Models.LabReport>(result);
            return lab;
        }

        public ActionResult SelectPatient(string wardId, string cycleTime)
        {
            WardList wardList = new WardList("R10", "2022/07/07 15:05:10", GetBedData());
            return View("SelectPatient", wardList);
        }
        public ActionResult SelectNursingStation()
        {
            List<Models.Ward> ward = GetWardData();

            return View(ward);
        }

        [HttpPost]
        public ActionResult SelectNursingStation(string wardId)
        {
            string cycletime = "";
            return RedirectToAction("SelectPatient", "InPtUddWork", new { wardId = wardId, cycletime = cycletime });
        }
        public ActionResult CheckMed(string BedId)
        {
            Models.DrugSet drugs = GetDrugData();
            List<Models.PRNOrder> PRN = GetPRNData();
            Models.LabReport Lab = GetLabData();
            List<Models.UddData> data = GetUddData();
            //List<Models.Bed> bed = GetBedData();
            string date = DateTime.Now.ToString("u");
            ViewBag.PRN = PRN;
            ViewBag.Lab = Lab;
            ViewBag.Date = date;
            ViewBag.AllPatientsNum = data.Count();
            var i = 0;
            ViewBag.lastPId = "";
            ViewBag.nextPId = "";
            bool reDirect = false;
            Models.UddData udd = new Models.UddData();
            UddDataAndDrug uddDataAndDrug = new UddDataAndDrug();
            foreach (Models.UddData p in data)
            {
                i++;
                if (p.headler.Roombed == BedId)
                {
                    ViewBag.PatientNum = i;
                    udd = p;
                    uddDataAndDrug = new UddDataAndDrug(udd, drugs);
                    reDirect = true;
                }
                else
                {
                    if (reDirect == true)
                    {
                        ViewBag.nextPId = p.headler.Roombed;
                        return View(uddDataAndDrug);
                    }
                    ViewBag.lastPId = p.headler.Roombed;
                }
            }
            if (reDirect == true)
            {
                return View(uddDataAndDrug);
            }

            return RedirectToAction("SelectNursingStation", "InPtUddWork");
        }

        [HttpPost]
        public ActionResult SelectPatient(string bedid)
        {
            return RedirectToAction("CheckMed", "InPtUddWork", new { BedId = bedid });
        }


        [HttpPost]
        public ActionResult CheckMed(string roomBed, string[] _checked)
        {
            List<Models.UddData> data = GetUddData();
            string date = DateTime.Now.ToString("u");
            ViewBag.Date = date;
            ViewBag.AllPatientsNum = data.Count();
            var i = 0;
            ViewBag.lastPId = "";
            ViewBag.nextPId = "";
            bool reDirect = false;
            Models.UddData udd = new Models.UddData();
            foreach (Models.UddData p in data)
            {
                i++;
                if (p.headler.Roombed == roomBed)
                {
                    ViewBag.PatientNum = i;
                    udd = p;
                    reDirect = true;
                    int k = 0;
                    foreach (var item in p.detail)
                    {
                        item.SetChecked(_checked[k]);
                        //string c = item.IsChecked;
                        k++;
                    }

                }
                else
                {
                    if (reDirect == true)
                    {
                        ViewBag.nextPId = p.headler.Roombed;
                        return View("CheckMed", udd);
                    }
                    ViewBag.lastPId = p.headler.Roombed;
                }

            }
            if (reDirect == true)
            {
                return View("CheckMed", udd);
            }
            return RedirectToAction("CheckMed", "InPtUddWork", new { BedId = roomBed });
        }




        /*

        public ActionResult SelectPatient()
        {
            List<Models.Bed> bed = GetBedData();
            return View(bed);
        }

        


        [HttpGet]
        public ActionResult SelectPatient(string bedid)
        {
            List<Models.UddData> data = GetUddData();
            List<Models.Bed> bed = GetBedData();
            string date = DateTime.Now.ToString("u");
            ViewBag.Date = date;
            ViewBag.AllPatientsNum = data.Count();
            var i = 0;
            ViewBag.lastPId="";
            ViewBag.nextPId = "";
            bool reDirect = false;
            Models.UddData udd = new Models.UddData();
            foreach (Models.UddData p in data)
            {
                i++;
                if (p.headler.Roombed == bedid)
                {
                    ViewBag.PatientNum = i;
                    udd = p;
                    reDirect = true;
                }
                else
                {
                    if (reDirect == true)
                    {
                        ViewBag.nextPId = p.headler.Roombed;
                        return View("CheckMed", udd);
                    }
                    ViewBag.lastPId = p.headler.Roombed;
                }
            }
            if (reDirect == true)
            {
                return View("CheckMed", udd);
            }
            return View(bed);
        }
        public ActionResult CheckMed()
        {
            List<Models.Bed> bed = GetBedData();
            return View("SelectPatient", bed);
        }
        
        [HttpPost]
        public ActionResult SelectPatient(string roomBed, string[] _checked)
        {
            List<Models.UddData> data = GetUddData();
            string date = DateTime.Now.ToString("u");
            ViewBag.Date = date;
            ViewBag.AllPatientsNum = data.Count();
            var i = 0;
            ViewBag.lastPId = "";
            ViewBag.nextPId = "";
            bool reDirect = false;
            Models.UddData udd = new Models.UddData();
            foreach (Models.UddData p in data)
            {
                i++;
                if (p.headler.Roombed == roomBed)
                {
                    ViewBag.PatientNum = i;
                    udd = p;
                    reDirect = true;
                    foreach(var item in p.detail)
                    {
                        item.IsChecked = _checked[i];
                    }
                }
                else
                {
                    if (reDirect == true)
                    {
                        ViewBag.nextPId = p.headler.Roombed;
                        return View("CheckMed", udd);
                    }
                    ViewBag.lastPId = p.headler.Roombed;
                }

            }
            if (reDirect == true)
            {
                return View("CheckMed", udd);
            }
            return View("SelectPatient");
        }
        */
    }
}