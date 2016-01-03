<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="test.aspx.cs" Inherits="PreCheck.test" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="ContentPlaceHolder1_divBtns">
        <button class="btn btn-info" id="btnShowPrivateLogs">Private Logs</button>&nbsp;&nbsp;&nbsp;
        <button class="btn btn-info" id="btnShowPublicLogs">Public Logs</button>
        <div id="divPrivateNotes">12/21/2015 Blah Blah -HAyala</div>
        <div id="divPublicNotes">12/21/2015 Blah Blah -HAyala</div>
        <script>
            $(document).ready(function () {
                $("#divPrivateNotes").dialog({ autoOpen: false, show: "blind", hide: "explode" });
                $("#divPublicNotes").dialog({ autoOpen: false, show: "blind", hide: "explode" });
                $("#btnShowPrivateLogs").click(function () {
                    $("#divPrivateNotes").dialog("open");
                    return false;
                });
                $("#btnShowPublicLogs").click(function () {
                    return false;
                });
            });

        </script>
    </div>
</asp:Content>
