using System;
using System.Diagnostics;

namespace Algorithms
{

        class Node
        {
            public int value;
            public Node left;
            public Node right;

        }

        class Tree {
            public Node Insert(Node root, int v){

                if(root == null){
                    root = new Node();
                    root.value = v;
                   
                }else if(v < root.value){
                    root.left = Insert(root.left, v);
                }else {
                    root.right = Insert(root.right, v);
                }

                return root;
            }
        
        public void Visit(Node node){
            Console.WriteLine("Node value: " + node.value);
        }

        public void Traverse(Node root){
            if(root == null){
                return;
            }

            Traverse(root.left);
            Traverse(root.right);
        }

        /// <summary>
        /// Visit the left branch, then the current node, and finally the right branch
        /// </summary>
        /// <param name="node"></param>
        public void InOrderTraversal(Node node){
            if(node != null){
                InOrderTraversal(node.left);
                Visit(node);
                InOrderTraversal(node.right);
            }
        }

        /// <summary>
        /// Visit the current node before it's child nodes
        /// </summary>
        /// <param name="node"></param>
        public void PreOrderTraversal(Node node){
            if(node != null){
                Visit(node);
                InOrderTraversal(node.left);
                InOrderTraversal(node.right);
            }
        }

        /// <summary>
        /// Visit the current node after it's child nodes
        /// </summary>
        /// <param name="node"></param>
        public void PostOrderTraversal(Node node){
            if(node != null){
                InOrderTraversal(node.left);
                InOrderTraversal(node.right);
                Visit(node);
            }
        }


        }
        
       class BinarySearchTree {


         

            public static void Test(int size){
                Node root = null;
                Tree bst = new Tree();
                int[] a = new int[size];

                Random random = new Random();
                //generate numbers
                for (int i = 0; i < size; i++)
                {
                    a[i] = random.Next(10000);
                }
                //fill up tree
                for (int i = 0; i < size; i++)
                {
                    root = bst.Insert(root, a[i]);
                    if(i ==0){
                         Console.WriteLine("Root Node: " + a[i]);
                    }
                }

                Console.WriteLine("Traverse Tree");
                bst.Traverse(root);

                Console.WriteLine("In Order Tree Traversal");
                bst.InOrderTraversal(root);

                Console.WriteLine("Pre Order Tree Traversal");
                bst.PreOrderTraversal(root);

                Console.WriteLine("Post Order Tree Traversal");
                bst.PostOrderTraversal(root);
                
            }
       }
        
}