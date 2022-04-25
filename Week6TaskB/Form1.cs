using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Week6TaskB.Classes;

namespace Week6TaskB
{
    public partial class Form1 : Form
    {
        Graph myGraph = new Graph();


        public Form1()
        {
            InitializeComponent();


            myGraph.AddNode("lux");
            myGraph.AddNode("ams");
            myGraph.AddNode("cdg");
            myGraph.AddNode("lis");
            myGraph.AddNode("waw");
            myGraph.AddNode("mxp");
            myGraph.AddNode("ber");
            myGraph.AddNode("lcy");
            myGraph.AddNode("mad");
            myGraph.AddNode("bru");



            myGraph.AddEdge("lux", "ams");
            myGraph.AddEdge("ams", "cdg");
            myGraph.AddEdge("cdg", "lis");
            myGraph.AddEdge("waw", "lux");
            myGraph.AddEdge("mxp", "waw");
            myGraph.AddEdge("mxp", "ber");
            myGraph.AddEdge("mxp", "lcy");
            myGraph.AddEdge("ber", "mad");
            myGraph.AddEdge("mad", "lcy");
            myGraph.AddEdge("mad", "bru");
            myGraph.AddEdge("mad", "cdg");


        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("Please enter an airport code");
            }

            
            else if (textBox1.Text != null)
            {
                myGraph.AddNode(textBox1.Text);
                MessageBox.Show("New airport code inserted");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {

            listBox1.Items.Clear();
            string s = textBox4.Text;

            GraphNode n = myGraph.findNodeInGraph(s);


            if (n != null)
            {
                if (radioButton1.Checked)
                {
                    LinkedList<string> adjList = n.GetAdjList();
                    foreach (string t in adjList)
                    {                      
                            listBox1.Items.Add(textBox4.Text + " --> " + t );      
                    }
                }
            }

            if (radioButton2.Checked)
            {
                List<string> visitedDFT = new List<string>();

                myGraph.DepthFirstTraverse(textBox4.Text, ref visitedDFT);

                foreach (string u in visitedDFT)
                {
                    listBox1.Items.Add(u);
                }
            }

            if (String.IsNullOrEmpty(textBox4.Text))
            {
                MessageBox.Show("Please enter a value");
            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBox2.Text))
            {
                MessageBox.Show("Please enter both airports");
            }

            if (String.IsNullOrEmpty(textBox3.Text) )
            {
                MessageBox.Show("Please enter both airports");
            }

            else if (textBox2.Text != null && textBox3.Text != null)
            {
                
                myGraph.AddEdge(textBox2.Text, textBox3.Text);

                MessageBox.Show("New direct flight created");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

            if (String.IsNullOrEmpty(textBox2.Text))
            {
                MessageBox.Show("Please enter both airports");
            }

            if (String.IsNullOrEmpty(textBox3.Text))
            {
                MessageBox.Show("Please enter both airports");
            }

            else if (textBox2.Text != null && textBox3.Text != null)
            {
                myGraph.RemoveEdge(textBox2.Text, textBox3.Text);
                MessageBox.Show("Direct flight removed");
            }
           

        }
    }
    }

