//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace UniversityStudentsInfo
{
    using System;
    using System.Collections.Generic;
    
    public partial class StudentInfo
    {
        public int StudentID { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Patronymic { get; set; }
        public System.DateTime DateOfEnrollment { get; set; }
        public int Group { get; set; }
        public string Course { get; set; }
        public int AttestatScanNumber { get; set; }
        public string PassportNumber { get; set; }
        public string Registration { get; set; }
        public string Telephone { get; set; }
        public string FullName
        {
            get
            {
                return LastName + " " + FirstName + " " + Patronymic;
            }
        }
        public virtual Courses Courses { get; set; }
        public virtual Groups Groups { get; set; }
    }
}
