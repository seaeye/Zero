using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Service.BlogContext.DTO;

namespace Zero.Service.BlogContext
{
    public interface ISchoolService
    {
        /// <summary>
        /// 创建学校
        /// </summary>
        /// <param name="schoolDTO"></param>
        /// <returns></returns>
        SchoolDTO CreateSchool(SchoolDTO schoolDTO);

        /// <summary>
        /// 修改学校
        /// </summary>
        /// <param name="schoolDTO"></param>
        /// <returns></returns>
        SchoolDTO ModifySchool(SchoolDTO schoolDTO);
    }

    public class SchoolService : ISchoolService
    {
        /// <summary>
        /// 创建学校
        /// </summary>
        /// <param name="schoolDTO"></param>
        /// <returns></returns>
        public SchoolDTO CreateSchool(SchoolDTO schoolDTO)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 修改学校
        /// </summary>
        /// <param name="schoolDTO"></param>
        /// <returns></returns>
        public SchoolDTO ModifySchool(SchoolDTO schoolDTO)
        {
            throw new NotImplementedException();
        }
    }
}
