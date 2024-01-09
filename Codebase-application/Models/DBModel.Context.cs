﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Codebase_application.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class CodebaseEntities : DbContext
    {
        public CodebaseEntities()
            : base("name=CodebaseEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<User_Details> User_Details { get; set; }
    
        public virtual ObjectResult<sp_GetUserDetails_Result> sp_GetUserDetails(string email)
        {
            var emailParameter = email != null ?
                new ObjectParameter("Email", email) :
                new ObjectParameter("Email", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_GetUserDetails_Result>("sp_GetUserDetails", emailParameter);
        }
    
        public virtual int sp_UserDetail(string firstName, string lastName, string password, string email, string mobileNo)
        {
            var firstNameParameter = firstName != null ?
                new ObjectParameter("FirstName", firstName) :
                new ObjectParameter("FirstName", typeof(string));
    
            var lastNameParameter = lastName != null ?
                new ObjectParameter("LastName", lastName) :
                new ObjectParameter("LastName", typeof(string));
    
            var passwordParameter = password != null ?
                new ObjectParameter("Password", password) :
                new ObjectParameter("Password", typeof(string));
    
            var emailParameter = email != null ?
                new ObjectParameter("Email", email) :
                new ObjectParameter("Email", typeof(string));
    
            var mobileNoParameter = mobileNo != null ?
                new ObjectParameter("MobileNo", mobileNo) :
                new ObjectParameter("MobileNo", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_UserDetail", firstNameParameter, lastNameParameter, passwordParameter, emailParameter, mobileNoParameter);
        }
    
        public virtual ObjectResult<sp_GetAllUserDetails_Result> sp_GetAllUserDetails()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_GetAllUserDetails_Result>("sp_GetAllUserDetails");
        }

        public System.Data.Entity.DbSet<Codebase_application.Models.sp_GetAllUserDetails_Result> sp_GetAllUserDetails_Result { get; set; }
    }
}