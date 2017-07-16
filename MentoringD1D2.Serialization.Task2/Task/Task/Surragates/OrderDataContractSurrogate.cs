using System;
using System.CodeDom;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using Task.DB;

namespace Task.Surragates
{
    public class OrderDataContractSurrogate : IDataContractSurrogate
    {
        private Order orederResult;
        public Type GetDataContractType(Type type)
        {
            return type;
        }

        public object GetObjectToSerialize(object obj, Type targetType)
        {
            
            if (obj is Order)
            {
                Order order = obj as Order;
                orederResult = new Order
                {
                    OrderID = order.OrderID,
                    CustomerID = order.CustomerID,
                    OrderDate = order.OrderDate,
                    RequiredDate = order.RequiredDate
                 };

                if (order.Order_Details != null)
                {
                    orederResult.Order_Details = order.Order_Details.Select(detail => new Order_Detail() { OrderID = detail.OrderID, Discount = detail.Discount, ProductID = detail.ProductID, UnitPrice = detail.UnitPrice }).ToList();
                }

                return orederResult;
            }

            return obj;
        }

        public object GetDeserializedObject(object obj, Type targetType)
        {
            return GetObjectToSerialize(obj, targetType);
        }

        #region Not Implemented Memnders
        public object GetCustomDataToExport(MemberInfo memberInfo, Type dataContractType)
        {
            throw new NotImplementedException();
        }

        public object GetCustomDataToExport(Type clrType, Type dataContractType)
        {
            throw new NotImplementedException();
        }

        public void GetKnownCustomDataTypes(Collection<Type> customDataTypes)
        {
            throw new NotImplementedException();
        }

        public Type GetReferencedTypeOnImport(string typeName, string typeNamespace, object customData)
        {
            throw new NotImplementedException();
        }

        public CodeTypeDeclaration ProcessImportedType(CodeTypeDeclaration typeDeclaration, CodeCompileUnit compileUnit)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
