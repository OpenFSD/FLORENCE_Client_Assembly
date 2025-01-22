#pragma once
#define WIN32_LEAN_AND_MEAN             // Exclude rarely-used stuff from Windows headers

#include "LaunchConcurrency.h"

namespace ConcurrentQue
{
    class Framework_ConcurrentQue
    {
    public:
        Framework_ConcurrentQue();
        virtual ~Framework_ConcurrentQue();
        void Request_Wait_Launch_ConcurrentThread(unsigned char concurrent_CoreId);
        void ConcurrentThread_End(unsigned char concurrent_CoreId);
        void Create_ConcurrentQue();
        static class LaunchConcurrency* Get_LaunchConcurrency();

    protected:

    private:
        static class LaunchConcurrency* ptr_LaunchConcurrency;
    };
}