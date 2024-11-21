using iTextSharp.text.pdf;
using iTextSharp.text;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PRJ_QuanLyBanLaptop
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Document doc = new Document();
            //get the current directory
            string path = Environment.CurrentDirectory;
            //get a PDFWriter object 
            PdfWriter.GetInstance(doc, new FileStream(path + "/Stdio_iTextSharp_Demo.pdf", FileMode.Create));
            //open the document for writting
            doc.Open();
            //write a pharagrap to the document
            doc.Add(new Paragraph("Wellcome you to Stdio.vn"));
            //write Author metadata
            doc.AddAuthor("Nguyen Nghia");
            //write title metadata
            doc.AddTitle("Demo Read PDF document using iTextSharp library in C#");
            //write subject metadata
            doc.AddSubject("Read PDF document using iTextSharp library in C#");
            //write keyworks metadata
            doc.AddKeywords("Stdio.vn");
            //close the document
            doc.Close();

            Console.ReadLine();
        }
    }
}
