using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.UnitOfWork;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class CustomerManager : ICustomerService
    {
        private readonly ICustomerDal _customerDal;
        private readonly IUnitDal _unitDal;

        public CustomerManager(ICustomerDal customerDal, IUnitDal unitDal)
        {
            _customerDal = customerDal;
            _unitDal = unitDal;
        }

        public void TDelete(Customer t)
        {
            _customerDal.Delete(t);
            _unitDal.Save();
        }

        public Customer TGetById(int id)
        {
            return _customerDal.GetById(id);
        }

        public List<Customer> TGetList()
        {
            return _customerDal.GetList();
        }

        public void TInsert(Customer t)
        {
            _customerDal.Insert(t);
            _unitDal.Save();
        }

        public void TMultiUpdate(List<Customer> t)
        {
            _customerDal.MultiUpdate(t);
            _unitDal.Save();
        }

        public void TUpdate(Customer t)
        {
            _customerDal.Update(t);
            _unitDal.Save();
        }
    }
}
