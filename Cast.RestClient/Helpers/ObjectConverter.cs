using System.Collections;

namespace Cast.RestClient.Helpers
{
    internal static class ObjectConverter
    {
        internal static IList ArrayObjectToGenericList(object values)
        {
            Ensure.IsArray(values, nameof(values));

            dynamic array = values;

            if (array!.Length == 0)
            {
                return new List<object>();
            }

            var elemType = array!.GetType().GetElementType();
            var genericList = typeof(List<>).MakeGenericType(elemType);
            var instance = (IList)Activator.CreateInstance(genericList);

            for (int i = 0; i < array.Length; i++)
            {
                instance.Add(array[i]);
            }

            return instance;
        }
    }
}
