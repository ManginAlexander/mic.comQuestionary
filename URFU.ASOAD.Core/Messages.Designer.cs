﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.269
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace URFU.ASOAD.Core {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public class Messages {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Messages() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("URFU.ASOAD.Core.Messages", typeof(Messages).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
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
        ///   Looks up a localized string similar to Невозможно изменить объект {0}, который ещё не был сохранён в хранилище.
        /// </summary>
        public static string CanNotChangeUnsavedObject {
            get {
                return ResourceManager.GetString("CanNotChangeUnsavedObject", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Невозможно загрузить хранилище &quot;{0}&quot; по причине: {1}.
        /// </summary>
        public static string CanNotLoadRepository {
            get {
                return ResourceManager.GetString("CanNotLoadRepository", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Невозможно сохранить хранилище &quot;{0}&quot; по причине: {1}.
        /// </summary>
        public static string CanNotSaveRepository {
            get {
                return ResourceManager.GetString("CanNotSaveRepository", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Ошибка при работе с хранилищем данных: {0}.
        /// </summary>
        public static string DaoException {
            get {
                return ResourceManager.GetString("DaoException", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Ошибка при десериализации объекта типа {0}: {1}.
        /// </summary>
        public static string DeserializeException {
            get {
                return ResourceManager.GetString("DeserializeException", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Не найдено сообщение для кода ошибки {0}.
        /// </summary>
        public static string ErrorMessageNotFound {
            get {
                return ResourceManager.GetString("ErrorMessageNotFound", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to В процессе обработки запроса {0} перехвачено исключение: {1}.
        /// </summary>
        public static string HandleException {
            get {
                return ResourceManager.GetString("HandleException", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to {0}.
        /// </summary>
        public static string Message {
            get {
                return ResourceManager.GetString("Message", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Объект {0} с идентификатором &apos;{1}&apos; не найден в хранилище.
        /// </summary>
        public static string ObjectNotFound {
            get {
                return ResourceManager.GetString("ObjectNotFound", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Анкета &quot;{0}&quot; уже существует в хранилище.
        /// </summary>
        public static string ObjectNotUnique {
            get {
                return ResourceManager.GetString("ObjectNotUnique", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Ошибка при сериализации объекта типа {0}: {1}.
        /// </summary>
        public static string SerializeException {
            get {
                return ResourceManager.GetString("SerializeException", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to При проверке правильности заполнения анкеты обнаружены ошибки: {0}.
        /// </summary>
        public static string ValidationError {
            get {
                return ResourceManager.GetString("ValidationError", resourceCulture);
            }
        }
    }
}
