using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Utility
{
    public class UserProfile
    {
        private int _userId, _locationId, _practiceId, _organisationId,_stateId, _employeeId, _departmentId, _doctorId, _specialtyId, _subInventoryId;
        private string _fullName, _email, _picture;
        private int _userGroupId;

        public UserProfile()
        {

        }
        public UserProfile(int userId, int locationId, int practiceId,int organisationId, int stateId, int employeeId, int departmentId, int doctorId, int specialtyId, int subInventoryId, string fullName, string email, string picture,int userGroupId)
        {
            this._userId = userId;
            this._locationId = locationId;
            this._practiceId = practiceId;
            this._organisationId = organisationId;
            this._stateId = stateId;
            this._employeeId = employeeId;
            this._departmentId = departmentId;
            this._doctorId = doctorId;
            this._specialtyId = specialtyId;
            this._subInventoryId = subInventoryId;
            this._fullName = fullName;
            this._email = email;
            this._picture = picture;
            this._userGroupId = userGroupId;
        }
        public int UserId { get { return this._userId; } }
        public int UserGroupId { get { return this._userGroupId; } }
        public string FullName { get { return this._fullName; } }
        public string Email { get { return this._email; } }
        public string Picture { get { return this._picture; } }
        public int LocationId { get { return this._locationId; } }
        public int PracticeId { get { return this._practiceId; } }
        public int OrganisationId { get { return this._organisationId; } }
        public int SiteId { get { return this._stateId; } }
        public int EmployeeID { get { return this._employeeId; } }
        public int DepartmentID { get { return this._departmentId; } }
        public int DoctorID { get { return this._doctorId; } }
        public int SpecialtyID { get { return this._specialtyId; } }
        public int SubInventoryID { get { return this._subInventoryId; } }
    }
}
