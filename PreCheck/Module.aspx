<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Module.aspx.cs" Inherits="PreCheck.Module" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <div class="row">
            <div class="col-md-12" style="height: 10px; background-color: #013713">
            </div>
        </div>
        <div class="row">
            <div class="col-md-3"></div>
            <div class="col-md-3"></div>
            <div class="col-md-3" id="divTodayAverage" runat="server"></div>
            <div class="col-md-3" id="divAllAverage" runat="server"></div>
        </div>
        <div class="row">
            <asp:Button ID="btnRefresh" runat="server" Text="Refresh" CssClass="btn btn-default" />
            <div class="col-md-12" style="font-size: 1.2em; text-align: center;">
                <div id="divTableVOE" runat="server"></div>
            </div>
        </div>
        <div class="row">
            <div class="col-md-12" style="height: 10px; background-color: #696969">
            </div>
        </div>
        <div class="row">
        </div>
        <div class="row">
            <div class="col-md-12" style="height: 10px; background-color: #696969">
            </div>
        </div>
        <div class="row">
        </div>
    </div>
</asp:Content>
