using System;

namespace BTree
{
    class Program
    {
        static void Main(string[] args)
        {
            var tree = new BTree();
            tree.Add(10);
            tree.Add(5);
            tree.Add(20);
            tree.Add(2);
            tree.Add(7);
            tree.Add(15);
            tree.Add(21);
          
            tree.Traverse();

            Console.ReadKey();
        }
    }

    class Node
    {
        public int Value { get; private set; }
        public Node Left { get; set; }
        public Node Right { get; set; }
        public Node(int value)
        {
            Value = value;
        }
    }

    class BTree {
        Node root;

        public void Add(int value) {
            if (root == null) {
                root = new Node(value);
                return;
            }
            var newNode = new Node(value);
            var current = root;
            var parent = root;
            bool isLeft = true;
            while (current != null) {
                parent = current;
                if (value < current.Value) {
                    current = current.Left;
                    isLeft = true;
                } else {
                    current = current.Right;
                    isLeft = false;
                }
            }
            if (isLeft) {
                parent.Left = newNode;
            } else {
                parent.Right = newNode;
            }
        }

        public void Traverse() {
            this.InternalTraverse(root);
        }

        private void InternalTraverse(Node node) {
            if (node == null) {
                return;
            }
            System.Console.WriteLine(node.Value);
            this.InternalTraverse(node.Left);
            this.InternalTraverse(node.Right);
        }
    }
}
