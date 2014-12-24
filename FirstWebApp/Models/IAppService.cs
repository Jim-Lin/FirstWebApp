namespace FirstWebApp.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;

    public interface IAppService<T>
    {
        IList<T> FindRecords();

        T GetRecordByName(string name);

        T GetRecordById(int id);

        void AddRecord(T record);

        void UpdateRecord(T record);

        void DeleteRecord(int id);
    }
}