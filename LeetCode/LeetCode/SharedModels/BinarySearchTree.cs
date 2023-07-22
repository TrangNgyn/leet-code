using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.SharedModels
{
    public class TreeNode
    {
        public int Key { get; set; }
        public int? Value { get; set; }
        public TreeNode Left { get; set; }
        public TreeNode Right { get; set; }

        public TreeNode()
        {

        }
        public TreeNode(int key, int? value = null)
        {
            Key = key;
            Value = value;
            Left = Right = null;
        }
    }

    public class BinarySearchTree
    {
        public TreeNode Root;

        public BinarySearchTree()
        {
            Root = null;
        }

        public BinarySearchTree(int rootKey, int? rootValue = null)
        {
            Root = new TreeNode(rootKey, rootValue);
        }

        public void Add(int key)
        {
            Root = AddTosubtree(Root, key);
        }

        public void Add(int key, int value)
        {
            Root = AddTosubtree(Root, key, value);
        }

        private TreeNode AddTosubtree(TreeNode root, int key, int? value = null)
        {
            // if node's parent is a leaf node
            if (root == null)
            {
                root = new TreeNode(key, value);

                return root;
            }

            if (root.Key == key)
            {
                root.Value = value;
                return root;
            }

            // traverse the tree recursively
            if (key < root.Key)
            {
                root.Left = AddTosubtree(root.Left, key, value);
            }
            else if (key > root.Key)
            {
                root.Right = AddTosubtree(root.Right, key, value);
            }

            return root;
        }

        public bool Contains(int key)
        {
            var target = SearchNode(Root, key);
            return target != null;
        }

        public int Search(int key)
        {
            var target = SearchNode(Root, key);
            return target != null ? target.Value.Value : -1;
        }

        private TreeNode SearchNode(TreeNode node, int key)
        {
            // base case: tree is empty or key is found
            if (node == null || node.Key == key)
            {
                return node;
            }

            // traverse the tree
            if (key < node.Key)
            {
                return SearchNode(node.Left, key);
            }

            return SearchNode(node.Right, key);
        }

        public void Remove(int key)
        {
            Root = RemoveFromSubtree(Root, key);
        }

        /* case 1 - base case: tree is emoty
         * 
         * case 2: delete leaf node
         *  find the node to be deleted recursvely and simply delete it
         * 
         * case 3: delete node with 1 child
         *  delete the node and replace it with it's only child
         * 
         * case 4: delete node with 2 children
         *  find the in-order successor of the subtree
         *  if in-order sucessor exists:
         *   - replace the successor with its right child (if any)
         *   - replace the deleted node with the sucessor
         *  if no in-order successor (the deleted node's right child only has a right child)
         *   - replace the right child with its right child (shifting the right subtree up)
         *   - replace the delete node with its right child
         */
        private TreeNode RemoveFromSubtree(TreeNode root, int key)
        {

            if (root == null)
            {
                return root;
            }

            // find node to remove recursively
            if (key < root.Key)
            {
                root = RemoveFromSubtree(root.Left, key);
                return root;
            }
            else if (key > root.Key)
            {
                root = RemoveFromSubtree(root.Right, key);
                return root;
            }

            /* If the deleted node only has one child
             * delete node and replace it with its child
             */
            if (root.Left == null)
            {
                var rightChild = root.Right;
                root = null;
                return rightChild;
            }
            else if (root.Right == null)
            {
                var leftChild = root.Left;
                root = null;
                return leftChild;
            }
            // Node has 2 children
            else
            {
                // find the in-order successor
                var successorParent = root;
                var successor = root.Right; // successor is in the right sub-tree

                while (successor.Left != null) // traverse to the left leaf of the subtree
                {
                    successorParent = successor;
                    successor = successor.Left;
                }

                /* if successor exists (successor parent shifted)
                 * make successor's right child as the left child of its parent
                 * (replace successor with its right child)
                 */
                if (successorParent != root)
                {
                    successorParent.Left = successor.Right;
                }
                else
                {
                    // make successor's right child as its parent's right child
                    // (replace the node with its right child - moving the right subtree up)
                    successorParent.Right = successor.Right;
                }

                // replace the deleted node with its successor
                root.Key = successor.Key;
                root.Value = successor.Value;

                // delete the successor and return the new root
                successor = null;
                return root;
            }
        }
    }
}
