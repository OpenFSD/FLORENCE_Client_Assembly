#include "Global_ConcurrentQue_Client.h"
#include <cstddef>

namespace ConcurrentQue
{
    bool Global_ConcurrentQue_Client::flag_core_ACTIVE = NULL;
    bool Global_ConcurrentQue_Client::flag_core_IDLE = NULL;
    unsigned char Global_ConcurrentQue_Client::number_Implemented_Cores = NULL;

    Global_ConcurrentQue_Client::Global_ConcurrentQue_Client()
    {
        flag_core_ACTIVE = bool(true);
        flag_core_IDLE = bool(false);

        number_Implemented_Cores = unsigned char(4);//NUMBER OF CORES
    }

    Global_ConcurrentQue_Client::~Global_ConcurrentQue_Client()
    {

    }

    bool Global_ConcurrentQue_Client::GetConst_Core_ACTIVE()
    {
        return flag_core_ACTIVE;
    }
    bool Global_ConcurrentQue_Client::GetConst_Core_IDLE()
    {
        return flag_core_IDLE;
    }
    unsigned char Global_ConcurrentQue_Client::Get_NumCores()
    {
        return number_Implemented_Cores;
    }
}