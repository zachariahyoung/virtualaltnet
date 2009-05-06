using System;
using NHibernate.Validator.Constraints;
using Rhino.Security;
using SharpArch.Core.DomainModel;


namespace van.Core  {

    /// <summary>
    /// User security contexts
    /// </summary>
    public class User : Entity, IUser {


        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        /// <value>The id for the user.</value>
        public virtual long Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the user.
        /// </summary>
        /// <value>The name of the user.</value>
        [DomainSignature]
        public virtual string UserName { get; set; }

        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        /// <value>The email.</value>
        [DomainSignature]
        [Email]
        public virtual string Email { get; set; }

        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        /// <value>The password.</value>
        [DomainSignature]
        public virtual string Password { get; set; }

        /// <summary>
        /// Gets or sets the first name.
        /// </summary>
        /// <value>The first name.</value>

        [DomainSignature]
        public virtual string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the last name.
        /// </summary>
        /// <value>The last name.</value>
        [DomainSignature]
        public virtual string LastName { get; set; }
        
        /// <summary>
        /// Gets or sets the security info for this user
        /// </summary>
        /// <value>
        /// The security info.
        /// </value>
        public override string ToString()
        {
            return UserName;
        }

        public virtual SecurityInfo SecurityInfo
        {
            get { return new SecurityInfo(UserName, Id); }
        }
    }
}
