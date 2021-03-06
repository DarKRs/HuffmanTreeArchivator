﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.IO;
using System.Text.RegularExpressions;

namespace HuffmanCode
{
    public class HuffmanTree
    {
        private List<Node> nodes = new List<Node>();
        public Node Root { get; set; }
        public Dictionary<char, int> Frequencies = new Dictionary<char, int>();

        public Dictionary<char,int> Build(string source)
        {
            for (int i = 0; i < source.Length; i++)
            {
                if (!Frequencies.ContainsKey(source[i]))
                {
                    Frequencies.Add(source[i], 0);
                }

                Frequencies[source[i]]++;
            }

            foreach (KeyValuePair<char, int> symbol in Frequencies)
            {
                nodes.Add(new Node() { Symbol = symbol.Key, Frequency = symbol.Value });
            }

            while (nodes.Count > 1)
            {
                List<Node> orderedNodes = nodes.OrderBy(node => node.Frequency).ToList<Node>();

                if (orderedNodes.Count >= 2)
                {
                    // Take first two items
                    List<Node> taken = orderedNodes.Take(2).ToList<Node>();

                    // Create a parent node by combining the frequencies
                    Node parent = new Node()
                    {
                        Symbol = '*',
                        Frequency = taken[0].Frequency + taken[1].Frequency,
                        Left = taken[0],
                        Right = taken[1]
                    };

                    nodes.Remove(taken[0]);
                    nodes.Remove(taken[1]);
                    nodes.Add(parent);
                }

                this.Root = nodes.FirstOrDefault();

            }
            return Frequencies;
        }

        public Node node()
        {
            return Root;
        }
        
        public void createNode(string[] tree)
        {
            Node Root = new Node();
            Node currrentNode = new Node();
            Node parr = new Node();
            char[] code = { ' ' };
            char[] symbol = { ' ' };
            List<string> tre = new List<string>();
            for(int i=0; i< tree.Length; i++)
            {
                tre.Add(tree[i]);
                
            }
           tre = tre.OrderBy(x => x.Length).ToList<string>(); tre.Reverse();
            for (int i = 0; i < tre.Count; i++)
            {
                
                var re = new Regex("'");
                string clr = re.Replace(tre[i], "");
                string[] clear = clr.Split(':'); clear[1] += "$";

                symbol = clear[0].ToCharArray();
                code = clear[1].ToCharArray();

                for (int j = 0; j < code.Length; j++)
                {

                    if (code[j] == '$')
                    {
                        currrentNode.Symbol = symbol[0];
                        nodes.Add(currrentNode);
                    }
                    if (code[j] == '0')
                    {
                        if (j == 0) { Root.Left = parr; currrentNode = parr; }
                        else {
                            currrentNode.Left = parr;
                            currrentNode = currrentNode.Left; }
                    }
                    if (code[j] == '1')
                    {
                        if (j == 0) { Root.Right = parr; currrentNode = parr; }
                        else
                        {
                            currrentNode.Right = parr;
                            currrentNode = currrentNode.Right; }
                        
                    }
                }
            
            }
            int iasd = 1;

        }

        public BitArray Encode(string source)
        {
            List<bool> encodedSource = new List<bool>();

            for (int i = 0; i < source.Length; i++)
            {
                List<bool> encodedSymbol = this.Root.Traverse(source[i], new List<bool>());
                encodedSource.AddRange(encodedSymbol);
            }

            BitArray bits = new BitArray(encodedSource.ToArray());

            return bits;
        }

        public string Decode(BitArray bits)
        {
            Node current = this.Root;
            string decoded = "";

            foreach (bool bit in bits)
            {
                if (bit)
                {
                    if (current.Right != null)
                    {
                        current = current.Right;
                    }
                }
                else
                {
                    if (current.Left != null)
                    {
                        current = current.Left;
                    }
                }

                if (IsLeaf(current))
                {
                    decoded += current.Symbol;
                    current = this.Root;
                }
            }

            return decoded;
        }

        public bool IsLeaf(Node node)
        {
            return (node.Left == null && node.Right == null);
        }

    }
 
}
