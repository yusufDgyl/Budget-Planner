<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/BP_MasterPage.Master" AutoEventWireup="true" CodeBehind="BP_IsletmeAyarlari.aspx.cs" Inherits="BUDGET_PLANNER_.nett.Pages.BP_IsletmeAyarlari" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Styles/BP_IsletmeAyarlariStyle.css" rel="stylesheet"/>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:ScriptManager runat="server"></asp:ScriptManager>

    <div class="form-container">
        <div class="bilgilerim-form" id="formBilgilerim">
            <div class="form-baslik">
                <h1>Merhaba ,
                    <asp:Label runat="server" ID="lblIsim"></asp:Label></h1>
                <div>
                    <a class="btn-duzenle" id="btnDuzenle" onclick="DuzenleGoster()">Düzenle</a>
                </div>
            </div>
            <div class="form-icerik">
                <ul>
                    <asp:DataList runat="server" ID="dListBilgilerim" CssClass="dList">
                        <ItemTemplate>
                            <li>
                                <div>
                                    <i class="fa-solid fa-user"></i>
                                    <label>İŞLETME ADI</label>
                                </div>
                                <h3><%# Eval("adi") %></h3>
                            </li>
                            <li>
                                <div>
                                    <i class="fa-solid fa-envelope"></i>
                                    <label>İŞLETME AÇIKLAMASI</label>
                                </div>
                                <h3><%# Eval("aciklamasi") %></h3>
                            </li>
                        </ItemTemplate>
                    </asp:DataList>
                </ul>
            </div>
        </div>


        <div class="form-duzenle" id="formDuzenle">
            <div class="form-baslik">
                <h1>İşletme Bilgilerini Düzenle</h1>
                <div>
                    <a class="btn-vazgec" onclick="DuzenleKapat()">VAZGEÇ</a>
                    <asp:Button runat="server" ID="btnKaydet" CssClass="btn-kaydet" Text="KAYDET" OnClick="btnKaydet_Click" />
                </div>
            </div>
            <ul>
                <li class="column-2">
                    <div>
                        <i class="fa-solid fa-envelope"></i>
                        <label>İŞLETME ADI</label>
                    </div>
                    <div>
                        <asp:TextBox runat="server" ID="txtIsletmeAdi" CssClass="txt"></asp:TextBox>
                    </div>
                </li>
                <li class="column-2">
                    <div>
                        <i class="fa-solid fa-circle-user"></i>
                        <label>İŞETME AÇIKLAMASI</label>
                    </div>
                    <div>
                        <asp:TextBox runat="server" ID="txtIsletmeAciklamasi" CssClass="txt"></asp:TextBox>
                    </div>
                </li>
            </ul>
            <asp:UpdatePanel runat="server">
                <ContentTemplate>
                    <asp:Label runat="server" ID="lblKaydetMesaj"></asp:Label>
                </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="btnKaydet" EventName="Click" />
                </Triggers>
            </asp:UpdatePanel>
        </div>

    </div>

    <script>

        window.onload = function () {
            var link = document.querySelector("#ayarlar");
            link.classList.toggle("active-menu-item");
        }
        function DuzenleGoster() {
            var link = document.getElementById("formDuzenle");
            link.style.display = "block";

            var link2 = document.getElementById("formBilgilerim");
            link2.style.display = "none";
        }
        function DuzenleKapat() {
            var link = document.getElementById("formDuzenle");
            link.style.display = "none";


            var link2 = document.getElementById("formBilgilerim");
            link2.style.display = "block";
        }
    </script>
</asp:Content>
