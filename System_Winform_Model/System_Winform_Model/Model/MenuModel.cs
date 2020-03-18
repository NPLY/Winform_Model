using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System_Winform_Model.Model
{
   public class MenuModel
    {  
        //dll 檔案名稱
        public string root { get; set; }
        //節點的代號，自動編號
        public int ID { get; set; }
        //父節點，如果是0，代表為根節點
        public int ParentID { get; set; }
        //值
        public string ChineseName { get; set; }
        //值
        public string Value { get; set; }
        //是否為葉子
        public int Leaf { get; set; }
        //權限
        public string PERMISSIONS { get; set; }

        public List<MenuModel> GetMENUTREE()
        {
            List<MenuModel> menumodels = new List<MenuModel>();
            menumodels.Add(new MenuModel() { ID = 1, ParentID = 0, Value = "樣板", Leaf = 0, ChineseName = "樣板", root = "System_Winform_Model", PERMISSIONS = "NULL" });
            menumodels.Add(new MenuModel() { ID = 2, ParentID = 1, Value = "系統設定", Leaf = 0, ChineseName = "系統設定", root = "System_Winform_Model", PERMISSIONS = "NULL" });
            menumodels.Add(new MenuModel() { ID = 3, ParentID = 1, Value = "基本資料", Leaf = 0, ChineseName = "基本資料", root = "System_Winform_Model", PERMISSIONS = "NULL" });
            menumodels.Add(new MenuModel() { ID = 4, ParentID = 2, Value = "Fm1_ChPw", Leaf = 1, ChineseName = "變更密碼", root = "System_Winform_Model", PERMISSIONS = "N_TC" });
            menumodels.Add(new MenuModel() { ID = 5, ParentID = 2, Value = "關閉程式", Leaf = 1, ChineseName = "關閉程式", root = "System_Winform_Model", PERMISSIONS = "N_TC" });
            menumodels.Add(new MenuModel() { ID = 6, ParentID = 3, Value = "Fm2_Test", Leaf = 1, ChineseName = "測試", root = "System_Winform_Model", PERMISSIONS = "NULL" });
            menumodels.Add(new MenuModel() { ID = 7, ParentID = 3, Value = "Fm2_Test2", Leaf = 1, ChineseName = "測試2", root = "System_Winform_Model", PERMISSIONS = "NULL" });
            menumodels.Add(new MenuModel() { ID = 8, ParentID = 1, Value = "功能區1", Leaf = 0, ChineseName = "功能區1", root = "System_Winform_Model", PERMISSIONS = "NULL" });
            menumodels.Add(new MenuModel() { ID = 9, ParentID = 8, Value = "Fm3_CopyExcel", Leaf = 1, ChineseName = "複製欄位", root = "System_Winform_Model", PERMISSIONS = "NULL" });

            return menumodels;
        }
    }
}

