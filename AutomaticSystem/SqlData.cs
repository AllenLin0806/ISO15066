using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomaticSystem
{
    class SqlData
    {
        public string GetData(string DataType, int Action)
        {
            string G = "";
            switch (DataType)
            {

                case "ContrlBox_Name":
                    G = ContrlBox_Name(Action);
                    break;
                case "HW_Version":
                    G = HW_Version(Action);
                    break;
                case "Tester":
                    G = Tester(Action);
                    break;
                case "HMI_Version":
                    G = HMI_Version(Action);
                    break;
                case "Data":
                    G = Data(Action);
                    break;
            }
            return G;
        }

        private string ContrlBox_Name(int Action)
        {
            string Sqlstr = "";
            switch (Action)
            {
                case 1: //查詢ContrlBox Mode Name
                    Sqlstr = "Select cbName from ContrlBox_Name where ArmName ='?1'";
                    break;
            }
            return Sqlstr;
        }

        private string HW_Version(int Action)
        {
            string Sqlstr = "";
            switch (Action)
            {
                case 1: //查詢HW版本
                    Sqlstr = "Select * from HW_Version order by hw_version desc";
                    break;
                case 2: //新增HW版本
                    Sqlstr = "insert into HW_Version(hw_version,pid) values('?1','?2')";
                    break;
                case 3: //取得最大PID
                    Sqlstr = "select max(pid) from HW_Version";
                    break;
                case 4: //修改HW版本
                    Sqlstr = "update HW_Version set hw_version ='?1' where pid =?2";
                    break;
                case 5: //刪除HW版本
                    Sqlstr = "delete from HW_Version where pid =?1";
                    break;
            }
            return Sqlstr;
        }

        private string HMI_Version(int Action)
        {
            string Sqlstr = "";
            switch (Action)
            {
                case 1:
                    Sqlstr = "Select * from HMI_Version order by Version desc";
                    break;
                case 2: //新增HMI版本
                    Sqlstr = "insert into HMI_Version(Version,pid) values('?1','?2')";
                    break;
                case 3: //取得最大PID
                    Sqlstr = "select max(pid) from HMI_Version";
                    break;
                case 4: //修改HMI版本
                    Sqlstr = "update HMI_Version set Version = '?1' where pid =?2";
                    break;
                case 5: //刪除HMI版本
                    Sqlstr = "delete from HMI_Version where pid =?1";
                    break;
            }
            return Sqlstr;
        }

        private string Tester(int Action)
        {
            string Sqlstr = "";
            switch (Action)
            {
                case 1: //查詢測試人員
                    Sqlstr = "Select * from Tester";
                    break;
                case 2:
                    Sqlstr = "insert into Tester(Name) values('?1')";
                    break;
                case 3: //修改Tester版本
                    Sqlstr = "update Tester set Name = '?1' where id =?2";
                    break;
                case 4: //修改Tester版本
                    Sqlstr = "delete from Tester where id =?1";
                    break;
            }
            return Sqlstr;
        }

        private string Data(int Action)
        {
            string Sqlstr = "";
            switch (Action)
            {
                case 1: //建立
                    Sqlstr = "insert into ThingsValue(Axis,K1K2,FT,FS,pid,done_datetime,last_datetime,ArmModel_SN) values('?1','?2',?3,?4,?5,'?6','?7','?8')";
                    break;
                case 2: //讀取建立數值
                    Sqlstr = "select * from ThingsValue where DateValue(last_datetime) = Date() and id >=?1 order by id";
                    break;
                case 3: //取最大ID
                    Sqlstr = "select max(id) from ThingsValue";
                    break;
                case 4: //取3筆資料
                    Sqlstr = "select FT,FS from ThingsValue where id >=?1 and id<=?2 order by FT desc";
                    break;
                case 5: //取最大Force(Max)跟FS
                    Sqlstr = "select Axis,K1K2,FT,FS,pid from ThingsValue where FT=(select max(FT) from ThingsValue where id >=?1 and id<=?2) and id >=?1 and id<=?2";
                    break;
                case 6: //取中間值Force(Max)跟FS
                    Sqlstr = "select Axis,K1K2,FT,FS,pid from ThingsValue where FT < (select max(FT) from ThingsValue where id >=?1 and id<=?2) ";
                    Sqlstr += "and FT > (select min(FT) from ThingsValue where id >=?1 and id<=?2) ";
                    Sqlstr += "and id >=?1 and id<=?2 order by FT desc";
                    break;
                case 7: //查詢全部資訊
                    Sqlstr = "select * from ThingsValue where id >=?1";
                    break;
                case 8: //不重複查詢ArmModel_SN
                    Sqlstr = "select Distinct ArmModel_SN from ThingsValue";
                    break;
                case 9: //查詢指定資料
                    Sqlstr = "select * from ThingsValue where ArmModel_SN ='?1' and last_datetime between '?2' and '?3' order by done_datetime";
                    break;
                case 10://修改FT及FS資訊
                    Sqlstr = "update ThingsValue set FT = '?1', FS = '?2', last_datetime ='?3' where id =?4";
                    break;
            }
            return Sqlstr;
        }

    }
}
