namespace IBuilder
{
    public interface IBuilderDAL
    {
        string CreatDal(bool maxid, bool exists, bool add, bool update, bool delete, bool getModel, bool list);

        string CreatInstance();

        string CreatAdd();
        string CreatUpdate();
        string CreatDelete();
        string CreatGetModel();
        string CreatDataRowToModel();
        string CreatGetList();
        string CreatGetListByPage();
        string CreatGetListByPageProc();
    }
}