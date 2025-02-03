#pragma once
#include <array>

namespace ConcurrentQue
{
    class Global_ConcurrentQue_Client
    {
    public:
        Global_ConcurrentQue_Client();
        ~Global_ConcurrentQue_Client();
        bool GetConst_Core_IDLE();
        bool GetConst_Core_ACTIVE();
        unsigned char Get_NumCores();

    protected:

    private:
        static bool flag_core_IDLE;
        static bool flag_core_ACTIVE;
        static unsigned char number_Implemented_Cores;
    };
}
