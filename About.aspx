<%@ Page Title="About" Language="C#" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="TLDR_Capstone.About" %>

    <h2><%: Title %>.</h2>
    <h3>Your application description page.</h3>
    <p>Use this area to provide additional information.</p>
	<br />
	<asp:Button ID="importBtn" runat="server" OnClick="importBtn_Click" Text="Import Courses" />
</asp:Content>
