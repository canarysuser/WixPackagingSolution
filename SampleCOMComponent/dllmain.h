// dllmain.h : Declaration of module class.

class CSampleCOMComponentModule : public ATL::CAtlDllModuleT< CSampleCOMComponentModule >
{
public :
	DECLARE_LIBID(LIBID_SampleCOMComponentLib)
	DECLARE_REGISTRY_APPID_RESOURCEID(IDR_SAMPLECOMCOMPONENT, "{dccb4c4d-8bfa-4d61-ba09-0e2b0d94b8a1}")
};

extern class CSampleCOMComponentModule _AtlModule;
