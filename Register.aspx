<%@ Page Title="Register User Page" Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="TLDR_Capstone.Register" %>
<link rel="stylesheet" href="css/stylesheet.css">
	<h1>Schedule Planner: Register User</h1>
	<form runat="server">
	<div class="form-box">
		<div style=float: left; text-align: left">
			<div>Username:  </div>

			<div>Password:  </div>

			<div>Confirm Password:  </div>

			<div>Email:  </div>

			<div>Access Level Requested:  </div>
		</div>
		<div style="width: 50%; float: right">
			
			<div style="height: 30px" runat="server">
				<asp:TextBox ID="userTB" runat="server" Height="20px"></asp:TextBox>
			</div>
			<div style="height: 30px">
				<asp:TextBox ID="passTB" runat="server" Height="20px" TextMode="Password"></asp:TextBox>
			</div>
			<div style="height: 30px">
				<asp:TextBox ID="passConfTB" runat="server" Height="20px" TextMode="Password"></asp:TextBox>
			</div>
			<div style="height: 30px">
				<asp:TextBox ID="emailTB" runat="server" Height="20px"></asp:TextBox>
			</div>
			<div style="height: 30px">
				<asp:DropDownList ID="accessLvlDD" runat="server" Height="20px">
					<asp:ListItem Value="1">Student</asp:ListItem>
					<asp:ListItem Value="2">Admin</asp:ListItem>
					<asp:ListItem Value="3">Root User</asp:ListItem>
				</asp:DropDownList>
			</div>
			
		</div>
			<div style="text-align: center">

		<asp:Button ID="regBtn" runat="server" Text="Register" OnClick="regBtn_Click1" />
		<asp:Label ID="debug" runat="server" Text="debug"></asp:Label>
	</div>

	</form>