<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/BP_MasterPage.Master" AutoEventWireup="true" CodeBehind="BP_Islemler.aspx.cs" Inherits="BUDGET_PLANNER_.nett.Pages.BP_Islemler" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Styles/BP_IslemlerStyle.css" rel="stylesheet" />
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.6.0/css/all.min.css"
        integrity="sha512-Kc323vGBEqzTmouAECnVceyQqyqdsSiqLQISBL29aUW4U/M7pSPA/gEUZQqv1cwx4OnYxTxve5UMg5GT6L4JJg=="
        crossorigin="anonymous" referrerpolicy="no-referrer" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:ScriptManager runat="server"></asp:ScriptManager>

    <div class="islemler">
        <asp:UpdatePanel runat="server" ID="updatePnl" UpdateMode="Conditional">
            <ContentTemplate>
                <asp:Panel runat="server" ID="pnlIslem" CssClass="pnl-islem">

                    <div runat="server" id="islemlerContainer" class="islemler-container">
                        <div class="islemler-form">
                            <h1>İşlem Yap</h1>
                            <div class="input-group">
                                <h3>Hesap Adı</h3>
                                <asp:TextBox runat="server" ID="txtHesapAdi" CssClass="txt-islem"></asp:TextBox>
                            </div>
                            <div class="input-group">
                                <h3>Hesap Açıklaması</h3>
                                <asp:TextBox runat="server" ID="txtHesapAciklamasi" CssClass="txt-islem"></asp:TextBox>
                            </div>
                            <div class="input-group">
                                <div class="btn-islem-tur-group">
                                    <h3>İşlem Türü</h3>
                                    <asp:Button runat="server" ID="btnGelir" CssClass="btn-islem-tur btn-green" Text="GELİR" OnClick="IslemTurGelir_Click" />
                                    <asp:Button runat="server" ID="btnGider" CssClass="btn-islem-tur btn-red" Text="GİDER" OnClick="IslemTurGider_Click" AutoPostBack="false" />
                                    <asp:Button runat="server" ID="btnBaslangicBakiye" CssClass="btn-islem-tur btn-blue" Text="BAŞLANGIÇ BAKİYESİ" OnClick="IslemTurBaslangicBakiye_Click" AutoPostBack="false" />
                                </div>
                            </div>
                            <div class="input-group">
                                <h3>İşlem Adı</h3>
                                <asp:TextBox runat="server" ID="txtIslemAdi" CssClass="txt-islem"></asp:TextBox>
                            </div>
                            <div class="input-group">
                                <h3>Hesap Açıklaması</h3>
                                <asp:TextBox runat="server" ID="txtIslemAciklamasi" CssClass="txt-islem"></asp:TextBox>
                            </div>
                            <div class="input-group">
                                <h3>Tutar</h3>
                                <asp:TextBox runat="server" ID="txtIslemTutar" CssClass="txt-islem" type="number" onkeypress="javascript:return onlyNumbers(event)"></asp:TextBox>
                            </div>
                            <asp:Label runat="server" ID="lblMesaj" CssClass="lbl-mesaj"></asp:Label>

                            <div class="btn-group">
                                <asp:Button runat="server" ID="btnEkle" Text="EKLE" CssClass="btn-islem" OnClick="btnEkle_Click" AutoPostBack="false" />
                                <asp:Button runat="server" ID="btnTamamla" Text="TAMAMLA" CssClass="btn-islem" />
                            </div>
                        </div>
                    </div>

                </asp:Panel>
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="btnGelir" EventName="Click" />
            </Triggers>
        </asp:UpdatePanel>
    </div>
    <asp:UpdatePanel runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel runat="server" ID="pnlIslemleriGoruntule" CssClass="pnl-islemleri-goruntule">
                <div class="islemler-goruntule">

                    <h1>Yapılan İşlemler</h1>
                    <asp:DataList runat="server" ID="dListIslemleriGoruntule" CssClass="dList" OnItemDataBound="Box_Shadow_ItemDataBound">
                        <ItemTemplate>
                            <asp:Panel runat="server" ID="islemRow">
                                <div runat="server" class="islem-row" id="boxShadow">
                                    <div class="islem-info">
                                        <label id="islem-adi-id-<%#Eval("id")%>"><%# Eval("islem_adi") %></label>
                                        <label id="islem-aciklamasi-id-<%#Eval("id")%>"><%# Eval("islem_aciklamasi") %></label>
                                    </div>
                                    <div class="islem-info">
                                        <label id="islem-tutar-id-<%#Eval("id")%>"><%# Convert.ToDecimal(Eval("islem_tutar")).ToString("C") %></label>
                                        <label id="islem-tarihi-id-<%#Eval("id")%>"><%# Eval("islem_tarihi") %></label>
                                    </div>
                                    <div class="islem-icons">
                                        <a onclick="ShowEdit(<%#Eval("id")%>)"><i class="fa-solid fa-pen-to-square"></i></a>
                                    </div>
                                </div>
                            </asp:Panel>
                            <asp:Panel runat="server" ID="islemDuzenleRow">
                                <div class="islem-duzenle" id="<%#Eval("id")%>">
                                    <h1>İşlem Düzenle</h1>
                                    <asp:LinkButton runat="server" ID="btnIslemSil" OnClientClick="ShowSure()" Text="<i class='fa-solid fa-trash'></i>" CssClass="islem-link-btn" />
                                    <asp:TextBox runat="server" ID="txtHesapIslemId" CssClass="none"></asp:TextBox>
                                    <div class="input-group-duzenle">
                                        <h3>İşlem Adı</h3>
                                        <asp:TextBox runat="server" ID="txtDuzenleIslemAdi" CssClass="txt-islem txt-islem-adi"></asp:TextBox>
                                        <asp:RequiredFieldValidator runat="server" ID="txtDuzenleIslemAdiValidator"
                                            ErrorMessage="Boş bırakılamaz" ControlToValidate="txtDuzenleIslemAdi" ForeColor="Red"></asp:RequiredFieldValidator>
                                    </div>
                                    <div class="input-group-duzenle">
                                        <h3>İşlem Açıklaması</h3>
                                        <asp:TextBox runat="server" ID="txtDuzenleIslemAciklamasi" CssClass="txt-islem txt-islem-aciklamasi"></asp:TextBox>
                                        <asp:RequiredFieldValidator runat="server" ID="txtDuzenleIslemAciklamasiValidator"
                                            ErrorMessage="Boş bırakılamaz" ControlToValidate="txtDuzenleIslemAciklamasi" ForeColor="Red"></asp:RequiredFieldValidator>
                                    </div>
                                    <div class="input-group-duzenle">
                                        <h3>İşlem Tutar</h3>
                                        <asp:TextBox runat="server" ID="txtDuzenleIslemTutar" CssClass="txt-islem txt-islem-tutar" type="number" onkeypress="javascript:return onlyNumbers(event)"></asp:TextBox>
                                        <asp:RequiredFieldValidator runat="server" ID="txtDuzenleIslemTutarValidator"
                                            ErrorMessage="Boş bırakılamaz" ControlToValidate="txtDuzenleIslemTutar" ForeColor="Red"></asp:RequiredFieldValidator>
                                    </div>
                                    <div class="input-group-duzenle">
                                        <h3>İşlem Tarihi</h3>
                                        <asp:TextBox runat="server" ID="txtDuzenleIslemTarihi" CssClass="txt-islem txt-islem-tarihi" Enabled="false"></asp:TextBox>
                                    </div>
                                    <div class="button-group">
                                        <asp:Button runat="server" ID="btnDuzenleKaydet" CssClass="btn-duzenle" Text="KAYDET" OnClick="btnDuzenleKaydet_Click" />
                                        <a onclick="CloseEdit(<%#Eval("id")%>)" class="btn-duzenle">İPTAL</a>
                                    </div>
                                </div>
                            </asp:Panel>
                        </ItemTemplate>
                    </asp:DataList>
                </div>

            </asp:Panel>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnEkle" EventName="Click" />
        </Triggers>
    </asp:UpdatePanel>

    <div class="emin-misin-container" id="eminMisin">
        <div class="emin-misin">
            <h2>İşlem Sil</h2>
            <p>Hesap İşlemini silmek istediğinden emin misin ?</p>
            <div class="emin-misin-btn-group">
                <asp:Button runat="server" ID="btnYinedeSil" Text="SİL" CssClass="btn-emin-misin" OnClick="btnYinedeSil_Click" />
                <a class="btn-emin-misin" onclick="CloseSure()">İPTAL</a>
            </div>
        </div>
    </div>

    <script>

        window.onload = function () {
            var link = document.querySelector("#islemler");
            link.classList.toggle("active-menu-item");
        }

        function onlyNumbers(event) {
            var keyCode = (event.which) ? event.which : event.keyCode;
            if (keyCode < 48 || keyCode > 57) {
                alert("Sadece sayı giriniz!");
                return false;
            }
            else {
                return true;
            }
        }

        function Blur() {
            var link = document.getElementById("islemDuzenleContainer");
            link.style.display = "flex";
        }
        function ShowEdit(id) {
            var islemEdit = document.getElementById(id);
            var dataList = document.getElementById("<%=dListIslemleriGoruntule.ClientID%>");


            var islemAdi = document.getElementById("islem-adi-id-" + id);
            var islemAciklamasi = document.getElementById("islem-aciklamasi-id-" + id);
            var islemTutar = document.getElementById("islem-tutar-id-" + id);
            var islemTarihi = document.getElementById("islem-tarihi-id-" + id);

            var texts = dataList.getElementsByTagName("input");

            for (var i = 0; i < texts.length; i++) {

                if (texts[i].classList.contains("txt-islem-adi")) {
                    texts[i].value = islemAdi.textContent;
                }
                else if (texts[i].classList.contains("txt-islem-aciklamasi")) {
                    texts[i].value = islemAciklamasi.textContent;
                }
                else if (texts[i].classList.contains("txt-islem-tutar")) {
                    texts[i].value = islemTutar.textContent;
                }
                else if (texts[i].classList.contains("txt-islem-tarihi")) {
                    texts[i].value = islemTarihi.textContent;
                }
                else if (texts[i].classList.contains("none")) {
                    texts[i].value = id;
                    texts[i].style.display = "none";
                }

            }


            islemEdit.style.display = "block";
        }
        function CloseEdit(id) {
            var link = document.getElementById(id);
            link.style.display = "none";
        }
        function ShowSure() {
            var link = document.getElementById("eminMisin");
            link.style.display = "flex";

        }
        function CloseSure() {
            var link = document.getElementById("eminMisin");
            link.style.display = "none";
        }
    </script>
</asp:Content>
