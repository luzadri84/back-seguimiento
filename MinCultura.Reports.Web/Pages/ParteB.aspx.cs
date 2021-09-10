using MinCultura.Reports.Web.Reportes;
using System;
using System.Drawing;

namespace MinCultura.Reports.Web.Pages
{
    public partial class ParteB : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(Request["Id"]))
            {
                XtraReportParteB parteB = new XtraReportParteB();
                decimal Id = Convert.ToDecimal(Request["Id"]);

                DataSource.PAS_REPORTE_REGISTRO_PROYECTO_CONCERTACIONDataTable data =
                    parteB.pAS_REPORTE_REGISTRO_PROYECTO_CONCERTACIONTableAdapter.GetData(Id);
                if (data.Count > 0)
                {
                    DataSource.PAS_REPORTE_PARTE_BDataTable dataParteB =
                        parteB.pAS_REPORTE_PARTE_BTableAdapter.GetData(Id);
                    DataSource.PAS_REPORTE_PARTE_B_TEMASDataTable dataParteBTemas =
                        parteB.pAS_REPORTE_PARTE_B_TEMASTableAdapter.GetData(Id);
                    DataSource.PAS_REPORTE_PARTE_B_TRAYECTORIADataTable dataParteBTrayectoria =
                        parteB.pAS_REPORTE_PARTE_B_TRAYECTORIATableAdapter.GetData(Id);
                    DataSource.PAS_REPORTE_PARTE_B_CRONODataTable dataParteBCrono =
                        parteB.pAS_REPORTE_PARTE_B_CRONOTableAdapter.GetData(Id);
                    DataSource.PAS_REPORTE_PARTE_B_PRESUPUESTODataTable dataParteBPresupuesto =
                        parteB.pAS_REPORTE_PARTE_B_PRESUPUESTOTableAdapter.GetData(Id);
                    DataSource.PAS_REPORTE_PARTE_B_IMPACTOSDataTable dataParteBImpactos =
                        parteB.pAS_REPORTE_PARTE_B_IMPACTOSTableAdapter.GetData(Id);

                    //Información de la parte A
                    parteB.pAS_REPORTE_REGISTRO_PROYECTO_CONCERTACIONTableAdapter.Fill(data, Id);
                    //Información básica parte B
                    parteB.pAS_REPORTE_PARTE_BTableAdapter.Fill(dataParteB, Id);
                    //Temas proyecto
                    parteB.pAS_REPORTE_PARTE_B_TEMASTableAdapter.Fill(dataParteBTemas, Id);
                    //Preguntas trayectoria proyecto
                    parteB.pAS_REPORTE_PARTE_B_TRAYECTORIATableAdapter.Fill(dataParteBTrayectoria, Id);
                    //Cronograma y actividades obligatorias del proyecto
                    parteB.pAS_REPORTE_PARTE_B_CRONOTableAdapter.Fill(dataParteBCrono, Id);
                    //Presupuesto del proyecto
                    parteB.pAS_REPORTE_PARTE_B_PRESUPUESTOTableAdapter.Fill(dataParteBPresupuesto, Id);
                    //Impactos del proyecto
                    parteB.pAS_REPORTE_PARTE_B_IMPACTOSTableAdapter.Fill(dataParteBImpactos, Id);

                    ASPxWebDocumentViewer1.OpenReport(parteB);
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