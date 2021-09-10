using MinCultura.Reports.Web.Reportes;
using System;
using System.Drawing;
using System.Web.UI;

namespace MinCultura.Reports.Web.Pages
{
    public partial class ParteA : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!string.IsNullOrWhiteSpace(Request["Id"]))
            {
                XtraReportParteA parteA = new XtraReportParteA();
                decimal Id = Convert.ToDecimal(Request["Id"]);

                DataSource.PAS_REPORTE_REGISTRO_PROYECTO_CONCERTACIONDataTable data = 
                    parteA.pAS_REPORTE_REGISTRO_PROYECTO_CONCERTACIONTableAdapter.GetData(Id);
                

                if (data.Count > 0)
                {
                    parteA.pAS_REPORTE_REGISTRO_PROYECTO_CONCERTACIONTableAdapter.Fill(data, Id);
                    ASPxWebDocumentViewer1.OpenReport(parteA);
                    LabMsj.Text = "";
                }
                else
                {
                    LabMsj.Text = "No existe información para desplegar el reporte.";
                    LabMsj.ForeColor = Color.Red;
                    ASPxWebDocumentViewer1.Visible = false;
                }
            }
            else
            {
                LabMsj.Text = "Parámetros invalidos.";
                LabMsj.ForeColor = Color.Red;
                ASPxWebDocumentViewer1.Visible = false;
            }
        }
    }
}