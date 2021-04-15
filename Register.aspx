<%@ Page Title="Register User Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="TLDR_Capstone.Register" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

	<h1>Schedule Planner: Register User</h1>
	<div>
		<div style="width: 50%; float: left; text-align: right">
			<div style="height: 30px">Username:  </div>

			<div style="height: 30px">Password:  </div>

			<div style="height: 30px">Confirm Password:  </div>

			<div style="height: 30px">Access Level Requested:  </div>
		</div>
		<div style="width: 50%; float: right">
			<div style="height: 30px">
				<asp:TextBox ID="userTB" runat="server" Height="20px"></asp:TextBox>
			</div>
			<div style="height: 30px">
				<asp:TextBox ID="passTB" runat="server" Height="20px" TextMode="Password"></asp:TextBox>
			</div>
			<div style="height: 30px">
				<asp:TextBox ID="passConfTB" runat="server" Height="20px" TextMode="Password"></asp:TextBox>
			</div>
			<div style="height: 30px">
				<asp:DropDownList ID="accessLvlDD" runat="server" Height="20px">
					<asp:ListItem Value="1">Student</asp:ListItem>
					<asp:ListItem Value="2">Admin</asp:ListItem>
					<asp:ListItem Value="3">Root User</asp:ListItem>
				</asp:DropDownList>
			</div>
		</div>
	</div>
	<div style="text-align: center">

		<asp:Button ID="regBtn" runat="server" Text="Register" OnClick="regBtn_Click1" />
		<asp:Label ID="debug" runat="server" Text="debug"></asp:Label>
	</div>

</asp:Content>
