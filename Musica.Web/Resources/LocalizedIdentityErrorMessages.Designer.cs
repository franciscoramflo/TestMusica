﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Musica.Web.Resources {
    using System;
    
    
    /// <summary>
    ///   Clase de recurso fuertemente tipado, para buscar cadenas traducidas, etc.
    /// </summary>
    // StronglyTypedResourceBuilder generó automáticamente esta clase
    // a través de una herramienta como ResGen o Visual Studio.
    // Para agregar o quitar un miembro, edite el archivo .ResX y, a continuación, vuelva a ejecutar ResGen
    // con la opción /str o recompile su proyecto de VS.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "16.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public class LocalizedIdentityErrorMessages {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal LocalizedIdentityErrorMessages() {
        }
        
        /// <summary>
        ///   Devuelve la instancia de ResourceManager almacenada en caché utilizada por esta clase.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Musica.Web.Resources.LocalizedIdentityErrorMessages", typeof(LocalizedIdentityErrorMessages).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Reemplaza la propiedad CurrentUICulture del subproceso actual para todas las
        ///   búsquedas de recursos mediante esta clase de recurso fuertemente tipado.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a Optimistic concurrency failure, object has been modified..
        /// </summary>
        public static string ConcurrencyFailure {
            get {
                return ResourceManager.GetString("ConcurrencyFailure", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a An unknown failure has occurred..
        /// </summary>
        public static string DefaultError {
            get {
                return ResourceManager.GetString("DefaultError", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a Email &apos;{0}&apos; is already taken..
        /// </summary>
        public static string DuplicateEmail {
            get {
                return ResourceManager.GetString("DuplicateEmail", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a Role name &apos;{0}&apos; is already taken..
        /// </summary>
        public static string DuplicateRoleName {
            get {
                return ResourceManager.GetString("DuplicateRoleName", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a User name &apos;{0}&apos; is already taken..
        /// </summary>
        public static string DuplicateUserName {
            get {
                return ResourceManager.GetString("DuplicateUserName", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a Email &apos;{0}&apos; is invalid..
        /// </summary>
        public static string InvalidEmail {
            get {
                return ResourceManager.GetString("InvalidEmail", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a Type {0} must derive from {1}&lt;{2}&gt;..
        /// </summary>
        public static string InvalidManagerType {
            get {
                return ResourceManager.GetString("InvalidManagerType", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a The provided PasswordHasherCompatibilityMode is invalid..
        /// </summary>
        public static string InvalidPasswordHasherCompatibilityMode {
            get {
                return ResourceManager.GetString("InvalidPasswordHasherCompatibilityMode", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a The iteration count must be a positive integer..
        /// </summary>
        public static string InvalidPasswordHasherIterationCount {
            get {
                return ResourceManager.GetString("InvalidPasswordHasherIterationCount", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a Role name &apos;{0}&apos; is invalid..
        /// </summary>
        public static string InvalidRoleName {
            get {
                return ResourceManager.GetString("InvalidRoleName", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a Invalid token..
        /// </summary>
        public static string InvalidToken {
            get {
                return ResourceManager.GetString("InvalidToken", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a User name &apos;{0}&apos; is invalid, can only contain letters or digits..
        /// </summary>
        public static string InvalidUserName {
            get {
                return ResourceManager.GetString("InvalidUserName", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a A user with this login already exists..
        /// </summary>
        public static string LoginAlreadyAssociated {
            get {
                return ResourceManager.GetString("LoginAlreadyAssociated", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a AddIdentity must be called on the service collection..
        /// </summary>
        public static string MustCallAddIdentity {
            get {
                return ResourceManager.GetString("MustCallAddIdentity", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a No IPersonalDataProtector service was registered, this is required when ProtectPersonalData = true..
        /// </summary>
        public static string NoPersonalDataProtector {
            get {
                return ResourceManager.GetString("NoPersonalDataProtector", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a No RoleType was specified, try AddRoles&lt;TRole&gt;()..
        /// </summary>
        public static string NoRoleType {
            get {
                return ResourceManager.GetString("NoRoleType", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a No IUserTwoFactorTokenProvider&lt;{0}&gt; named &apos;{1}&apos; is registered..
        /// </summary>
        public static string NoTokenProvider {
            get {
                return ResourceManager.GetString("NoTokenProvider", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a User security stamp cannot be null..
        /// </summary>
        public static string NullSecurityStamp {
            get {
                return ResourceManager.GetString("NullSecurityStamp", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a Incorrect password..
        /// </summary>
        public static string PasswordMismatch {
            get {
                return ResourceManager.GetString("PasswordMismatch", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a Passwords must have at least one digit (&apos;0&apos;-&apos;9&apos;)..
        /// </summary>
        public static string PasswordRequiresDigit {
            get {
                return ResourceManager.GetString("PasswordRequiresDigit", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a Passwords must have at least one lowercase (&apos;a&apos;-&apos;z&apos;)..
        /// </summary>
        public static string PasswordRequiresLower {
            get {
                return ResourceManager.GetString("PasswordRequiresLower", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a Passwords must have at least one non alphanumeric character..
        /// </summary>
        public static string PasswordRequiresNonAlphanumeric {
            get {
                return ResourceManager.GetString("PasswordRequiresNonAlphanumeric", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a Passwords must use at least {0} different characters..
        /// </summary>
        public static string PasswordRequiresUniqueChars {
            get {
                return ResourceManager.GetString("PasswordRequiresUniqueChars", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a Passwords must have at least one uppercase (&apos;A&apos;-&apos;Z&apos;)..
        /// </summary>
        public static string PasswordRequiresUpper {
            get {
                return ResourceManager.GetString("PasswordRequiresUpper", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a Passwords must be at least {0} characters..
        /// </summary>
        public static string PasswordTooShort {
            get {
                return ResourceManager.GetString("PasswordTooShort", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a Recovery code redemption failed..
        /// </summary>
        public static string RecoveryCodeRedemptionFailed {
            get {
                return ResourceManager.GetString("RecoveryCodeRedemptionFailed", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a Role {0} does not exist..
        /// </summary>
        public static string RoleNotFound {
            get {
                return ResourceManager.GetString("RoleNotFound", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a Store does not implement IProtectedUserStore&lt;TUser&gt; which is required when ProtectPersonalData = true..
        /// </summary>
        public static string StoreNotIProtectedUserStore {
            get {
                return ResourceManager.GetString("StoreNotIProtectedUserStore", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a Store does not implement IQueryableRoleStore&lt;TRole&gt;..
        /// </summary>
        public static string StoreNotIQueryableRoleStore {
            get {
                return ResourceManager.GetString("StoreNotIQueryableRoleStore", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a Store does not implement IQueryableUserStore&lt;TUser&gt;..
        /// </summary>
        public static string StoreNotIQueryableUserStore {
            get {
                return ResourceManager.GetString("StoreNotIQueryableUserStore", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a Store does not implement IRoleClaimStore&lt;TRole&gt;..
        /// </summary>
        public static string StoreNotIRoleClaimStore {
            get {
                return ResourceManager.GetString("StoreNotIRoleClaimStore", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a Store does not implement IUserAuthenticationTokenStore&lt;User&gt;..
        /// </summary>
        public static string StoreNotIUserAuthenticationTokenStore {
            get {
                return ResourceManager.GetString("StoreNotIUserAuthenticationTokenStore", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a Store does not implement IUserAuthenticatorKeyStore&lt;User&gt;..
        /// </summary>
        public static string StoreNotIUserAuthenticatorKeyStore {
            get {
                return ResourceManager.GetString("StoreNotIUserAuthenticatorKeyStore", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a Store does not implement IUserClaimStore&lt;TUser&gt;..
        /// </summary>
        public static string StoreNotIUserClaimStore {
            get {
                return ResourceManager.GetString("StoreNotIUserClaimStore", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a Store does not implement IUserConfirmationStore&lt;TUser&gt;..
        /// </summary>
        public static string StoreNotIUserConfirmationStore {
            get {
                return ResourceManager.GetString("StoreNotIUserConfirmationStore", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a Store does not implement IUserEmailStore&lt;TUser&gt;..
        /// </summary>
        public static string StoreNotIUserEmailStore {
            get {
                return ResourceManager.GetString("StoreNotIUserEmailStore", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a Store does not implement IUserLockoutStore&lt;TUser&gt;..
        /// </summary>
        public static string StoreNotIUserLockoutStore {
            get {
                return ResourceManager.GetString("StoreNotIUserLockoutStore", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a Store does not implement IUserLoginStore&lt;TUser&gt;..
        /// </summary>
        public static string StoreNotIUserLoginStore {
            get {
                return ResourceManager.GetString("StoreNotIUserLoginStore", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a Store does not implement IUserPasswordStore&lt;TUser&gt;..
        /// </summary>
        public static string StoreNotIUserPasswordStore {
            get {
                return ResourceManager.GetString("StoreNotIUserPasswordStore", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a Store does not implement IUserPhoneNumberStore&lt;TUser&gt;..
        /// </summary>
        public static string StoreNotIUserPhoneNumberStore {
            get {
                return ResourceManager.GetString("StoreNotIUserPhoneNumberStore", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a Store does not implement IUserRoleStore&lt;TUser&gt;..
        /// </summary>
        public static string StoreNotIUserRoleStore {
            get {
                return ResourceManager.GetString("StoreNotIUserRoleStore", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a Store does not implement IUserSecurityStampStore&lt;TUser&gt;..
        /// </summary>
        public static string StoreNotIUserSecurityStampStore {
            get {
                return ResourceManager.GetString("StoreNotIUserSecurityStampStore", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a Store does not implement IUserTwoFactorRecoveryCodeStore&lt;User&gt;..
        /// </summary>
        public static string StoreNotIUserTwoFactorRecoveryCodeStore {
            get {
                return ResourceManager.GetString("StoreNotIUserTwoFactorRecoveryCodeStore", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a Store does not implement IUserTwoFactorStore&lt;TUser&gt;..
        /// </summary>
        public static string StoreNotIUserTwoFactorStore {
            get {
                return ResourceManager.GetString("StoreNotIUserTwoFactorStore", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a User already has a password set..
        /// </summary>
        public static string UserAlreadyHasPassword {
            get {
                return ResourceManager.GetString("UserAlreadyHasPassword", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a User already in role &apos;{0}&apos;..
        /// </summary>
        public static string UserAlreadyInRole {
            get {
                return ResourceManager.GetString("UserAlreadyInRole", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a User is locked out..
        /// </summary>
        public static string UserLockedOut {
            get {
                return ResourceManager.GetString("UserLockedOut", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a Lockout is not enabled for this user..
        /// </summary>
        public static string UserLockoutNotEnabled {
            get {
                return ResourceManager.GetString("UserLockoutNotEnabled", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a User {0} does not exist..
        /// </summary>
        public static string UserNameNotFound {
            get {
                return ResourceManager.GetString("UserNameNotFound", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a User is not in role &apos;{0}&apos;..
        /// </summary>
        public static string UserNotInRole {
            get {
                return ResourceManager.GetString("UserNotInRole", resourceCulture);
            }
        }
    }
}
