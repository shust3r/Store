using Microsoft.AspNetCore.Mvc.Rendering;
using Store_DataAccess.Repository.IRepository;
using Store_Models;
using Store_Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store_DataAccess.Repository
{
    public class InquiryDetailRepository : Repository<InquiryDetail>, IInquiryDetailRepository
    {
        private readonly ApplicationDbContext _db;

        public InquiryDetailRepository(ApplicationDbContext db): base(db)
        {
            _db = db;
        }

        public void Update(InquiryDetail obj)
        {
            _db.InquiryDetail.Update(obj);
        }
    }
}
