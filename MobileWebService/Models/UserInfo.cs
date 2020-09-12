using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MobileWebService.Models
{
    public class UserInfo
    {
        public virtual uint ID { get; set; }
        public virtual string LoginName { get; set; }
        public virtual string UserName { get; set; }
        public virtual string Password { get; set; }

        public virtual uint UserTypeID { get; set; }

        public virtual uint ICNo { get; set; }
        public virtual string JobTypeName { get; set; }
        public virtual string Roles { get; set; }
        public virtual string CompanyName { get; set; }
        public virtual string Mobile { get; set; }

        public  virtual int IsEnable { get; set; }

        public virtual string Remark { get; set; }

        public virtual string Field1 { get; set; }


    }
}
