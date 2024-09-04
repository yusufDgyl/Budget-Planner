<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPages/AdminMasterPage.Master" AutoEventWireup="true" CodeBehind="SayfaDuzenle.aspx.cs" Inherits="BUDGET_PLANNER_.nett.Admin.Pages.SayfaDetay" %>

<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <style>
        .cke_skin_kama .cke_contents {
            height: 1000px;
        }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="ckeditor-container" style="margin-top: 50px;">

        <div class="sayfa-bilgileri">
            <asp:Label runat="server" ID="lblSayfaAdi"></asp:Label>
            <asp:Label runat="server" ID="lblSayfaId"></asp:Label>
        </div>
        <div>
            <CKEditor:CKEditorControl ID="txtIcerik" runat="server">
            </CKEditor:CKEditorControl>

        </div>
        <div>
            <asp:Label runat="server" ID="lblMesaj"></asp:Label>
        </div>
        <div>
            <asp:Button runat="server" ID="btnGuncelle" Text="GUCENLLE" CssClass="genelBtn" onclick="btnGuncelle_Click"/>
        </div>
    </div>
</asp:Content>
