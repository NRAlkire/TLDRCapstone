<%@ Page Title="Home Page" Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TLDR_Capstone._Default" %>

<head>
	<title>Login form</title>
	<link rel="stylesheet" href="css/stylesheet.css">
</head>
	<h1>Student Schedule Planner: Ultimate Edition</h1>
<div>
	<form class="form-box" runat="server">
		<div style="text-align: center;">

			<div style="width: 213px; margin-left: auto; margin-right: auto;">
				<asp:Login ID="Login" runat="server" OnAuthenticate="Login_Authenticate" />
			</div>

		</div>
		<div style="text-align: center;">
			<asp:Button class="submit-btn" ID="Button" runat="server" Text="Register" OnClick="gotoRegBtn_Click" />
		</div>
	</form>
</div>