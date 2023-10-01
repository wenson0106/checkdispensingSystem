using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using InPtUddWork.Models;
using InPtUddWork.ViewModels;

namespace InPtUddWork.Controllers
{
    public class InPtUddWorkTemplateController : Controller
    {
        // GET: InPtUddWork
        InPtUddWorkData.Ward ward = new InPtUddWorkData.Ward();
        InPtUddWorkData.UddData uddData = new InPtUddWorkData.UddData();
        InPtUddWorkData.Bed bed = new InPtUddWorkData.Bed();
        InPtUddWorkData.DrugSet drugSet = new InPtUddWorkData.DrugSet();

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

        /*public DrugSet GetDrugData()
        {
            string result = drugSet.GetData();
            DrugSet drugList = new JavaScriptSerializer().Deserialize<DrugSet>(result);
            return drugList;
        }*/

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
            return RedirectToAction("SelectPatient", "InPtUddWorkTemplate", new { wardId = wardId, cycletime = cycletime });
        }
        public ActionResult CheckMed(string BedId)
        {
            Models.DrugSet drugs = GetDrugData();
            List<Models.UddData> data = GetUddData();
            //List<Models.Bed> bed = GetBedData();
            string date = DateTime.Now.ToString("u");
            //ViewData["drugList"] = drugs;
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

            return RedirectToAction("SelectNursingStation", "InPtUddWorkTemplate");
        }

        [HttpPost]
        public ActionResult SelectPatient(string bedid)
        {
            return RedirectToAction("CheckMed", "InPtUddWorkTemplate", new { BedId = bedid });
        }
    }
}