using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zero.Storage.BlogContext
{
    public class User
    {

    }

    public class RoleModel
    {
        public int RoleID { get; set; }
    }

    public class UserCookie
    {
        /// <summary>
        /// 角色列表
        /// TODO：2013-10-14 余锦 先放在实体对象上
        /// </summary>
        public IList<RoleModel> Roles { get; set; }

        #region Public Methods

        /// <summary>
        /// 是否园长
        /// </summary>
        /// <returns></returns>
        public bool IsPrincipal()
        {
            if (Roles != null)
            {
                return Roles.Any(role => role.RoleID == Convert.ToInt32(SystemRoleEnum.Principal));
            }
            return false;
        }

        /// <summary>
        /// 是否是老师
        /// </summary>
        /// <returns></returns>
        public bool IsTeacher()
        {
            if (Roles != null)
            {
                return Roles.Any(role => role.RoleID == Convert.ToInt32(SystemRoleEnum.Teacher));
            }
            return false;
        }

        #endregion
    }

    /// <summary>
    /// 系统内置用户角色
    /// </summary>
    public enum SystemRoleEnum
    {
        /// <summary>
        /// 空角色
        /// </summary>
        None = 0,

        /// <summary>
        /// 孩子
        /// </summary>
        Children = 1,

        /// <summary>
        /// 家长
        /// </summary>
        Parent = 2,

        /// <summary>
        /// 老师
        /// </summary>
        Teacher = 4,

        /// <summary>
        /// 园长
        /// </summary>
        Principal = 8,

        /// <summary>
        /// 员工
        /// </summary>
        Employee = 16
    }
}
