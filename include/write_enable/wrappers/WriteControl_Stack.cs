/*
 *  Managed C# wrapper for FLORENCE Server library by Jasper Assembly Pty Ltd.
 *  Copyright (c) 2022 - 2025 Brenton James Maddocks BEng(CompSys).  
 *  All rights reserved.
 */

using System;
using System.Collections;
using System.Net;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;

namespace Florence.WriteEnable
{
    [SuppressUnmanagedCodeSecurity]
    public static class Stack_InputAction
    {
        [DllImport("WriteEnable_Stack_InputAction.dll", CharSet = CharSet.Unicode)]
        public static extern void Write_End(ushort coreId);

        [DllImport("WriteEnable_Stack_InputAction.dll", CharSet = CharSet.Unicode)]
        public static extern void Write_Start(ushort coreId);
    }
    
    [SuppressUnmanagedCodeSecurity]
    public static class Stack_OutputRecieve
    {
        [DllImport("WriteEnable_Stack_OutputRecieve.dll", CharSet = CharSet.Unicode)]
        public static extern void Write_End(ushort coreId);

        [DllImport("WriteEnable_Stack_OutputRecieve.dll", CharSet = CharSet.Unicode)]
        public static extern void Write_Start(ushort coreId);
    }
}