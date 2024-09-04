<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/BP_MasterPage.Master" AutoEventWireup="true" CodeBehind="BP_Notlar.aspx.cs" Inherits="BUDGET_PLANNER_.nett.Pages.BP_Notlar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Styles/BP_NotlarStyle.css" rel="stylesheet" />
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.6.0/css/all.min.css"
        integrity="sha512-Kc323vGBEqzTmouAECnVceyQqyqdsSiqLQISBL29aUW4U/M7pSPA/gEUZQqv1cwx4OnYxTxve5UMg5GT6L4JJg=="
        crossorigin="anonymous" referrerpolicy="no-referrer" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager runat="server"></asp:ScriptManager>
    <div class="notlar-baslik">
        <h1>İşletmeniz için notlar oluşturun!</h1>
        <a class="btn-not-ekle" onclick="AddNote()">Not Oluştur</a>
    </div>

    <div class="notlar-container" id="notlarContainer">
        <div>
            <ul class="tablo-basliklar">
                <li>Adı</li>
                <li>Açıklaması</li>
                <li>Kalan Süre</li>
                <li class="son-eleman">Oku</li>
            </ul>

        </div>
        <asp:UpdatePanel runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <asp:DataList runat="server" ID="dListNotlar">
                    <ItemTemplate>
                        <ul class="tablo-elemanlar">
                            <li style="overflow:hidden;"><a id="adi-eleman-<%#Eval("adi") %>"><%#Eval("adi") %></a></li>
                            <li style="overflow:hidden;" class="aciklama-kisalt"><a id="aciklamasi-eleman-<%#Eval("adi") %>"><%#Eval("aciklamasi") %></a></li>
                            <li><a id="tarih-eleman-<%#Eval("adi") %>"><%#Eval("tarih") %></a></li>
                            <li class="son-eleman">
                                <a onclick="ShowEdit(<%#Eval("id")%>,'adi-eleman-<%#Eval("adi") %>','aciklamasi-eleman-<%#Eval("adi") %>','tarih-eleman-<%#Eval("adi") %>')"><i class='fa-solid fa-eye'></i></a>
                                <a onclick="ShowEditEnable(<%#Eval("id")%>,'adi-eleman-<%#Eval("adi") %>','aciklamasi-eleman-<%#Eval("adi") %>','tarih-eleman-<%#Eval("adi") %>')"><i class="fa-solid fa-pen-to-square"></i></a>
                                <a onclick="ShowSure(<%#Eval("id")%>)"><i class='fa-solid fa-trash'></i></a>
                            </li>
                        </ul>
                    </ItemTemplate>
                </asp:DataList>
                <asp:TextBox runat="server" ID="txtNotlarID" type="hidden" CssClass="txt-hidden"></asp:TextBox>
                <asp:Panel runat="server" ID="pnlNotBulunamadi">
                    <h2 style="text-align: center; font-size: 22px; margin-top: 50px; padding: 40px;" runat="server" id="hesapBulunamadi">Herhangi bir not bulunmamaktadır.</h2>
                </asp:Panel>
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="btnYinedeSil" EventName="Click" />
                <asp:AsyncPostBackTrigger ControlID="btnNotOlustur" EventName="Click" />
                <asp:AsyncPostBackTrigger ControlID="btnNotDuzenleKaydet" EventName="Click" />

            </Triggers>
        </asp:UpdatePanel>
    </div>

    <div class="not-olustur" id="notOlustur">
        <div class="input-group">
            <p>Adı</p>
            <asp:TextBox runat="server" ID="txtAdi" CssClass="txt-adi" placeholder="Not adı.."></asp:TextBox>
        </div>
        <div class="input-group">
            <p>Açıklaması</p>
            <asp:TextBox runat="server" ID="txtAciklamasi" CssClass="txt-aciklamasi" placeholder="Not açıklaması.."></asp:TextBox>
        </div>
        <asp:Label runat="server" ID="lblMesaj" ForeColor="Red"></asp:Label>
        <div class="input-group">
            <asp:Button runat="server" ID="btnNotOlustur" Text="OLUŞTUR" CssClass="btn-olustur" OnClick="btnNotOlustur_Click" OnClientClick="ShowNotes()"/>
            <a class="btn-iptal" onclick="ShowNotes()">IPTAL</a>
        </div>
    </div>

    <div class="emin-misin-container" id="eminMisin">
        <div class="emin-misin" runat="server">
            <h2>İşlem Sil</h2>
            <p>Hesap İşlemini silmek istediğinden emin misin ?</p>
            <div class="emin-misin-btn-group">
                <asp:Button runat="server" ID="btnYinedeSil" Text="SİL" CssClass="btn-emin-misin" OnClick="btnYinedeSil_Click" OnClientClick="CloseSure()"/>
                <a class="btn-emin-misin" onclick="CloseSure()">İPTAL</a>
            </div>
        </div>
    </div>

    <div class="not-goruntule-container" id="notGoruntule">
        <div class="not-goruntule">
            <h2 style="text-align:center;">Not Görüntüle</h2>
            <div class="goruntule-group">
                <p>Not Adı</p>
                <asp:Label runat="server" ID="lblNotAdi" CssClass="lbl-goruntule"></asp:Label>
            </div>
            <div class="goruntule-group">
                <p>Not Açıklaması</p>
                <asp:Label runat="server" ID="lblNotAciklamasi" CssClass="lbl-goruntule"></asp:Label>
            </div>
            <div class="goruntule-group">
                <p>Oluşturulma Tarihi</p>
                <asp:Label runat="server" ID="lblNotTarih"></asp:Label>
            </div>
            <div class="goruntule-group btn-group">
                <a class="btn-goruntule-kapat" onclick="CloseEdit()">KAPAT</a>
            </div>
        </div>
    </div>

    <div class="not-duzenle-container" id="notDuzenle">
        <div class="not-duzenle">
            <h2 style="text-align:center;">Not Düzenle</h2>
            <div class="duzenle-group">
                <p>Not Adı</p>
                <asp:TextBox runat="server" ID="txtDuzenleNotAdi" CssClass="txt-duzenle-adi"></asp:TextBox>
            </div>
            <div class="duzenle-group">
                <p>Not Açıklaması</p>
                <asp:TextBox runat="server" ID="txtDuzenleNotAciklamasi" CssClass="txt-duzenle-aciklamasi"></asp:TextBox>
            </div>
            <div class="duzenle-group">
                <p>Oluşturulma Tarihi</p>
                <asp:TextBox runat="server" ID="txtDuzenleNotTarih" CssClass="txt-duzenle-tarih" disabled="disabled"></asp:TextBox>
            </div>
            <asp:Label runat="server" ID ="lblDuzenleMesaj" ForeColor="Red"></asp:Label>
            <div class="duzenle-group btn-group">
                <asp:Button runat="server" ID="btnNotDuzenleKaydet" Text="KAYDET" CssClass="btn-not-duzenle-kaydet" OnClick="btnNotDuzenleKaydet_Click" OnClientClick="CloseEditEnable()"/>
                <a class="btn-goruntule-kapat" onclick="CloseEditEnable()">KAPAT</a>
            </div>
        </div>
    </div>

    <script>

        window.onload = function () {
            var link = document.querySelector("#notlar");
            link.classList.toggle("active-menu-item");
        }

        function AddNote() {
            var link2 = document.getElementById("notlarContainer");
            var link = document.getElementById("notOlustur");
            link.style.display = "block";
            link2.style.display = "none";
        }
        function ShowNotes() {
            var link2 = document.getElementById("notlarContainer");
            var link = document.getElementById("notOlustur");
            link.style.display = "none";
            link2.style.display = "block";
        }
        function ShowSure(id) {
            var link = document.getElementById("eminMisin");
            link.style.display = "flex";

            var text = document.getElementById("<%=txtNotlarID.ClientID%>");
            text.value = id;
                        

        }
        function ShowEdit(id, adi, aciklamasi, tarih) {
            var link = document.getElementById("notGoruntule");
            link.style.display = "flex";

            var text = document.getElementById("<%=txtNotlarID.ClientID%>");
            text.value = id;

            var lblAdi = document.getElementById("<%=lblNotAdi.ClientID%>")
            var lblAciklamasi = document.getElementById("<%=lblNotAciklamasi.ClientID%>")
            var lblTarih = document.getElementById("<%=lblNotTarih.ClientID%>")

            var adiEleman = document.getElementById(adi).textContent;
            var aciklamasiEleman = document.getElementById(aciklamasi).textContent;
            var tarihEleman = document.getElementById(tarih).textContent;


            lblAdi.textContent = adiEleman;
            lblAciklamasi.textContent = aciklamasiEleman;
            lblTarih.textContent = tarihEleman;

        }
        function ShowEditEnable(id , adi , aciklamasi , tarih) {
            var link = document.getElementById("notDuzenle");
            link.style.display = "flex";

            var text = document.getElementById("<%=txtNotlarID.ClientID%>");
            text.value = id;

            var txtDuzenleNotAdi = document.getElementById("<%=txtDuzenleNotAdi.ClientID%>")
            var txtDuzenleNotAciklamasi = document.getElementById("<%=txtDuzenleNotAciklamasi.ClientID%>")
            var txtDuzenleNotTarih = document.getElementById("<%=txtDuzenleNotTarih.ClientID%>")

            var adiEleman = document.getElementById(adi).textContent;
            var aciklamasiEleman = document.getElementById(aciklamasi).textContent;
            var tarihEleman = document.getElementById(tarih).textContent;

            txtDuzenleNotAdi.value = adiEleman;
            txtDuzenleNotAciklamasi.value = aciklamasiEleman;
            txtDuzenleNotTarih.value = tarihEleman;

        }
        function CloseEditEnable() {
            var link = document.getElementById("notDuzenle");
            link.style.display = "none";
        }
        function CloseEdit() {
            var link = document.getElementById("notGoruntule");
            link.style.display = "none";
        }
        function CloseSure() {
            var link = document.getElementById("eminMisin");
            link.style.display = "none";

        }
    </script>

</asp:Content>
