<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPage.Master" AutoEventWireup="true" CodeBehind="Paketler.aspx.cs" Inherits="BUDGET_PLANNER_.nett.Pages.Paketler" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <link href="../Styles/PaketlerStyle.css" rel="stylesheet" />

</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <main>
        <div class="home">
            <div class="home-content">
                <asp:DataList runat="server" ID="dtHomeH1">
                    <ItemTemplate>
                        <h1><%# Eval("icerik") %></h1>
                    </ItemTemplate>
                </asp:DataList>

                <asp:DataList runat="server" ID="dtHomeP">
                    <ItemTemplate>
                        <p><%# Eval("icerik") %></p>
                    </ItemTemplate>
                </asp:DataList>
            </div>
        </div>

        <div class="plans">
            <asp:DataList runat="server" ID="dtPlansH1">
                <ItemTemplate>
                    <h1><%# Eval("icerik") %></h1>
                </ItemTemplate>
            </asp:DataList>
            <asp:DataList runat="server" ID="dtMain">
                <ItemTemplate>
                    <div class="plans-container">
                        <div class="plan">
                            <h4><%# Eval("adi") %></h4>
                            <h4><%# Eval("fiyat") %></h4>
                            <ul>
                                <li><%# Eval("liste_item1") %></li>
                                <li><%# Eval("liste_item2") %></li>
                                <li><%# Eval("liste_item3") %></li>
                                <li><%# Eval("liste_item4") %></li>
                                <li><%# Eval("liste_item5") %></li>
                            </ul>
                            <button class="btn"><a><%# Eval("buton_icerik") %></a></button>
                        </div>
                        <div class="plan-content">
                            <h2><%# Eval("paket_hakkinda_baslik") %></h2>
                            <p>
                                <%# Eval("paket_hakkinda_icerik") %>
                            </p>
                            <button class="btn"><a><%# Eval("buton_icerik") %></a></button>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:DataList>
        </div>

    </main>

</asp:Content>
