<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPages/AdminMasterPage.Master" AutoEventWireup="true" CodeBehind="SayfaListeleme.aspx.cs" Inherits="BUDGET_PLANNER_.nett.Admin.Pages.SayfaListeleme" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Styles/TabloTasarim.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="tablo-container">
        <asp:DataList runat="server" ID="dataList1" CssClass="tablo">
            <HeaderTemplate>
                <tr>
                    <th>ID</th>
                    <th>Adi</th>
                    <th>Link</th>
                </tr>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td><%# Eval("id") %></td>
                    <td><%# Eval("adi") %></td>
                    <td><a href="SayfaDuzenle.aspx?ID=<%#Eval("id")%>">Detaya Git</a></td>
                </tr>
            </ItemTemplate>
        </asp:DataList>
    </div>



</asp:Content>
