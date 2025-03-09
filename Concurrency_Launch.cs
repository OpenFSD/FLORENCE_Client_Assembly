/*
 *  Managed C# wrapper for FLORENCE Concurrent Que library by Jasper Assembly Pty Ltd.
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

namespace Florence.Concurrency
{
    [SuppressUnmanagedCodeSecurity]
    public static class ConcurrentQue_Client
    {
        [DllImport("WaitLaunch_Client_ConcurrentThread.dll", CharSet = CharSet.Unicode)]
        public static extern void Create_ConcurrentQue();

        [DllImport("WaitLaunch_Client_ConcurrentThread.dll", CharSet = CharSet.Unicode)]
        public static extern void Request_Wait_Launch_ConcurrentThread(ushort concurrent_coreId);

        [DllImport("WaitLaunch_Client_ConcurrentThread.dll", CharSet = CharSet.Unicode)]
        public static extern void ConcurrentThread_End(ushort concurrent_coreId);
    }
    
    [SuppressUnmanagedCodeSecurity]
    public static class ConcurrentQue_Server
    {
        [DllImport("WaitLaunch_Server_ConcurrentThread.dll", CharSet = CharSet.Unicode)]
        public static extern void Create_ConcurrentQue();

        [DllImport("WaitLaunch_Server_ConcurrentThread.dll", CharSet = CharSet.Unicode)]
        public static extern void Request_Wait_Launch_ConcurrentThread(ushort concurrent_coreId);

        [DllImport("WaitLaunch_Server_ConcurrentThread.dll", CharSet = CharSet.Unicode)]
        public static extern void ConcurrentThread_End(ushort concurrent_coreId);
    }
}