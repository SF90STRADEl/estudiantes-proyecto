using System;

namespace StudentManagementSystem
{
    public class BST<TKey, TData> where TKey : IComparable<TKey>
    {
        private class Node
        {
            public TKey Key { get; }
            public TData Data { get; set; }
            public Node Left;
            public Node Right;

            public Node(TKey key, TData data) => (Key, Data) = (key, data);
        }

        private Node root;

        public void Insert(TKey key, TData data) => root = InsertRec(root, key, data);

        private Node InsertRec(Node node, TKey key, TData data)
        {
            if (node == null) return new Node(key, data);
            int cmp = key.CompareTo(node.Key);
            if (cmp < 0) node.Left = InsertRec(node.Left, key, data);
            else if (cmp > 0) node.Right = InsertRec(node.Right, key, data);
            return node;
        }

        public TData Search(TKey key) => SearchRec(root, key);

        private TData SearchRec(Node node, TKey key)
        {
            if (node == null) return default;
            int cmp = key.CompareTo(node.Key);
            return cmp == 0 ? node.Data : cmp < 0 ? SearchRec(node.Left, key) : SearchRec(node.Right, key);
        }

        public void InsertOrUpdate(TKey key, TData data, Func<TData, TData> updateFunc)
        {
            root = InsertOrUpdateRec(root, key, data, updateFunc);
        }

        private Node InsertOrUpdateRec(Node node, TKey key, TData data, Func<TData, TData> updateFunc)
        {
            if (node == null) return new Node(key, data);
            int cmp = key.CompareTo(node.Key);
            if (cmp < 0) node.Left = InsertOrUpdateRec(node.Left, key, data, updateFunc);
            else if (cmp > 0) node.Right = InsertOrUpdateRec(node.Right, key, data, updateFunc);
            else node.Data = updateFunc(node.Data);
            return node;
        }
    }
}
