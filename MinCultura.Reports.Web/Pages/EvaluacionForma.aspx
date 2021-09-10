<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EvaluacionForma.aspx.cs" Inherits="MinCultura.Reports.Web.Pages.EvaluacionForma" %>

<%@ Register Assembly="DevExpress.XtraReports.v18.2.Web.WebForms, Version=18.2.14.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.XtraReports.Web" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v18.2, Version=18.2.14.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <script>
        function initViewer(s, e) {
            var reportPreview = s.GetPreviewModel().reportPreview;
            var currentExportOptions = reportPreview.exportOptionsModel;
            var optionsUpdating = false;
            var fixExportOptions = function (options) {
                try {
                    optionsUpdating = true;
                    if (!options) {
                        currentExportOptions(null);
                    } else {
                        delete options["xls"];
                        delete options["xlsx"];
                        delete options["mht"];
                        delete options["html"];
                        delete options["textExportOptions"];
                        delete options["csv"];
                        delete options["rtf"];
                        delete options["image"];
                        delete options["docx"];
                        currentExportOptions(options);
                    }
                } finally {
                    optionsUpdating = false;
                }
            };
            currentExportOptions.subscribe(function (newValue) {
                !optionsUpdating && fixExportOptions(newValue);
            });
            fixExportOptions(currentExportOptions());
        }
    </script>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Reporte Evaluación de Forma</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <dx:ASPxLabel ID="LabMsj" runat="server" Text=""></dx:ASPxLabel>
            <dx:ASPxWebDocumentViewer ID="ASPxWebDocumentViewer1" runat="server">
                <ClientSideEvents Init="initViewer" />
            </dx:ASPxWebDocumentViewer>
        </div>
    </form>
</body>
</html>
