class GetInfo
{

    static GetInfo _instance=null;

    static GetInfo GetInstance()
    {
      if (_instance==null)
          _instance=new  GetInfo();
          return _instance;
    }


}
