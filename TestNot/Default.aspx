<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TestNot._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
    <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
    <div id="here">
    <asp:GridView ID="GridView1" runat="server"></asp:GridView>
        </div>
<%--    <script>
        setTimeout(function () {
            window.location.reload(1);            
        }, 3000);
    </script>--%>
    <%--<script>
        $(document).ready(function () {
            setInterval(function () {
                $("#GridView1").load(window.location.href + " #GridView1");
            }, 3000);
        });
    </script>--%>
    <script> 
        $(document).ready(function () {
            setInterval(function () {
                $("#here").load(window.location.href + " #here");
            }, 3000);
        });
    </script>
</asp:Content>
