using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

using URFU.ASOAD.Core.Exceptions;

namespace URFU.ASOAD.Core
{
    public static class ObjectUtils
    {
        /// <summary>
        /// Десериализация бинарного представления объекта
        /// </summary>
        /// <typeparam name="T">тип объекта</typeparam>
        /// <param name="data">сериализованный объект</param>
        /// <returns>десериализованный объект</returns>
        public static T Deserialize<T>(byte[] data)
        {
            try
            {
                using (Stream stream = new MemoryStream(data))
                {
                    return (T)new BinaryFormatter().Deserialize(stream);
                }
            }
            catch (Exception exception)
            {
                throw new InternalException(ErrorCode.DeserializeException, typeof(T).Name, exception);
            }
        }

        /// <summary>
        /// Сериализация объекта в бинарное представление
        /// </summary>
        /// <param name="obj">объект</param>
        /// <returns>сериализованное представление объекта</returns>
        public static byte[] Serialize(object obj)
        {
            try
            {
                using (MemoryStream stream = new MemoryStream())
                {
                    new BinaryFormatter().Serialize(stream, obj);
                    return stream.ToArray();
                }
            }
            catch (Exception exception)
            {
                throw new InternalException(ErrorCode.SerializeException, obj.GetType(), exception);
            }
        }

        /// <summary>
        /// Возвращает имя метода из которого был вызван метод, где есть этот вызов
        /// </summary>
        /// <returns>имя метода, из которого был вызван данный метод</returns>
        public static string CallerMethodName()
        {
            return new StackTrace(0).GetFrame(2).GetMethod().Name;
        }
    }
}
