#pragma once
#define WIN32_LEAN_AND_MEAN             // Exclude rarely-used stuff from Windows headers
#include <bitset>
#include "WriteEnable_Client_OutputRecieve.h"

namespace WaitEnableWrite
{
    class Framework_WriteEnable_Client_OutputRecieve
    {
    public:
        Framework_WriteEnable_Client_OutputRecieve();
        virtual ~Framework_WriteEnable_Client_OutputRecieve();
        static void Create_WriteEnable();
        static void Write_End(unsigned char coreId);
        static void Write_Start(unsigned char coreId);

        static class WriteEnable_Client_OutputRecieve* Get_WriteEnable();

    protected:

    private:
        static class WriteEnable_Client_OutputRecieve* ptr_WriteEnable;
    };
}