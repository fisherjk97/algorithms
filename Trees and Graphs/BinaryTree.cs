using System;
using System.Collections.Generic;

namespace Algorithms.BinaryTree
{
    public class BinaryTree<T> : IEnumerable<T> where T: IComparable<T>
    {
        private BinaryTreeNode<T> _head;
        private int _count;

        #region Add

        /// <summary>
        /// Adds the provided value to the binary tree
        /// </summary>
        /// <param name="value"></param>
        public void Add(T value){
            //Case 1: The tree is empty - allocate the head
            if(_head == null){
                _head = new BinaryTreeNode<T>(value);
            }else{
            //Case 2: The tree is not empty so find the right location to insert
                AddTo(_head, value);
            
            }
        }

        /// <summary>
        /// Recursive add algorithm
        /// </summary>
        /// <param name="node"></param>
        /// <param name="value"></param>
        private void AddTo(BinaryTreeNode<T> node, T value){
            //Case 1: Value is less than the current node value
            if(value.CompareTo(node.Value) < 0){
                //if there is no left child, make this the new left 
                if(node.Left == null){
                    node.Left = new BinaryTreeNode<T>(value);
                }else{
                    //else add it to the left node
                    AddTo(node.Left, value);
                }
            }else {

            //Case 2: Value is equal to or greater than the current value
                if(node.Right == null){
                    node.Right = new BinaryTreeNode<T>(value);
                }else{
                    //else add it to the right node
                    AddTo(node.Right, value);
                }
            }
        }

        #endregion


        /// <summary>
        /// Determines if hte specified value exists in the binary tree
        /// </summary>
        /// <param name="value">The value to search for</param>
        /// <returns>True if the tree contains the value, false otherwise</returns>
        public bool Contains(T value){
            //defer to the node search helper function
            BinaryTreeNode<T> parent;
            return FindWithParent(value, out parent) != null;
        }

        /// <summary>
        /// Finds and returns the first node containing the specified value.null 
        /// If the value is not found, return null
        /// Also returns the parent of the found node (or null) which is used in Remove
        /// </summary>
        /// <param name="value">The value to search for</param>
        /// <param name="parent">The parent of the found node</param>
        /// <returns>The found node (or null)</returns>
        private BinaryTreeNode<T> FindWithParent(T value, out BinaryTreeNode<T> parent){
            //Now, try to find the data in the tree
            //always start with the head of the tree
            BinaryTreeNode<T> current = _head;

            parent = null;

            //while we don't have a match
            while(current != null){
                int result = current.CompareTo(value);

                if(result > 0){
                    //if the value is less than current, go left
                    parent = current;
                    current = current.Left;
                
                }else if (result < 0)
                {
                    //if the value is more than current, go right
                    parent = current;
                    current = current.Right;
                }else{
                    //we have a match
                    break;
                }
            }

            return current;
        }

        #region Remove

        /// <summary>
        /// Removes the first occurence of the specified value from the tree
        /// </summary>
        /// <param name="value">The value to remove</param>
        /// <returns>True if hte value was removed, false otherwise</returns>
        public bool Remove(T value){
            BinaryTreeNode<T> current, parent;

            //try to find the node to remove
            current = FindWithParent(value, out parent);

            //couldn't find the node to remove
            if(current == null){
                return false;
            }

            _count--;

            //Case 1: If the current has no right child, then the current's left replaces the current
            if(current.Right == null){
                if(parent == null){
                    //removing the root node, now promote left child to root node
                    _head = current.Left;
                }else{
                    //determine which parent link we're updating
                    int result = parent.CompareTo(current.Value);
                    if(result > 0){
                        //if parent value is greater than current value
                        //make the current left child a left child of the parent
                        parent.Left = current.Left;
                    }else if(result < 0){
                        //if parent value is less than current value
                        //make the current left child a right child of parent
                        parent.Right = current.Left;
                    }
                }
            }

            //Case 2: If the current's right child has no left child, then current's right child
            else if(current.Right.Left == null){
                current.Right.Left = current.Left;
                //removing the root node, now promote right child to root node
                if(parent == null){
                    _head = current.Right;
                }else{
                    //determine which parent link we're updating
                    int result = parent.CompareTo(current.Value);
                    if(result > 0){
                        //if parent value is greater than current value
                        //make the current right child a left child of the parent
                        parent.Left = current.Right;
                    }else if(result < 0){
                        //if parent value is less than current value
                        //make the current right child a right child of parent
                        parent.Right = current.Right;
                    }
                }
            }else{
                //Case 3: If the current's right child has a left child, replace current with current's right child's left-most child
            
                //find the right's left-most child
                BinaryTreeNode<T> leftmost = current.Right.Left;
                BinaryTreeNode<T> leftmostParent = current.Right;

                //while there's still a child to the left, keep going left
                while(leftmost.Left != null){
                    leftmostParent = leftmost;
                    leftmost = leftmost.Left;
                }

                //the parent's left subtree become's the leftmost's right subtree
                leftmostParent.Left  = leftmost.Right;

                //assign leftmost's left and right child to the current's left and right children
                leftmost.Left = current.Left;
                leftmost.Right = current.Right;

                if(parent == null){
                    _head = leftmost;
                }else{
                    //determine which parent link we're updating
                    int result = parent.CompareTo(current.Value);
                    if(result > 0){
                        //if parent value is greater than current value
                        //make the leftmost the parent's left child
                        parent.Left = leftmost;
                    }else if(result < 0){
                        //if parent value is less than current value
                        //make the leftmost the parent's right child
                        parent.Right = leftmost;
                    }
                }
            }

            return true;

        }

        #endregion


        #region Pre-Order Traversal

        /// <summary>
        /// Performs the provided action on each binary tree value in pre-order traversal order
        /// </summary>
        /// <param name="action">The action to perform</param>
        public void PreOrderTraversal(Action<T> action){
            PreOrderTraversal(action, _head);
        }

        private void PreOrderTraversal(Action<T> action, BinaryTreeNode<T> node){
            if(node != null){
                action(node.Value);//process the node
                PreOrderTraversal(action, node.Left);//go left
                PreOrderTraversal(action, node.Right);//go right
            }
        }

        #endregion


        #region Post-Order Traversal

        /// <summary>
        /// Performs the provided action on each binary tree value in post-order traversal order
        /// </summary>
        /// <param name="action">The action to perform</param>
        public void PostOrderTraversal(Action<T> action){
            PostOrderTraversal(action, _head);
        }

        private void PostOrderTraversal(Action<T> action, BinaryTreeNode<T> node){
            if(node != null){
                PostOrderTraversal(action, node.Left);//go left
                PostOrderTraversal(action, node.Right);//go right
                action(node.Value);//process node
            }
        }


        #endregion


        #region In-Order Traversal

        /// <summary>
        /// Performs the provided action on each binary tree value in in-order traversal order
        /// </summary>
        /// <param name="action">The action to perform</param>
        public void InOrderTraversal(Action<T> action){
            InOrderTraversal(action, _head);
        }

        private void InOrderTraversal(Action<T> action, BinaryTreeNode<T> node){
            if(node != null){
                InOrderTraversal(action, node.Left);//go left
                action(node.Value);//process node
                InOrderTraversal(action, node.Right);//go right
            }
        }


        /// <summary>
        /// Enumerates the values contained in a binary tree in in-order traversal (without recursion)
        /// Memory constaint problem instead of runtime stack problem
        /// </summary>
        /// <returns></returns>
        public IEnumerator<T> InOrderTraversal(){
            //This iss a non-recursive algorithm using a stack to demonstrate removing recursion to make the yield syntax easier

            if(_head != null){
                //store the nodes we'e skipped in the this stack (avoid recursion)
                Stack<BinaryTreeNode<T>> stack = new Stack<BinaryTreeNode<T>>();

                BinaryTreeNode<T> current = _head;

                //when removing recursion we need to keep track of whether or not
                //we should be going to the left node or the right nodes next
                bool goLeftNext = true;

                //start by pushing the head onto the stack

                stack.Push(current);

                //while we haven't removed everything from the stack
                while(stack.Count > 0){
                    //if we're heading left...
                    if(goLeftNext){
                        //push evcerything but the left-most node to the stack
                        //we'll yield the left-most after this block

                        while(current.Left != null){
                            stack.Push(current);
                            current = current.Left;
                        }
                        
                    }

                    //in-order is left->yield->right

                    yield return current.Value;//return this value as part of an enumerator


                    //if we can go right then do so
                    if(current.Right != null){
                        current = current.Right;

                        //once we've gone right once, we need to start going left again
                        goLeftNext = true;

                    }else{
                        //if we can't go right then we need to pop off the parent node
                        //so we can process it and then go to it's right node

                        current = stack.Pop();
                        goLeftNext = false;
                    
                    }
                }
            }
        }

        

        /// <summary>
        /// Returns the enumerator that performs an in-order traversal of the binary tree
        /// </summary>
        /// <returns></returns>
        public IEnumerator<T> GetEnumerator(){
            return InOrderTraversal();
        }


        /// <summary>
        /// Returns an enumerator that performs an in-order traversal of the binary tree
        /// </summary>
        /// <returns></returns>
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator(){
            return GetEnumerator();
        }

        #endregion

        /// <summary>
        /// Removes all items from the tree
        /// </summary>
        public void Clear(){
            _head = null;
            _count = 0;
        }

        /// <summary>
        /// Returns the number of items currentlyu contained in the tree
        /// </summary>
        /// <value></value>
        public int Count 
        {
            get {
                return _count;
            }
        }


    }
}