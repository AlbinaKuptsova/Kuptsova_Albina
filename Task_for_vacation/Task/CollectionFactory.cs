using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task
{
    public enum CollectionType
    {
        Array,
        References
    }

    public static class CollectionFactory
    {
        public static IAList<T> CreateAList<T>(CollectionType collectionType, int arraySize)
        {
            switch (collectionType)
            {
                case CollectionType.Array:
                    return new MyArrayList<T>(arraySize);
                case CollectionType.References:
                    return new MyReferenceList<T>();
            }
            return null;
        }

        public static IAQueue<T> CreateAQueue<T>(CollectionType collectionType, int arraySize)
        {
            switch (collectionType)
            {
                case CollectionType.Array:
                    return new MyArrayQueue<T>(arraySize);
                case CollectionType.References:
                    return new MyReferenceQueue<T>();
            }
            return null;
        }

        public static IAStack<T> CreateAStack<T>(CollectionType collectionType, int arraySize)
        {
            switch (collectionType)
            {
                case CollectionType.Array:
                    return new MyArrayStack<T>(arraySize);
                case CollectionType.References:
                    return new MyReferenceStack<T>();
            }
            return null;
        }
    }
}
