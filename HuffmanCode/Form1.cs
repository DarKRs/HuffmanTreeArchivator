using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HuffmanCode
{
    public partial class Form1 : Form
    {
        HuffmanTree huffmanTree = new HuffmanTree();
        BitArray encoded;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            loadFile.ShowDialog();
            string path = loadFile.FileName;
            string text = "";
            if (loadFile.FileName != "") //если в окне была нажата кнопка "ОК"
            {
                StreamReader sr = new StreamReader(path, System.Text.Encoding.Default);
                while (!sr.EndOfStream)
                {
                    text += sr.ReadLine();
                    text += "\n";
                }
                SourceText.Text = text;
            }
        }

        private void v_Click(object sender, EventArgs e)
        {
            SourceText.Text = "";
        }

        private void ClearEncoded_Click(object sender, EventArgs e)
        {
            EncodedText.Text = "";
        }

        private void Закодировать_Click(object sender, EventArgs e)
        {
            Dictionary<char, int> FrequenciesIn = new Dictionary<char, int>();
           

            string Encoding = SourceText.Text;

            FrequenciesIn = huffmanTree.Build(Encoding);
            encoded = huffmanTree.Encode(Encoding);
            string LenghtTree = huffmanTree.Frequencies.Count.ToString();
            EncodedText.Text += "ivt" + LenghtTree + "\n";
           
            printTree(huffmanTree.node());
            foreach (bool bit in encoded)
            {
                EncodedText.Text += (bit ? 1 : 0);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string decoded = huffmanTree.Decode(encoded);
            SourceText.Text = decoded;
        }

        private void CodeInFile_Click(object sender, EventArgs e)
        {
            SaveFile.Filter = "ARCHIVE(*.arc)|*.arc";
            if (SaveFile.ShowDialog() == DialogResult.OK) //если в окне была нажата кнопка "ОК"
            { 
            string path = SaveFile.FileName;
            FileStream fs = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write);
                
                Dictionary<char, int> FrequenciesIn = new Dictionary<char, int>();
               
                byte buffer=0;
                int bufferpos = 0;
                BinaryWriter bw = new BinaryWriter(fs);
                string Encoding = SourceText.Text;
            FrequenciesIn = huffmanTree.Build(Encoding);
            encoded = huffmanTree.Encode(Encoding);
            string LenghtTree = huffmanTree.Frequencies.Count.ToString();
              bw.Write("ivt" + LenghtTree);
              writeTree(huffmanTree.node(), bw);         


                foreach (bool bit in encoded)
                               {
                                  buffer = (byte)((buffer << 1) + (bit ? 1 : 0));
                                  bufferpos++;
                    if (bufferpos == 8)
                    {
                        bufferpos = 0; bw.Write(buffer); buffer = 0;
                    }
                               }
               
                
                bw.Close();
                


            }
           
        }

        private void DecodeInFile_Click(object sender, EventArgs e)
        {
            
        }

        public void printTree(Node node,string context = "")
        {
            
            if (node.Left == null)
            {
                EncodedText.Text += ("'" + node.Symbol + "':" + context + "\n");
            }
            if (node.Left != null)
            {
                printTree(node.Left, context + "0");
            }
            if(node.Right != null)
            {
                printTree(node.Right, context + "1");
            }
        }

        public void writeTree(Node node, BinaryWriter bw, string context = "")
        {

            if (node.Left == null)
            {
                bw.Write("'" + node.Symbol + "':" + context);
            }
            if (node.Left != null)
            {
                writeTree(node.Left,bw, context + "0");
            }
            if (node.Right != null)
            {
               writeTree(node.Right,bw, context + "1");
            }
        }
    }
}
