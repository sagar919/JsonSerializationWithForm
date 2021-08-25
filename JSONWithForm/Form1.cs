using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization.Json;

namespace JSONWithForm
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Person p = new Person();
            p.id = 1;
            p.name = "Sagar";
            p.email = "sagar111@gmail.com";

            MemoryStream ms = new MemoryStream();

            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(Person));

            ser.WriteObject(ms, p);

            byte[] jsonArray = ms.ToArray();

            string str = Encoding.UTF8.GetString(jsonArray);

            textBox1.Text = str;


        }

        private void button2_Click(object sender, EventArgs e)
        {
            MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(textBox1.Text));

            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(Person));

            Person p = ser.ReadObject(ms) as Person;

            textBox2.Text = p.id + " " + p.name + " " + p.email;

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
