using System;
using System.Collections.Generic;
using System.Reflection;

namespace URFU.ASOAD.Tests
{
    /// <summary>
    /// Предназначен для генерации тестовых объектов с заполненными данными. Делает следующие:
    /// Заполняет поля с простыми типами данных, понимает ссылки на сложные типы, понимает массивы, понимает перечисления, исключает односложные рекурсии (ссылки на самого себя или на массивы со своим типом),
    /// игнорирует коллекции (генератор кода в данный момент не генерирует коллекции, а только массивы)
    /// todo доработать, чтобы генерил коллекции
    /// </summary>
    internal class DataGenerator
    {
        /// <summary>
        /// Предназначен для установки значения поля с простым типом данных
        /// </summary>
        private interface IGeneratePropertyAction
        {
            void DoAction(object siteObject, PropertyInfo propertyInfo, DataGenerator dataGenerator);
        }

        private class GenerateBoolPropertyAction : IGeneratePropertyAction
        {
            public void DoAction(object siteObject, PropertyInfo propertyInfo, DataGenerator dataGenerator)
            {
                propertyInfo.SetValue(siteObject, true, null);
            }
        }

        private class GenerateBytePropertyAction : IGeneratePropertyAction
        {
            public void DoAction(object siteObject, PropertyInfo propertyInfo, DataGenerator dataGenerator)
            {
                propertyInfo.SetValue(siteObject, (byte)7, null);
            }
        }

        private class GenerateByteArrayPropertyAction : IGeneratePropertyAction
        {
            public void DoAction(object siteObject, PropertyInfo propertyInfo, DataGenerator dataGenerator)
            {
                propertyInfo.SetValue(siteObject, new[] { (byte)7 }, null);
            }
        }

        private class GenerateDateTimePropertyAction : IGeneratePropertyAction
        {
            public void DoAction(object siteObject, PropertyInfo propertyInfo, DataGenerator dataGenerator)
            {
                DateTime time = DateTime.SpecifyKind(dataGenerator.BeginTime, DateTimeKind.Utc);
                dataGenerator.BeginTime = time.AddMinutes(1);
                propertyInfo.SetValue(siteObject, time, null);
            }
        }

        private class GenerateStringPropertyAction : IGeneratePropertyAction
        {
            public void DoAction(object siteObject, PropertyInfo propertyInfo, DataGenerator dataGenerator)
            {
                if (propertyInfo.CanWrite)
                {
                    propertyInfo.SetValue(siteObject, Guid.NewGuid().ToString(), null);
                }
            }
        }

        private class GenerateIntegerPropertyAction : IGeneratePropertyAction
        {
            public void DoAction(object siteObject, PropertyInfo propertyInfo, DataGenerator dataGenerator)
            {
                propertyInfo.SetValue(siteObject, 12, null);
            }
        }

        private class GenerateUIntPropertyAction : IGeneratePropertyAction
        {
            public void DoAction(object siteObject, PropertyInfo propertyInfo, DataGenerator dataGenerator)
            {
                propertyInfo.SetValue(siteObject, (uint)12, null);
            }
        }

        private class GenerateUShortPropertyAction : IGeneratePropertyAction
        {
            public void DoAction(object siteObject, PropertyInfo propertyInfo, DataGenerator dataGenerator)
            {
                propertyInfo.SetValue(siteObject, (ushort)12, null);
            }
        }

        private class GenerateDoublePropertyAction : IGeneratePropertyAction
        {
            public void DoAction(object siteObject, PropertyInfo propertyInfo, DataGenerator dataGenerator)
            {
                propertyInfo.SetValue(siteObject, new Random().Next(int.MaxValue), null);
            }
        }

        private class GenerateFloatPropertyAction : IGeneratePropertyAction
        {
            public void DoAction(object siteObject, PropertyInfo propertyInfo, DataGenerator dataGenerator)
            {
                propertyInfo.SetValue(siteObject, 12.35f, null);
            }
        }

        private static readonly Dictionary<Type, IGeneratePropertyAction> propertyActions = new Dictionary<Type, IGeneratePropertyAction>
        {
            { typeof(byte), new GenerateBytePropertyAction() }, 
            { typeof(byte[]), new GenerateByteArrayPropertyAction() }, 
            { typeof(bool), new GenerateBoolPropertyAction() }, 
            { typeof(DateTime), new GenerateDateTimePropertyAction() }, 
            { typeof(string), new GenerateStringPropertyAction() },
            { typeof(int), new GenerateIntegerPropertyAction() }, 
            { typeof(uint), new GenerateUIntPropertyAction() }, 
            { typeof(ushort), new GenerateUShortPropertyAction() }, 
            { typeof(float), new GenerateFloatPropertyAction() }, 
            { typeof(double), new GenerateDoublePropertyAction() }
        };

        public DataGenerator()
        {
            BeginTime = DateTime.Now;
        }

        public DateTime BeginTime { get; set; }

        public int CountElementsInArray { get; set; }

        public object Generate(Type type)
        {
            if(type.Equals(typeof(object)))
            {
                return null;
            }
            if (type.IsArray)
            {
                return GenerateArray(type);
            }
            if (type.IsEnum)
            {
                return Enum.GetValues(type).GetValue(0);
            }
            object generated = CreateInstanceFromDefaultConstructor(type);
            FillObject(generated);
            return generated;
        }

        public void FillObject(object obj)
        {
            foreach (PropertyInfo propertyInfo in obj.GetType().GetProperties())
            {
                if (propertyInfo.CanWrite)
                {
                    GenerateSingleProperty(propertyInfo, obj);
                }
            }
        }

        private object GenerateArray(Type arrayType)
        {
            Type elementType = GetElementTypeFromArrayType(arrayType);
            Array array = Array.CreateInstance(elementType, CountElementsInArray);
            for (int index = 0; index < CountElementsInArray; ++index)
            {
                array.SetValue(Generate(elementType), index);
            }
            return array;
        }

        private Type GetElementTypeFromArrayType(Type type)
        {
            string name = type.FullName;
            if (name != null)
            {
                name = name.Substring(0, name.LastIndexOf("[]"));
            }
            return Assembly.GetAssembly(type).GetType(name);
        }

        private object CreateInstanceFromDefaultConstructor(Type type)
        {
            if(type.Equals(typeof(string)))
            {
                return Guid.NewGuid().ToString();
            }

            ConstructorInfo constructor = type.GetConstructor(new Type[] { });
            if (constructor == null)
            {
                throw new Exception(String.Format("Не найден конструктор по умолчанию для типа {0}", type.FullName));
            }
            return constructor.Invoke(null);
        }

        private void GenerateSingleProperty(PropertyInfo propertyInfo, object generated)
        {
            Type propertyType = propertyInfo.PropertyType;
            if (propertyType == generated.GetType() || (propertyType.IsArray && GetElementTypeFromArrayType(propertyType) == generated.GetType()))
            {
                return;
            }
            try
            {
                IGeneratePropertyAction action = propertyActions[propertyType];
                action.DoAction(generated, propertyInfo, this);
            }
            catch (KeyNotFoundException)
            {
                if (!propertyType.IsGenericType)
                {
                    propertyInfo.SetValue(generated, Generate(propertyType), null);
                }
                //throw new Exception(String.Format("Не найден обработчик поля {0} типа {1}. Владеющий класс - {2}", propertyInfo.Name,  propertyInfo.PropertyType.FullName, type.FullName));
            }
        }
    }
}
