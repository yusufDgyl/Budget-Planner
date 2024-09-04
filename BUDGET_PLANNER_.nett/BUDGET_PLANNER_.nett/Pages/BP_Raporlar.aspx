<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/BP_MasterPage.Master" AutoEventWireup="true" CodeBehind="BP_Raporlar.aspx.cs" Inherits="BUDGET_PLANNER_.nett.Pages.Raporlar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Styles/BP_RaporlarStyle.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <div class="chart-container">
        <h2>Genel Durum Raporu</h2>
        <div class="chart-container">
            <asp:Panel runat="server" ID="pnlBuyukIsletme">
                <div class="chart">
                    <canvas id="myChart"></canvas>
                </div>
            </asp:Panel>

            <asp:Panel runat="server" ID="pnlKucukIsletme">
                <div class="chart">
                    <canvas id="myChart_subbagian"></canvas>
                </div>
            </asp:Panel>
        </div>
    </div>

    <asp:TextBox runat="server" ID="txtNakit" type="hidden"></asp:TextBox>
    <asp:TextBox runat="server" ID="txtBanka" type="hidden"></asp:TextBox>
    <asp:TextBox runat="server" ID="txtKrediKarti" type="hidden"></asp:TextBox>
    <asp:TextBox runat="server" ID="txtBirikim" type="hidden"></asp:TextBox>
    <asp:TextBox runat="server" ID="txtCari" type="hidden"></asp:TextBox>
    <asp:TextBox runat="server" ID="txtPersonel" type="hidden"></asp:TextBox>
    <asp:TextBox runat="server" ID="txtStok" type="hidden"></asp:TextBox>



    <div class="rapor-container">
        <h1> Hesaplar Genel Durum</h1>
        <div class="rapor-hesap">
            <h2>Nakit Hesap</h2>
            <div>
                <label class="lbl lbl-durum">Genel Durum : </label>
                <asp:Label runat="server" ID="lblNakit" Text="deneme" CssClass="lbl lblTutar"></asp:Label>
            </div>
        </div>
        <div class="rapor-hesap">
            <h2>Banka Hesap</h2>
            <div>
                <label class="lbl lbl-durum">Genel Durum : </label>
                <asp:Label runat="server" ID="lblBanka" CssClass="lbl lblTutar"></asp:Label>
            </div>
        </div>
        <div class="rapor-hesap">
            <h2>Kredi Kartı Hesap</h2>
            <div>
                <label class="lbl lbl-durum">Genel Durum : </label>
                <asp:Label runat="server" ID="lblKrediKarti" CssClass="lbl lblTutar"></asp:Label>
            </div>
        </div>
        <div class="rapor-hesap">
            <h2>Birikim Hesap</h2>
            <div>
                <label class="lbl lbl-durum">Genel Durum : </label>
                <asp:Label runat="server" ID="lblBirikim" CssClass="lbl lblTutar"></asp:Label>
            </div>
        </div>
        <asp:Panel runat="server" ID="pnlBuyukIsletmeRapor">
            <div class="rapor-hesap">
                <h2>Cari Hesap</h2>
                <div>
                    <label class="lbl lbl-durum">Genel Durum : </label>
                    <asp:Label runat="server" ID="lblCari" CssClass="lbl lblTutar"></asp:Label>
                </div>
            </div>
            <div class="rapor-hesap">
                <h2>Personel Hesap</h2>
                <div>
                    <label class="lbl lbl-durum">Genel Durum : </label>
                    <asp:Label runat="server" ID="lblPersonel" CssClass="lbl lblTutar"></asp:Label>
                </div>
            </div>
            <div class="rapor-hesap">
                <h2>Stok Hesap</h2>
                <div>
                    <label class="lbl lbl-durum">Genel Durum : </label>
                    <asp:Label runat="server" ID="lblStok" CssClass="lbl lblTutar"></asp:Label>
                </div>
            </div>
        </asp:Panel>
    </div>




    <script>

        window.onload = function () {
            var link = document.querySelector("#raporlar");
            link.classList.toggle("active-menu-item");

        }
    </script>

    <script src="https://cdn.jsdelivr.net/npm/chart.js"></script>

    <script>

        // setup

        const data = {
            labels: ['Nakit', 'Banka', 'Kredi Kartı', 'Birikim', 'Cari', 'Personel', 'Stok'],
            datasets: [{
                label: 'Gelir',
                data: [<%=txtNakit.Text.Split(' ')[0]%>,<%=txtBanka.Text.Split(' ')[0]%>,<%=txtKrediKarti.Text.Split(' ')[0]%>,<%=txtBirikim.Text.Split(' ')[0]%>,<%=txtCari.Text.Split(' ')[0]%>,
                    , <%=txtPersonel.Text.Split(' ')[0]%>,<%=txtStok.Text.Split(' ')[0]%>],
                borderWidth: 1,
                backgrounColor: "#FF0000",
            }, {
                    label: 'Gider',
                    data: [<%=txtNakit.Text.Split(' ')[1]%>,<%=txtBanka.Text.Split(' ')[1]%>,<%=txtKrediKarti.Text.Split(' ')[1]%>,<%=txtBirikim.Text.Split(' ')[1]%>,<%=txtCari.Text.Split(' ')[1]%>,
                    , <%=txtPersonel.Text.Split(' ')[1]%>,<%=txtStok.Text.Split(' ')[1]%>],
                    borderWidth: 1,
                    backgrounColor: "#000000",
                }
            ]
        };


        // config

        const config = {
            type: 'bar',
            data,
            options: {
                scales: {
                    y: {
                        beginAtZero: true
                    }
                }
            }
        };



        // render init

        const myChart = new Chart(document.getElementById('myChart'), config);


        // subbagian setup

        const subbagianData = {
            labels: ['Nakit', 'Banka', 'Kredi Kartı', 'Birikim'],
            datasets: [{
                label: 'Gelir',
                data: [<%=txtNakit.Text.Split(' ')[0]%>,<%=txtBanka.Text.Split(' ')[0]%>,<%=txtKrediKarti.Text.Split(' ')[0]%>,<%=txtBirikim.Text.Split(' ')[0]%>],
                borderWidth: 1,
                backgrounColor: "#FF0000",
            }, {
                    label: 'Gider',
                    data: [<%=txtNakit.Text.Split(' ')[1]%>,<%=txtBanka.Text.Split(' ')[1]%>,<%=txtKrediKarti.Text.Split(' ')[1]%>,<%=txtBirikim.Text.Split(' ')[1]%>],
                    borderWidth: 1,
                    backgrounColor: "#000000",
                }
            ]
        };

        // subbagian config

        const subbagianConfig = {
            type: 'bar',
            data: subbagianData,
            options: {
                scales: {
                    y: {
                        beginAtZero: true
                    }
                }
            }
        };

        // subbagian init


        const myChart_subbagian = new Chart(document.getElementById('myChart_subbagian'), subbagianConfig);



    </script>
</asp:Content>
