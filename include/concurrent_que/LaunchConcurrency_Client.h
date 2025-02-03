#pragma once
#include "Framework_ConcurrentQue_Client.h"
#include "LaunchConcurrency_Control_Client.h"
#include "Global_ConcurrentQue_Client.h"

namespace ConcurrentQue
{
    class LaunchConcurrency_Client
    {
    public:
        LaunchConcurrency_Client();
        virtual ~LaunchConcurrency_Client();

        void Thread_Start(unsigned char concurrent_CoreId);
        void Initialise_Control(
            class Global_ConcurrentQue_Client* ptr_Global,
            unsigned char ptr_MyNumImplementedCores
        );
        void Thread_End(unsigned char concurrent_CoreId);

        class LaunchConcurrency_Control_Client* Get_Control_Of_LaunchConcurrency();
        class Global_ConcurrentQue_Client* Get_GlobalForLaunchConcurrency();

    protected:

    private:
        static class Global_ConcurrentQue_Client* ptr_Global;
        static class LaunchConcurrency_Control_Client* ptr_LaunchConcurrency_Control;
    };
}