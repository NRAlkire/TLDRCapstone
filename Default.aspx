<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TLDR_Capstone._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

	<div class="jumbotron">
        <h1>Schedule Planner</h1>
		
        <div style="text-align: center;">
            <div style="width: 213px; margin-left: auto; margin-right:auto;">
                <asp:Login ID="Login" runat="server" OnAuthenticate="Login_Authenticate" />
            </div>
        </div>
        <div>

        	<asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>

        </div>
    </div>
</asp:Content>