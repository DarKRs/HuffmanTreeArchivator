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
            loadfile2.ShowDialog();
            string path = loadfile2.FileName;
            string text = "";
            if (loadfile2.FileName != "") //если в окне была нажата кнопка "ОК"
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
           
                FileStream fs2 = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write);
                StreamWriter sw = new StreamWriter(fs2, System.Text.Encoding.Default);
                Dictionary<char, int> FrequenciesIn = new Dictionary<char, int>();
                
                byte buffer=0;
                int bufferpos = 0;
                
                string Encoding = SourceText.Text;
            FrequenciesIn = huffmanTree.Build(Encoding);
            encoded = huffmanTree.Encode(Encoding);
            string LenghtTree = huffmanTree.Frequencies.Count.ToString();
              sw.WriteLine("ivt" + LenghtTree);
              writeTree(huffmanTree.node(), sw);
                sw.Flush();
                sw.Close();
                
                FileStream fs = new FileStream(path, FileMode.Append, FileAccess.Write);
                BinaryWriter bw = new BinaryWriter(fs);
             
                //bw.Seek(sw.NewLine + 1, 0);
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

            SaveFile.Filter = "TXT(*.txt)|*.txt";
            if (SaveFile.ShowDialog() == DialogResult.OK) //если в окне была нажата кнопка "ОК"
            {
                string decoded = huffmanTree.Decode(encoded);
                string path = SaveFile.FileName;
                FileStream fs2 = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write);
                StreamWriter sw = new StreamWriter(fs2);
                sw.Write(decoded);
                sw.Close();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
            loadFile.Filter = "ARCHIVE(*.arc)|*.arc";
            loadFile.ShowDialog();
            string path = loadFile.FileName;
            string text = "";
            byte[] buf = new byte[1024];
            char[] buff = new char[1024];
            FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read);
            /*byte[] buff;
            
            if (loadFile.FileName != "") //если в окне была нажата кнопка "ОК"
            {
                BinaryReader br = new BinaryReader(fs3);
                
                    text += br.Read(buff,0,fs3.Length);
                    text += "\n";
                EncodedText.Text = text;s
                br.Close();
            }*/
            StreamReader sr = new StreamReader(fs);
            sr.Read(buff, 0, 3);
            string lnght = sr.ReadLine();
            int lenght = Convert.ToInt32(lnght);
            string[] tr = new string[lenght];
            for(int i = 0; i < lenght; i++)
            {
                tr[i] = sr.ReadLine();
                if (tr[i] == "'")
                {
                    tr[i] += "\n";
                    tr[i] += sr.ReadLine();
                    
                }
            }
            BinaryReader br = new BinaryReader(fs);
            
            for(int i=0;i<fs.Length;i++)
            {
                br.ReadByte();
            }
            int s = 90;
            /*var file = File.OpenRead(path);
            byte[] buf = new byte[1024];
            int r = -1;
            byte b;
            while (r != 0)
            {
                r = file.Read(buf, 0, buf.Length);
                for (int j = 0; j < r; j++)
                {
                    b = buf[j];
                    for (int i = 9; i >= 0; i--)
                        text += ((b >> i) & 1);
                    text += ((j + 1) % 1 == 0 ? ' ' : '/');
                }
            }
            EncodedText.Text = text;*/
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

        public void writeTree(Node node, StreamWriter sw, string context = "")
        {

            if (node.Left == null)
            {
                sw.Write("'" + node.Symbol + "':" + context + "\n");
            }
            if (node.Left != null)
            {
                writeTree(node.Left,sw, context + "0");
            }
            if (node.Right != null)
            {
               writeTree(node.Right,sw, context + "1");
            }
        }

        public Dictionary<char,string> readTree(int lenght,BinaryReader br)
        {
            Dictionary<char, string> dic = new Dictionary<char, string>();



            return dic;
        }

       
    }
}
