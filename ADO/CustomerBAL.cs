using System;
using System.Collections.Generic;

namespace ADO
{
    // --- S?A L?I 2: PH?I CÓ CH? 'public' ? ?ÂY ---
    public class CustomerBAL
    {
        CustomerDAL dal = new CustomerDAL();

        public List<CustomerBEL> ReadCustomer()
        {
            List<CustomerBEL> lstCus = dal.ReadCustomer();
            return lstCus;
        }

        public void AddCustomer(CustomerBEL cus)
        {
            dal.NewCustomer(cus);
        }

        public void DeleteCustomer(CustomerBEL cus)
        {
            dal.DeleteCustomer(cus);
        }

        public void EditCustomer(CustomerBEL cus)
        {
            dal.EditCustomer(cus);
        }
    }
}