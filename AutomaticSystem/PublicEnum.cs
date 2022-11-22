using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomaticSystem
{
    public enum enMessageType : int
    {
        Default = 0,
        Primary = 1,
        Info = 2,
        Success = 3,
        Warning = 4,
        Error = 5,
        Question = 6,
    }
    public enum enMessageButton : int
    {
        OKCancel = 0,
        OK = 1,
    }
    public enum enK1K2 : int
    {
        Abdomen = 0,
        Chest = 1,
        UpperArm = 2,
        Back = 3,
        LowerArm = 4,
        Thigh = 5,
        LowerLeg = 6,
        Hands = 7
    }
    public enum enAxis : int
    { 
        X = 0,
        Y = 1,
        Z= 2
    }
}
