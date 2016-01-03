<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="voe.aspx.cs" Inherits="PreCheck.voe" MaintainScrollPositionOnPostback="true" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .CustomBox{
            width:75%;
            height:150px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <div class="row">
            <div class="col-md-12" style="height: 10px; background-color: #013713"></div>
        </div>
        <div class="row">
            <div class="col-md-6" style="height: 125px; background-color: #e0e1e0; font-size: 2em">
                <span>Employer Info</span>
            </div>
            <div class="col-md-3" style="height: 125px; background-color: #e0e1e0; font-size: 2em">
                <span>Employer Info</span>
            </div>
            <div class="col-md-3" style="height: 125px; font-size: 1.4em">
                <br />
                <asp:Button ID="btnLock" runat="server" Text="Start" CssClass="btn btn-warning" OnClick="btnLock_Click" />
                <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="btn btn-primary" Enabled="false" OnClick="btnSubmit_Click" />
            </div>
            <br /><br /><br /><br />
        </div>
        <div class="row">
            <div class="col-md-12" style="height: 10px; background-color: #696969"></div>
        </div>
        <div class="row">
            <div class="col-md-6" style="height: 125px; background-color: #bbbbbb; font-size: 2em">
                <span>Applicant Info</span>
            </div>
            <div class="col-md-3" style="height: 125px; background-color: #bbbbbb; font-size: 2em">
                <span>Applicant Info</span>
            </div>
            <div class="col-md-3" style="height: 125px; font-size: 1.4em">
                <br />
                <a href="Module.aspx">Back By Line</a>
            </div>
            <br /><br /><br /><br />
        </div>
        <div class="row">
            <div class="col-md-12" style="height: 10px; background-color: #696969"></div>
        </div>
        <div class="row" style="font-size:1.2em;background-color:#d1d1d1">
            <div class="col-md-4" style="text-align:center;">
                <label class="label label-default">Public Notes</label>
                <br />
                <asp:TextBox ID="txtPublicNotes" runat="server" TextMode="MultiLine" CssClass="CustomBox" Enabled="false"></asp:TextBox>
            </div>
            <div class="col-md-4" style="text-align:center;">
                <label class="label label-default">Signoff</label>
                <br />
                <asp:TextBox ID="txtSignOff" runat="server" TextMode="MultiLine" Enabled="false"></asp:TextBox>
                <br />
                <div runat="server" id="divBtns"></div>
            </div>
            <div class="col-md-4" style="text-align:center;">
                <label class="label label-default">Private Notes</label>
                <br />
                <asp:TextBox ID="txtPrivateNotes" runat="server" TextMode="MultiLine" CssClass="CustomBox" Enabled="false"></asp:TextBox>
            </div>
        </div>
    </div>
    <asp:HiddenField ID="hdnDate" runat="server" />
</asp:Content>
