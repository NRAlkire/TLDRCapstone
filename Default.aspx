<%@ Page Title="Home Page" Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TLDR_Capstone._Default" %>

<div class="jumbotron">
	<h1>Schedule Planner: Login</h1>

	<form runat="server">
		<div style="text-align: center;">

			<div style="width: 213px; margin-left: auto; margin-right: auto;">
				<asp:Login ID="Login" runat="server" OnAuthenticate="Login_Authenticate" />
			</div>

		</div>
		<div style="text-align: center;">
			<asp:Button ID="gotoRegBtn" runat="server" Text="Sign-up" OnClick="gotoRegBtn_Click" />
		</div>
	</form>
</div>
