using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InPtUddWork.Models
{
    public class Ward
    {
        public string building { get; set; }
        public string ward { get; set; }

        public Ward() { }

        public Ward(string building, string ward)
        {
            this.building = building;
            this.ward = ward;
        }
    }
    public class Bed
    {
        public string Barcode { get; set; } //BarCode
        public string QRCode { get; set; } //QRCode
        public string RoomBed { get; set; } //床號
        public int ChartNo { get; set; } //病歷號
        public string PtName { get; set; } //患者姓名
        public string Sex { get; set; } //性別
        public string CtrlDrug { get; set; } //管制藥
        public string HighAlert { get; set; } //高警訊藥品
        public string ExpandDate { get; set; } //展開日期
        public string IsOut { get; set; } //出院
        public string IsDC { get; set; } //DC
        public string IsExpandRepair { get; set; } //補展開
        public string IsFreezer { get; set; } //冰
        public string IsExpensive { get; set; } //高貴藥
        public string ChangeBed { get; set; } //轉床
        public string ChangeRoomBed { get; set; } //轉床號
        public string EndTime { get; set; } //停用日期
        public string NowVisitNo { get; set; } //床號當下就醫號
        public Bed() { }
        public Bed(string barCode, string qrCode, string roomBed, int chartNo, string ptName, string sex, string ctrlDrug, string highAlert, string expandDate, string isOut, string isDC, string isExpandRepair, string isFreezer, string isExpensive, string changeBed, string changeRoomBed, string endTime, string nowVisitNo)
        {
            this.Barcode = barCode;
            this.QRCode = qrCode;
            this.RoomBed = roomBed;
            this.ChartNo = chartNo;
            this.PtName = ptName;
            this.Sex = sex;
            this.CtrlDrug = ctrlDrug;
            this.HighAlert = highAlert;
            this.ExpandDate = expandDate;
            this.IsOut = isOut;
            this.IsDC = isDC;
            this.IsExpandRepair = isExpandRepair;
            this.IsFreezer = isFreezer;
            this.IsExpensive = isExpensive;
            this.ChangeBed = changeBed;
            this.ChangeRoomBed = changeRoomBed;
            this.EndTime = endTime;
            this.NowVisitNo = nowVisitNo;
        }
    }
    public class DrugSet
    {
        public string Manufactory { get; set; } //製造商, 廠商名稱
        public string TradeName { get; set; } //商品名, 藥品英文名稱
        public string ChineseName { get; set; } //中文名, 藥品中文名稱
        public string GenericName { get; set; } //學名及劑量, 主成份及含量
        public string LicenseNumber { get; set; }//衛生署許可證號
        public string ItemCode { get; set; } //院內批價碼, 院內代碼
        public int Form { get; set; } //劑型分類
        public string GenericCode { get; set; } //學名碼
        public string IndicationsA1 { get; set; }//適應症(院外), 適應症(藥袋列印)
        public string IndicationsA2 { get; set; } //適應症(院內), 適應症
        public string AdultDosing { get; set; } //用法與劑量, 用法用量
        public string AdverseEffectsA1 { get; set; } //副作用(院外), 副作用(藥袋列印)
        public string AdverseEffectsA2 { get; set; } //副作用(院內), 副作用
        public string Contraindication { get; set; } //禁忌, 禁忌
        public string Precautions { get; set; } //須注意事項, 其他注意事項
        public string Dispose { get; set; } //配製, 配置方法
        public string Storage { get; set; } //儲存, 儲存方法
        public int HighAlert { get; set; } //高警訊藥品, 警訊藥品
                                           //0: 非高警訊藥品
                                           //1: 高警訊藥品
                                           //2: 化療注射劑
                                           //3: 兒童專用藥
                                           //4: 人體臨床試驗藥品
        public string Pregnancy { get; set; } //懷孕分級, 懷孕分級
        public string NhiNorm { get; set; } //健保規範, 健保規範
        public string ExpireHourDesc { get; set; } //ExpireHour, 開封後有效時數(小時), 開封後有效時數
        public string Injection { get; set; } //輸注速率(針劑專用), 輸注速率
        public string DrugImg { get; set; } //藥品圖示, 藥品圖示
        //http://www.csh.org.tw/into/pharm/Drugimages/{ItemCode}
        public string DrugPkgImg { get; set; } //包裝圖示, 包裝圖示
        //http://www.csh.org.tw/into/pharm/Drugimages/{ItemCode}
        public DrugSet() { }

    }
    public class UddData
    {
        public DataHeadler headler;
        public List<Interaction> interaction;
        public List<DataDetail> detail;
        public UddData()
        {
        }

        public UddData(DataHeadler headler, List<Interaction> interaction, List<DataDetail> detail)
        {
            this.headler = headler;
            this.interaction = interaction;
            this.detail = detail;

        }
    }
    public class DataHeadler
    {
        public string Ward { get; set; } //護理站
        public string ExpandDate { get; set; } //展開日期
        public int VisitNo { get; set; } //就醫號
        public string Roombed { get; set; } //床號
        public string CycleTime { get; set; } //用藥期間
        public string ChartNo { get; set; } //病歷號
        public string PtName { get; set; } //患者姓名
        public string Sex { get; set; } //性別
        public string Birthday { get; set; } //生日
        public string Age { get; set; } //年齡
        public double Weight { get; set; } //體重
        public string InTime { get; set; } //入院時間
        public string Division { get; set; } //科別
        public string Doctor { get; set; } //主治醫師
        public string ChtName { get; set; } //主診斷
        public string Allergy { get; set; } //過敏記錄
        public string LabReport { get; set; } //肝腎檢查
        public string DoseModification { get; set; } // 肝腎劑量調整
    }
    public class DataDetail
    {
        public int SeqNo { get; set; } //序號
        public string ItemName { get; set; } //商品名
        public string GenericName { get; set; } //學名
        public double Dose { get; set; } //劑量
        public string DoseUnit { get; set; } //劑量單位
        public string Usage { get; set; } //頻率
        public string Way { get; set; } //途徑
        public double TotQty { get; set; } //總量
        public string SaleUnit { get; set; }//銷售單位
        public string IsMill { get; set; } //是否磨粉
        public string IsSelf { get; set; }//是否自費
        public string StartTime { get; set; } //開始時間
        public string EndTime { get; set; } //停用時間
        public string Remark { get; set; } //備註
        public string IsChecked { get; set; } //已確認
        public string SmallPicUrl { get; set; } //縮圖連結
        public string PicUrl { get; set; } //圖片連結
        public string UpdateUser { get; set; } //修改人員
        public string UpdateTime { get; set; } //修改時間


        public void SetChecked(string check)
        {
            IsChecked = check;
        }
    }


    public class Interaction
    {
        public string ItemCode1 { get; set; }  //藥品碼1
        public string ItemName1 { get; set; }  //藥品1
        public string ItemCode2 { get; set; }  //藥品碼2
        public string ItemName2 { get; set; }  //藥品2
        public int Significance { get; set; }  //危害等級
        public string Severity { get; set; }  //嚴重程度
        public string Mechanism { get; set; }  //機轉
        public string Management { get; set; }  //管理
    }

    public class PRNOrder
    {
        public string ItemName { get; set; } //品項代碼
        public double Dose { get; set; } //預設次劑量
        public string DoseUnit { get; set; } //劑量單位
        public int UsageNo { get; set; } //使用頻率
        public int WayNo { get; set; } //途徑
        public string SaleUnit { get; set; } //銷售單位
        public double Qty { get; set; } //總量
        public double TotQty { get; set; } //總量
        public string QtyUnit { get; set; } //總量單位
        public string IsSelf { get; set; } //自購
        public string IsMill { get; set; } //磨粉
        public string Ward { get; set; } //護理站
        public string ADC { get; set; } //ADC藥品
        public string IsSchedule { get; set; } //預排
        public string IsPreExam { get; set; } //是否事前審查
        public double NhiPrice { get; set; } //劑量單位健保價
        public double GenPrice { get; set; } //劑量單位自費價
        public string AuthSheet { get; set; } //審查表單
        public string CtrlDrug { get; set; } //管制藥
        //1 :該藥品為管制藥第1級
        //2 :該藥品為管制藥第2級
        //3 :該藥品為管制藥第3級
        //4 :該藥品為管制藥第4級
        //A :該藥品為抗生素第1線
        //B :該藥品為抗生素第2線
        //C :該藥品為抗生素第3線
        //N :該藥品非管制藥
        public string PreExecTime { get; set; } //預定執行(排程)時間
        public int PreExecLoc { get; set; } //預定執行地點
        public int MedType { get; set; } //醫囑類別
        public int DrugType { get; set; } //醫囑類別
        public string IsOwn { get; set; } //獨立一張醫囑單
        public int OrderUser { get; set; }//開立人員
        public int UpdateUser { get; set; }//最後修改人員 
        public int VisitNo { get; set; } //就醫號碼
        public int OrderNo { get; set; } //醫囑編號
        public int ItemNo { get; set; } //項目號
        public double SaleRate { get; set; } //劑量與銷售之轉換比率 = 銷售量 / 次劑量
        public string HasSoa { get; set; } //是否有S.O.A
        public string InfoHint { get; set; }
        public string ExecTime { get; set; } //執行(預定停止)時間
        public string TreatTime { get; set; }//處置時間
        public string TreatStatus { get; set; }//處置情形
        public string MedSummary { get; set; }//醫囑摘要
        public string Advise { get; set; }//醫師指示
        public string HasUseRule { get; set; }//使用規範
        public string IsChecked { get; set; }
        public string HiddenAdvise { get; set; }
        public string ExecNo { get; set; }
        public string GenericName { get; set; }//學名及劑量  2016/11/30 新增
        public string OrganDosing { get; set; }//依器官調整劑量,肝異常需調整 
        public string Atc7Code { get; set; }//藥理分類代碼(ATC7)-主
        public string PureItemName { get; set; }//純商品名
        public string INPStorageCode { get; set; } //住院儲位碼
        public string AdultDosing { get; set; } //用法與劑量
        public string PediatricDosings { get; set; } //劑量備註
        public string IndicationsA1 { get; set; } //適應症(院外)
        public string AdverseEffectsA1 { get; set; } //副作用(院外)
        public string AdverseEffectsA2 { get; set; } //副作用(院內)
        public string IsFreezer { get; set; } //是否需要冷藏2021-09-06
        public string IsExpensive { get; set; }//是否高貴藥品2021-09-06
        public string ItemCode { get; set; }//項目代碼


    }
    public class LabReport
    {
        public string ALT { get; set; }
        public string CRE { get; set; }
        public string eGFR { get; set; }
        public string AST { get; set; }
        public string CrCl { get; set; }
        public string Blood { get; set; }
        public string ADR { get; set; }
        public string IBW { get; set; }
        public string Area { get; set; }

        public LabReport() { }

    }
}