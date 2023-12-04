using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace BLL
{
    public class AdminBusiness:BaseBusiness
    {
        public void ApproveOrReject(List<int> Ids, string Status)
        {
            using (TransactionScope Trans = new TransactionScope())
            {
                try
                {
                    foreach (var item in Ids)
                    {
                        var myUrl = urlBs.GetById(item);
                        myUrl.Approved = Status;
                        urlBs.Update(myUrl);
                    }

                    Trans.Complete();
                }
                catch (Exception e)
                {
                    throw new Exception(e.Message);
                }
            }
        }
    }
}
