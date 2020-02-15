using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;


//namespace hw1
//{
//
//    public class Node
//    {
//        public List<Node> m_Children;
//        //public Node m_parent;
//        public string type;
//        public Direction direction;
//        public string stringValue;
//        public int depth;
//        public Node()
//        {
//            m_Children = null;
//            type = null;
//            direction;
//            stringValue = null;
//            depth = -1;
//        }
//
//        public Node(Node n)
//        {
//        }
//
//    }
//    class Tree
//    {
//
//        public Node m_root;
//        public int maxdepth;
//        public int deepestDepth;
//        public struct Solution
//        {
//            public List<string> Data;
//            public Solution(List<string> d, int s)
//            {
//                Data = d;
//                Score = s;
//            }
//            public Solution(Solution s)
//            {
//                Data = new List<string>(s.Data);
//                Score = s.Score;
//            }
//        }
//
//        public List<Solution> solutionList;
//        //type has to be "pacman" or "ghost"
//        public Tree()
//        {
//        }
//        public Tree(Tree t)
//        {
//
//        }
//
//        //branches must start of from a node// this creates only internal nodes
//        //the leaves are created differently
//        public void createTree(int mode)
//        {
//            //grow
//            //create initial root
//            /*
//
//            */
//            m_root = new Node(); //do nothing
//            if (mode == 1)
//            {
//                recursionGrowBranching(ref m_root, 0, false);
//
//            }
//        }
//
//        public void createBranch(ref Node root, string t, float v, string sV, int d)
//        {
//            
//            //newLeft.m_parent = root;
//            //newRight.m_parent = root;
//
//            root.m_left = newLeft;
//            root.m_right = newRight;
//
//            root.type = t;
//            root.value = v;
//            root.stringValue = sV;
//            root.depth = d;
//
//            if (IsEmpty())
//            {
//                m_root = root;
//                //root.m_parent = null;
//            }
//            //Console.WriteLine("CREATED:" + root.type);
//        }
//
//        public bool IsEmpty()
//        {
//            if (m_root == null)
//                return true;
//            else
//                return false;
//        }
//
//        public void test()
//        {
//            Node selectedNode = m_root;
//            selectedNode.m_left.m_left = null;
//            selectedNode.m_left.m_right = null;
//            selectedNode.m_right.m_left = null;
//            selectedNode.m_right.m_right = null;
//        }
//
//
//        public void print()
//        {
//            prettyPrint(m_root, 0);
//        }
//        public void prettyPrint(Node t, int pad)
//        {
//            string s = "";
//            for (int i = 0; i < pad; i++)
//            {
//                s += " ";
//            }
//            if (t == null)
//            {
//                Console.WriteLine();
//            }
//            else
//            {
//                if (t.type==g_internal && t.m_right == null)
//                {
//
//                    //Console.WriteLine(t.stringValue);
//                    //Console.WriteLine(t.depth);
//                    //Console.WriteLine(ControllerType);
//                    //Console.WriteLine(ControllerType);
//                    int i = 0;
//                }
//                prettyPrint(t.m_right, pad + 4);
//                if (t == m_root)
//                {
//                    //Console.WriteLine(s + "" + t.value);
//                    Console.WriteLine(s + t.stringValue);
//                    //Console.WriteLine(s + "" + t.depth);
//                }
//                else if (t.type == g_internal)
//                {
//                    //Console.WriteLine(s + "" + t.value);
//                    Console.WriteLine(s + t.stringValue +t.depth);
//                    //Console.WriteLine(s + "" + t.depth);
//                }
//                else if (t.type == g_external)
//                {
//                    //Console.WriteLine(s + "" + t.stringValue);
//                    Console.WriteLine(s + t.value + "-" + t.depth);
//                    //Console.WriteLine(s + "" + t.depth);
//                }
//                if (t.type == g_internal && t.m_left == null)
//                {
//                    //Console.WriteLine(ControllerType);
//                    //Console.WriteLine(ControllerType);
//                    int i = 0;
//                }
//                prettyPrint(t.m_left, pad + 4);
//            }
//        }
//
//    }
//}