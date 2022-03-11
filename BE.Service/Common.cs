using System;
using System.Collections.Generic;
using System.Text;

namespace BE.Service
{
    /// <summary>
    /// Common class to hold constants and general enums
    /// </summary>
    public class Common
    {
        /// <summary>
        /// Mail messages
        /// </summary>
        public class Messages
        {
            public const string WelcomeNewUserEmailSubject = "New user email";
            public const string ResetPasswordEmailSubject = "Reset password";
        }

        /// <summary>
        /// Email HTML template paths
        /// </summary>
        public class EmailTemplates
        {
            public const string WelcomeNewUserEmailTemplate = "BE.Service.EmailTemplates.WelcomeNewUserEmail.html";
            public const string ResetPasswordEmailTemplate = "BE.Service.EmailTemplates.ResetPasswordEmail.html";
        }

        /// <summary>
        /// User roles
        /// </summary>
        public class UserRoles
        {
            public const string Admin = "Admin";
            public const string InternalUser = "InternalUser";
        }

        /// <summary>
        /// Exception messages
        /// </summary>
        public class ErrorMessages
        {
            public const string MissingArgument = "Missing argument: {0}";
            public const string InvalidID = "Invalid id: {0}";
            public const string IdMissmatch = "Id do not match. Entity: {0}. ID: {1}";
            public const string KeyNotFound = "Entity not found for the given ID. Entity: {0}. ID: {1}";
            public const string DBUpdateError = "Error while saving changes to Data Base.";
            public const string UserNameAlreadyExists = "User name already exists.";
            public const string UserNameDoesntExists = "User name doesn't exists.";
            public const string UserNotResolved = "User not resolved.";
            public const string CantUpdateSelfUser = "User can't edit itself. ID: {0}";
            public const string DuplicateKeyFound = "Duplicate Entity found for the given entry: {0}";
            public const string InvalidPassWordLink = "Invalid password link";
        }
    }
}
