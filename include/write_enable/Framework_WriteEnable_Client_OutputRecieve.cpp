#include "Framework_WriteEnable_Client_OutputRecieve.h"
#include <cstddef>

namespace WaitEnableWrite
{
	class WaitEnableWrite::WriteEnable_Client_OutputRecieve* Framework_WriteEnable_Client_OutputRecieve::ptr_WriteEnable = NULL;

	Framework_WriteEnable_Client_OutputRecieve::Framework_WriteEnable_Client_OutputRecieve()
	{
		ptr_WriteEnable = NULL;
	}

	Framework_WriteEnable_Client_OutputRecieve::~Framework_WriteEnable_Client_OutputRecieve()
	{

	}

	void Framework_WriteEnable_Client_OutputRecieve::Create_WriteEnable()
	{
		ptr_WriteEnable = new class WaitEnableWrite::WriteEnable_Client_OutputRecieve();
		while (ptr_WriteEnable == NULL) { /* wait untill created */ }
	}

	void Framework_WriteEnable_Client_OutputRecieve::Write_End(unsigned char coreId)
	{
		ptr_WriteEnable->Write_End(coreId);
	}

	void Framework_WriteEnable_Client_OutputRecieve::Write_Start(unsigned char coreId)
	{
		ptr_WriteEnable->Write_Start(coreId);
	}

	WaitEnableWrite::WriteEnable_Client_OutputRecieve* Framework_WriteEnable_Client_OutputRecieve::Get_WriteEnable()
	{
		return ptr_WriteEnable;
	}
}