using MinCultura.Reports.Web.Reportes;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MinCultura.Reports.Web.Pages
{
    public partial class EvaluacionForma : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(Request["Id"]))
            {
                decimal Id = Convert.ToDecimal(Request["Id"]);
                XtraReportEvaluacionForma ef = new XtraReportEvaluacionForma();

                DataSource.SP_EVALUACION_FORMADataTable data = ef.sP_EVALUACION_FORMATableAdapter.GetData(Id);

                if(data.Count > 0)
                {
                    ef.sP_EVALUACION_FORMATableAdapter.Fill(data, Id);
                    ASPxWebDocumentViewer1.OpenReport(ef);
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