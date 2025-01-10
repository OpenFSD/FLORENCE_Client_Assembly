using FLORENCE.Frame.Cli.Dat.In;
using FLORENCE.Frame.Cli.Dat.Out.Gfx;
using OpenTK.Mathematics;
using OpenTK.Windowing.Common;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLORENCE
{
    public class Input
    {
        static private FLORENCE.Frame.Cli.Dat.In.Input_Control input_Control;
        static private Object praiseInputBuffer_Subset;

        static private UInt16 praiseEventId;
        

        public Input()
        {
            input_Control = null;

            praiseEventId = new int();
            praiseEventId = 0;

            praiseInputBuffer_Subset = null;

            System.Console.WriteLine("FLORENCE: Input");
        }

        public void InitialiseControl() 
        {
            input_Control = new FLORENCE.Frame.Cli.Dat.In.Input_Control();
            while (input_Control == null) { /* Wait while is created */ }
        }

        public Object Get_InputBufferSubset()
        {
            return praiseInputBuffer_Subset;
        }

        public FLORENCE.Frame.Cli.Dat.In.Input_Control GetInputControl()
        {
            return input_Control;
        }

        public int GetPraiseEventId() 
        {   
            return praiseEventId; 
        }

        public void Set_InputBuffer_SubSet(Object value)
        {
            praiseInputBuffer_Subset = value;
        }

        public void SetPraiseEventId(UInt16 value)
        {
            praiseEventId = value;
        }
    }
}