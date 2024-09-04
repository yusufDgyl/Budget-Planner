<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/BP_MasterPage.Master" AutoEventWireup="true" CodeBehind="BP_HesapSec.aspx.cs" Inherits="BUDGET_PLANNER_.nett.Pages.BP_HesapSec" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Styles/BP_HesapSecStyle.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="box-container">
        <div class="row row-1">
            <div class="box">
                <h2><i class="fa-solid fa-wallet"></i></h2>
                <h2>Nakit Hesap</h2>
                <p>Nakit gelir ve giderlerin kaydedildiği hesap</p>
                <ul>
                    <li>lorem ipsum</li>
                    <li>lorem ipsum color</li>
                    <li>lorem ipsum color deconstructor</li>
                </ul>
                <asp:DataList runat="server" ID="dListNakit">
                    <ItemTemplate>
                        <div class="btn-container">
                            <a class="btn-sec" href="BP_Islemler.aspx?ID=<%# Eval("id")%>">Seç</a>
                        </div>
                    </ItemTemplate>
                </asp:DataList>
            </div>
            <div class="box">
                <h2><i class="fa-solid fa-building-columns"></i></h2>
                <h2>Banka Hesap</h2>
                <p>Banka gelir ve giderlerin kaydedildiği hesap</p>
                <ul>
                    <li>lorem ipsum</li>
                    <li>lorem ipsum color</li>
                    <li>lorem ipsum color deconstructor</li>
                </ul>
                <asp:DataList runat="server" ID="dListBanka">
                    <ItemTemplate>
                        <div class="btn-container">
                            <a class="btn-sec" href="BP_Islemler.aspx?ID=<%# Eval("id")%>">Seç</a>
                        </div>
                    </ItemTemplate>
                </asp:DataList>
            </div>
            <div class="box">
                <h2><i class="fa-solid fa-credit-card"></i></h2>
                <h2>Kredi Kartı Hesap</h2>
                <p>Kredi kartı gelir ve giderlerin kaydedildiği hesap</p>
                <ul>
                    <li>lorem ipsum</li>
                    <li>lorem ipsum color</li>
                    <li>lorem ipsum color deconstructor</li>
                </ul>
                <asp:DataList runat="server" ID="dListKredi">
                    <ItemTemplate>
                        <div class="btn-container">
                            <a class="btn-sec" href="BP_Islemler.aspx?ID=<%# Eval("id")%>">Seç</a>
                        </div>
                    </ItemTemplate>
                </asp:DataList>
            </div>

            <div class="box">
                <h2><i class="fa-solid fa-piggy-bank"></i></h2>
                <h2>Birikim Hesap</h2>
                <p>Birikim gelir ve giderlerin kaydedildiği hesap</p>
                <ul>
                    <li>lorem ipsum</li>
                    <li>lorem ipsum color</li>
                    <li>lorem ipsum color deconstructor</li>
                </ul>
                <asp:DataList runat="server" ID="dListBirikim">
                    <ItemTemplate>
                        <div class="btn-container">
                            <a class="btn-sec" href="BP_Islemler.aspx?ID=<%# Eval("id")%>">Seç</a>
                        </div>
                    </ItemTemplate>
                </asp:DataList>
            </div>
        </div>
        <asp:Panel runat="server" ID="pnlIsletmeTur" CssClass="pnl-isletme-tur">
            <div class="row row-2">
                <div class="box">
                    <h2><i class="fa-solid fa-coins"></i></h2>
                    <h2>Cari Hesap</h2>
                    <p>Cari gelir ve giderlerin kaydedildiği hesap</p>
                    <ul>
                        <li>lorem ipsum</li>
                        <li>lorem ipsum color</li>
                        <li>lorem ipsum color deconstructor</li>
                    </ul>
                    <asp:DataList runat="server" ID="dListCari">
                        <ItemTemplate>
                            <div class="btn-container">
                                <a class="btn-sec" href="BP_Islemler.aspx?ID=<%# Eval("id")%>">Seç</a>
                            </div>
                        </ItemTemplate>
                    </asp:DataList>
                </div>
                <div class="box">
                    <h2><i class="fa-solid fa-address-book"></i></h2>
                    <h2>Personel Hesap</h2>
                    <p>Personel gelir ve giderlerin kaydedildiği hesap</p>
                    <ul>
                        <li>lorem ipsum</li>
                        <li>lorem ipsum color</li>
                        <li>lorem ipsum color deconstructor</li>
                    </ul>
                    <asp:DataList runat="server" ID="dListPersonel">
                        <ItemTemplate>
                            <div class="btn-container">
                                <a class="btn-sec" href="BP_Islemler.aspx?ID=<%# Eval("id")%>">Seç</a>
                            </div>
                        </ItemTemplate>
                    </asp:DataList>
                </div>
                <div class="box">
                    <h2><i class="fa-solid fa-boxes-stacked"></i></h2>
                    <h2>Stok Hesap</h2>
                    <p>Stok gelir ve giderlerin kaydedildiği hesap</p>
                    <ul>
                        <li>lorem ipsum</li>
                        <li>lorem ipsum color</li>
                        <li>lorem ipsum color deconstructor</li>
                    </ul>
                    <asp:DataList runat="server" ID="dListStok">
                        <ItemTemplate>
                            <div class="btn-container">
                                <a class="btn-sec" href="BP_Islemler.aspx?ID=<%# Eval("id")%>">Seç</a>
                            </div>
                        </ItemTemplate>
                    </asp:DataList>
                </div>
            </div>

        </asp:Panel>
    </div>
</asp:Content>
