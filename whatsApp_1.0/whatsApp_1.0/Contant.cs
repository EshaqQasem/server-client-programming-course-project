using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MyLibrary.Data;

namespace whatsApp_1._0
{
    

    public interface IContantRepository
    {
        void AddContant(Contant contant);
        IEnumerable<Contant> GetContants();
        Contant GetContant(string phoneNumber);
        void UpdateContant(string phoneNumber, Contant updatedContant);
        void DeleteContant(string phoneNumber);       
    }
   
    public  class ContantMSAccessRepository : IContantRepository
    {
       protected IDataAccessLayer dal;
       public ContantMSAccessRepository()
       {
       }
        public void AddContant(Contant contant)
        {
            dal.Connect();
            
        }

        public IEnumerable<Contant> GetContants()
        {
            throw new NotImplementedException();
        }

        public Contant GetContant(string phoneNumber)
        {
            throw new NotImplementedException();
        }

        public void UpdateContant(string phoneNumber, Contant updatedContant)
        {
            throw new NotImplementedException();
        }

        public void DeleteContant(string phoneNumber)
        {
            throw new NotImplementedException();
        }
    }

    //public class ContantSqlRepository : ContantDatBaseRepository
    //{
    //    public ContantSqlRepository()
    //    {
    //        dal = new SqlDataAccessLayer();
    //    }
    //}
    //public class ContantOleDbRepository : ContantDatBaseRepository
    //{
    //    public ContantOleDbRepository()
    //    {
    //        dal = new OleDbDataAccessLayer();
    //    }
    //}
}
