using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.BlogContext.DTO
{
    public class SchoolDTO
    {
        /// <summary>
        /// 学校ID
        /// </summary>
        public int SchoolID { get; set; }

        /// <summary>
        /// 学校名称
        /// </summary>
        public string SchoolName { get; set; }

        /// <summary>
        /// 学校地址
        /// </summary>
        public string Address { get; set; }
    }
}
