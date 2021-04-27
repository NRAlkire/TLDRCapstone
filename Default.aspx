<%@ Page Title="Home Page" Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TLDR_Capstone._Default" %>

<head>
	<title>Login form</title>
	<link rel="stylesheet" href="css/stylesheet.css">
</head>
<h1>Student Schedule Planner: Ultimate Edition</h1>
<body>

<div>
	<form class="form-box" runat="server">
		<div style="text-align: center;">

			<div style="width: 213px; margin-left: auto; margin-right: auto;">
				<asp:Login ID="Login" runat="server" OnAuthenticate="Login_Authenticate" >
                    <LayoutTemplate>
                        <table cellpadding="1" cellspacing="0" style="border-collapse:collapse;">
                            <tr>
                                <td>
                                    <table cellpadding="0">
                                        <tr>
                                            <td align="center" colspan="2">Log In</td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                                <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName">Username</asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox class="input-field" ID="UserName" runat="server" placeholder="********"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName" ErrorMessage="User Name is required." ToolTip="Username is required." ValidationGroup="Login">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                                <asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="Password">Password</asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox class="input-field" ID="Password" runat="server" TextMode="Password" placeholder="********"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password" ErrorMessage="Password is required." ToolTip="Password is required." ValidationGroup="Login">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2">
                                                <asp:CheckBox class="check-box" ID="RememberMe" runat="server" Text="Remember me" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center" colspan="2" style="color:Red;">
                                                <asp:Literal ID="FailureText" runat="server" EnableViewState="False"></asp:Literal>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right" colspan="2">
                                                <asp:Button class="submit-btn" ID="LoginButton" runat="server" CommandName="Login" Text="Log In" ValidationGroup="Login" />
                                                <asp:Button class="submit-btn" ID="Button" runat="server" Text="Register" OnClick="gotoRegBtn_Click" />
                                            </td>
                                        </tr>
                                        		</div>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </LayoutTemplate>
                </asp:Login>
			</div>

		</div>
	</form>
</div>
    </body>