<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/BP_MasterPage.Master" AutoEventWireup="true" CodeBehind="BP_Anasayfa.aspx.cs" Inherits="BUDGET_PLANNER_.nett.Pages.BP_Anasayfa" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Styles/BP_AnasayfaStyle.css" rel="stylesheet" />
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.6.0/css/all.min.css"
        integrity="sha512-Kc323vGBEqzTmouAECnVceyQqyqdsSiqLQISBL29aUW4U/M7pSPA/gEUZQqv1cwx4OnYxTxve5UMg5GT6L4JJg=="
        crossorigin="anonymous" referrerpolicy="no-referrer" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager runat="server"></asp:ScriptManager>

    <div class="metin-container">
        <div class="metin">
            <asp:Label runat="server" ID="lblMesaj" CssClass="hosgeldin-metin"></asp:Label>
            <hr />
        </div>
    </div>
    <br />
    <div class="chart-container">
        <h2>Aylık gelir-gider grafiği</h2>
        <div class="chart">
            <canvas id="myChart"></canvas>
        </div>
    </div>
    <asp:TextBox runat="server" ID="txtOcakValues" type="hidden"></asp:TextBox>
    <asp:TextBox runat="server" ID="txtSubatValues" type="hidden"></asp:TextBox>
    <asp:TextBox runat="server" ID="txtMartValues" type="hidden"></asp:TextBox>
    <asp:TextBox runat="server" ID="txtNisanValues" type="hidden"></asp:TextBox>
    <asp:TextBox runat="server" ID="txtMayisValues" type="hidden"></asp:TextBox>
    <asp:TextBox runat="server" ID="txtHaziranValues" type="hidden"></asp:TextBox>
    <asp:TextBox runat="server" ID="txtTemmuzValues" type="hidden"></asp:TextBox>
    <asp:TextBox runat="server" ID="txtAgustosValues" type="hidden"></asp:TextBox>
    <asp:TextBox runat="server" ID="txtEylulValues" type="hidden"></asp:TextBox>
    <asp:TextBox runat="server" ID="txtEkimValues" type="hidden"></asp:TextBox>
    <asp:TextBox runat="server" ID="txtKasimValues" type="hidden"></asp:TextBox>
    <asp:TextBox runat="server" ID="txtAralikValues" type="hidden"></asp:TextBox>


    <div class="hesaplarim-box">
        <div class="hesaplarim-container">
            <h1>Hesaplarım</h1>
            <span>Hesap Türü: </span>
            <asp:DropDownList runat="server" ID="dDownListHesaplar" CssClass="dDown-hesaplar" OnSelectedIndexChanged="dDownListHesaplar_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
            <div>
                <ul class="tablo-basliklar">
                    <li>Hesap Adı</li>
                    <li>Hesap Açıklaması</li>
                    <li>Hesap Türü</li>
                    <li>Hesap Toplam Gelir</li>
                    <li>Hesap Gider</li>
                    <li>İşlem Yap</li>
                </ul>
            </div>
            <asp:UpdatePanel runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <div>
                        <asp:DataList runat="server" ID="dListHesaplar">
                            <ItemTemplate>
                                <ul class="tablo-elemanlar">
                                    <li><%# Eval("adi") %></li>
                                    <li><%# Eval("aciklamasi") %> </li>
                                    <li><%# Eval("tur") %> </li>
                                    <li style="color: seagreen;"><%# Convert.ToDecimal(Eval("gelir")).ToString("C") %> </li>
                                    <li style="color: red;"><%# Convert.ToDecimal(Eval("gider")).ToString("C") %></li>
                                    <li>
                                        <a href="BP_Islemler.aspx?IDislem=<%#Eval("id")%>&" class="btn-islem-yap">İşlem Yap</a>
                                        <a class="btn-sil" onclick="ShowSure(<%# Eval("id") %>)">Hesabı Sil</a>
                                    </li>
                                </ul>
                            </ItemTemplate>
                        </asp:DataList>
                    </div>
                    <asp:Panel runat="server" ID="pnlHesapBulunamadi">
                        <h2 style="text-align: center; font-size: 22px; margin-top: 50px; padding: 40px;" runat="server" id="hesapBulunamadi">Herhangi bir hesap bulunmamaktadır.</h2>
                    </asp:Panel>

                </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="dDownListHesaplar" EventName="SelectedIndexChanged" />
                </Triggers>
            </asp:UpdatePanel>

        </div>
    </div>

    <div class="emin-misin-container" id="eminMisin">
        <div class="emin-misin">
            <asp:HiddenField runat="server" ID="hFHesapId" />
            <asp:Label runat="server" ID="lblHesapId" style="visibility:hidden"></asp:Label>
            <h2>Hesabı Sil</h2>
            <p>Hesabı silmek istediğinden emin misin ?</p>
            <div class="emin-misin-btn-group">
                <asp:Button runat="server" ID="btnYinedeSil" Text="SİL" CssClass="btn-emin-misin" OnClick="btnYinedeSil_Click" />
                <a class="btn-emin-misin" onclick="CloseSure()">İPTAL</a>
            </div>
        </div>
    </div>

    <script>

        window.onload = function () {
            var link = document.querySelector("#anasayfa");
            link.classList.toggle("active-menu-item");
        }
        function ShowSure(id) {
            var link = document.getElementById("eminMisin");
            link.style.display = "flex";
            document.getElementById("<%=hFHesapId.ClientID%>").value = id;


        }
        function CloseSure() {
            var link = document.getElementById("eminMisin");
            link.style.display = "none";
        }
    </script>
    <script src="https://cdn.jsdelivr.net/npm/chart.js"></script>
    <script>
        const ctx = document.getElementById('myChart');

        new Chart(ctx, {
            type: 'line',
            data: {
                labels: ['Ocak', 'Şubat', 'Mart', 'Nisan', 'Mayıs', 'Haziran', 'Temmuz', 'Ağustos', 'Eylül', 'Ekim', 'Kasım'],
                datasets: [{
                    label: 'Gelir',
                    data: [<%=txtOcakValues.Text.Split(' ')[0]%>,<%=txtSubatValues.Text.Split(' ')[0]%>,<%=txtMartValues.Text.Split(' ')[0]%>,<%=txtNisanValues.Text.Split(' ')[0]%>,<%=txtMayisValues.Text.Split(' ')[0]%>,<%=txtHaziranValues.Text.Split(' ')[0]%>,<%=txtTemmuzValues.Text.Split(' ')[0]%>,<%=txtAgustosValues.Text.Split(' ')[0]%>,<%=txtEylulValues.Text.Split(' ')[0]%>,<%=txtEkimValues.Text.Split(' ')[0]%>,<%=txtKasimValues.Text.Split(' ')[0]%>,<%=txtAralikValues.Text.Split(' ')[0]%>],
                    borderWidth: 1,
                    backgrounColor: "#FF0000",
                }, {
                        label: 'Gider',
                    data: [<%=txtOcakValues.Text.Split(' ')[1]%>,<%=txtSubatValues.Text.Split(' ')[1]%>,<%=txtMartValues.Text.Split(' ')[1]%>,<%=txtNisanValues.Text.Split(' ')[1]%>,<%=txtMayisValues.Text.Split(' ')[1]%>,<%=txtHaziranValues.Text.Split(' ')[1]%>,<%=txtTemmuzValues.Text.Split(' ')[1]%>,<%=txtAgustosValues.Text.Split(' ')[1]%>,<%=txtEylulValues.Text.Split(' ')[1]%>,<%=txtEkimValues.Text.Split(' ')[1]%>,<%=txtKasimValues.Text.Split(' ')[1]%>,<%=txtAralikValues.Text.Split(' ')[1]%>],
                        borderWidth: 1,
                        backgrounColor: "#000000",
                    }
                ]
            },
            options: {
                scales: {
                    y: {
                        beginAtZero: true
                    }
                }
            }
        });
    </script>


</asp:Content>
