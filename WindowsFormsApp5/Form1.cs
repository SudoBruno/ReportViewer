using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp5
{
    public partial class Form1 : Form
    {
        DsRelatorio dsRelatorio = new DsRelatorio();
        
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dsRelatorio.Tables[0].Rows.Clear();
            CarregarDados(1, "Bruno", "Araçatuba", "SP");
            CarregarDados(2, "Jeferson", "Mirando", "SP");
            CarregarDados(3, "JEsus", "Birigui", "SP");
            


        }

        private void CarregarDados(int codigo, string nome, string cidade, string estado)
        {
          

            DataRow row = dsRelatorio.Tables[0].NewRow();

            row["Codigo"] = codigo;
            row["Nome"] = nome;
            row["Cidade"] = cidade;
            row["Estado"] = estado;

            dsRelatorio.Tables[0].Rows.Add(row);
           

        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DsRelatorioRDLC", dsRelatorio.Tables[0]));
            reportViewer1.RefreshReport();
            
        }
    }
}
