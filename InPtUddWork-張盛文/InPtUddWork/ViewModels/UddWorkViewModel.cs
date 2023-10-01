using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using InPtUddWork.Models;

namespace InPtUddWork.ViewModels
{
    public class WardList
    {
        public string Ward { get; set; }
        public string CycleTime { get; set; }
        public List<Bed> bed = new List<Bed>();

        public WardList()
        {
        }
        public WardList(string ward, string cycleTime, List<Bed> bed)
        {
            this.Ward = ward;
            this.CycleTime = cycleTime;
            this.bed = bed;
        }
    }

    public class UddDataAndDrug
    {
        public UddData uddData { get; set; }
        public DrugSet drugSet { get; set; }

        public UddDataAndDrug()
        {
        }
        public UddDataAndDrug(UddData uddData, DrugSet drugSet)
        {
            this.uddData = uddData;
            this.drugSet = drugSet;
        }
    }
}