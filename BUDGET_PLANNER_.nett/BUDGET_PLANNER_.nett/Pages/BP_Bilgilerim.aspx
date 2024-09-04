<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/BP_MasterPage.Master" AutoEventWireup="true" CodeBehind="BP_Bilgilerim.aspx.cs" Inherits="BUDGET_PLANNER_.nett.Pages.BP_Bilgilerim" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Styles/BP_BilgilerimStyle.css" rel="stylesheet" />
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
                                    <label>ADI SOYADI</label>
                                </div>
                                <h3><%# Eval("adi") %> <%# Eval("soyadi") %></h3>
                            </li>
                            <li>
                                <div>
                                    <i class="fa-solid fa-envelope"></i>
                                    <label>E-POSTA ADRESİ</label>
                                </div>
                                <h3><%# Eval("mail") %></h3>
                            </li>
                            <li>
                                <div>
                                    <i class="fa-solid fa-circle-user"></i>
                                    <label>KULLANICI ADI</label>
                                </div>
                                <h3><%# Eval("kul_adi") %></h3>
                            </li>
                            <li>
                                <div>
                                    <i class="fa-solid fa-lock"></i>
                                    <label>PAROLA</label>
                                </div>
                                <h3>***********</h3>
                            </li>
                        </ItemTemplate>
                    </asp:DataList>
                </ul>
            </div>
        </div>

        <div class="form-duzenle" id="formDuzenle">
            <h1>Bilgilerimi Düzenle</h1>
            <ul>
                <li class="column-3">
                    <div>
                        <i class="fa-solid fa-user"></i>
                        <label>ADI SOYADI</label>
                    </div>
                    <div>
                        <asp:TextBox runat="server" ID="txtAdSoyad" CssClass="txt"></asp:TextBox>
                        <asp:RequiredFieldValidator runat="server" ID="txtAdSoyadValidator"
                            ErrorMessage="Boş bırakılamaz" ControlToValidate="txtAdSoyad" ForeColor="Red"></asp:RequiredFieldValidator>
                    </div>
                    <div>
                        <a class="btn-vazgec" onclick="DuzenleKapat()">VAZGEÇ</a>
                        <asp:Button runat="server" ID="btnKaydet" CssClass="btn-kaydet" Text="KAYDET" OnClick="btnKaydet_Click" />
                    </div>
                </li>
                <li class="column-2">
                    <div>
                        <i class="fa-solid fa-envelope"></i>
                        <label>E-MAIL</label>
                    </div>
                    <div>
                        <asp:UpdatePanel runat="server">
                            <ContentTemplate>
                                <asp:Label runat="server" ID="lblMail" CssClass="lbl-mail"></asp:Label>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="btnDegistir" EventName="Click" />
                            </Triggers>
                        </asp:UpdatePanel>
                    </div>
                    <div>
                        <a class="mail-degistir" onclick="Blur()">DEĞİŞTİR</a>
                    </div>
                </li>
                <li class="column-2">
                    <div>
                        <i class="fa-solid fa-circle-user"></i>
                        <label>KULLANICI ADI</label>
                    </div>
                    <div>
                        <asp:TextBox runat="server" ID="txtKulAdi" CssClass="txt"></asp:TextBox>
                    </div>
                </li>
                <li>
                    <div class="parola-box">
                        <div>
                            <i class="fa-solid fa-lock"></i>
                            <label>MEVCUT PAROLA</label>
                        </div>
                        <div>
                            <asp:TextBox runat="server" ID="txtMevcutParola" CssClass="txt"></asp:TextBox>
                        </div>
                    </div>
                    <div class="parola-box">
                        <div>
                            <i class="fa-solid fa-lock"></i>
                            <label>YENİ PAROLA</label>
                        </div>
                        <div>
                            <asp:TextBox runat="server" ID="txtYeniParola" CssClass="txt"></asp:TextBox>
                        </div>
                    </div>
                    <div class="parola-box">
                        <div>
                            <i class="fa-solid fa-lock"></i>
                            <label>YENİ PAROLA TEKRAR</label>
                        </div>
                        <div>
                            <asp:TextBox runat="server" ID="txtYeniParolaTekrar" CssClass="txt"></asp:TextBox>
                        </div>
                    </div>
                </li>
            </ul>
            <asp:UpdatePanel runat="server">
                <ContentTemplate>
                    <asp:Label runat="server" ID="lblKaydetMesaj"></asp:Label>
                </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="btnKaydet" EventName="Click"/>
                </Triggers>
            </asp:UpdatePanel>
        </div>

    </div>


    <div class="mail-change-container" id="mailChangeContainer">
        <div class="mail-change">
            <asp:UpdatePanel runat="server">
                <ContentTemplate>
                    <h2>Yeni e-posta adresiniz</h2>
                    <div class="metin">
                        <p>
                            Belirleyeceğiniz yeni e-posta adresine bir doğrulama mesajı göndereceğiz. Değiştirme işlemi yeni e-posta adresinizi doğruladığınızda tamamlanacak.
                        </p>
                    </div>
                    <div class="yeni-mail">
                        <p>Yeni e-posta adresinizi belirleyin:</p>
                        <asp:TextBox runat="server" ID="txtYeniMail" CssClass="txtMail" type="email"></asp:TextBox>
                    </div>
                    <asp:Panel runat="server" ID="pnlKod" CssClass="pnl-kod">
                        <div class="rastgele-kod">
                            <p>Kod</p>
                            <asp:TextBox runat="server" ID="txtKod" CssClass="txtMail" type="number"></asp:TextBox>
                        </div>
                    </asp:Panel>
                    <div>
                        <asp:Label runat="server" ID="lblMesaj"></asp:Label>
                    </div>
                    <div class="buttons">
                        <asp:Button runat="server" ID="btnKodGonder" Text="GÖNDER" CssClass="btn-kod-gonder" OnClick="btnKodGonder_Click" />
                        <a class="btn-vazgec" onclick="UnBlur()">VAZGEÇ</a>
                        <asp:Button runat="server" ID="btnDegistir" Text="DEĞİŞTİR" CssClass="btn-degistir" OnClick="btnDegistir_Click" />
                        <a runat="server" id="btnTamamla" class="btn-tamamla" onclick="UnBlur()">TAMAMLA</a>
                    </div>
                </ContentTemplate>
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
        function UnBlur() {
            var link = document.getElementById("mailChangeContainer");
            link.style.display = "none";
        }
        function Blur() {
            var link = document.getElementById("mailChangeContainer");
            link.style.display = "flex";
        }
        function showMailCodeField() {
            var link = document.querySelector(".btn-kod-gonder");

            if (link.style.display == "none") {
                document.querySelector(".rastgele-kod").style.display = "block";
                document.querySelector(".yeni-mail").style.display = "none";
            }
        }
    </script>
</asp:Content>
