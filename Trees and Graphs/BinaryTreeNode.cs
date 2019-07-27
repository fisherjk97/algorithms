using System;

namespace Algorithms.BinaryTree
{
    /* This example is from Pluralsight Course "Introuction to Algorithms and Data Structures - Part 1 by Robert Horvick */
    /// <summary>
    /// A binary tree node class - encapsulates the value left/right pointers
    /// </summary>
    public class BinaryTreeNode<TNode> : IComparable<TNode>
        where TNode : IComparable<TNode>
    {
        public BinaryTreeNode(TNode value){
           
        }

        /// <summary>
        /// left child
        /// </summary>
        /// <value></value>
        public BinaryTreeNode<TNode> Left {get; set; }

        /// <summary>
        /// right child
        /// </summary>
        /// <value></value>
        public BinaryTreeNode<TNode> Right {get; set; }

        public TNode Value {get; private set;}

        /// <summary>
        /// Compares the current node to the provided value
        /// </summary>
        /// <param name="other">The node value to compare to</param>
        /// <returns>1 if the instance value is greater than the provided value, -1 if less than provided value, or 0 if equal.</returns>
        public int CompareTo(TNode other){
            return Value.CompareTo(other);
        }
    }
}