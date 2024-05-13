<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="take_notes.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-11">
            <h1 style="margin-top: 12px">Welcome back!</h1>
            <h5>These are your taken notes</h5>
        </div>
        <div class="col-1">
            <asp:Button ID="btnAddNote" CssClass="btn btn-primary" runat="server" Text="Add" Style="margin-top: 26px; width: 86px; height: 76px" OnClick="btnAddNote_Click" />
        </div>
    </div>
    <hr />
    <div class="row">
        <div class="col-4">
            <label for="ddlFilter" class="form-label">Filter by Category:</label>
            <asp:DropDownList ID="ddlFilter" runat="server" CssClass="form-select"></asp:DropDownList>
        </div>
        <div class="col-8">
            <asp:Button ID="btnFilter" runat="server" Text="Search" CssClass="btn btn-primary" OnClick="btnFilter_Click" style="margin-top:30px;" />
            <asp:Button ID="btnClear" runat="server" Text="Clear" CssClass="btn btn-secondary" OnClick="btnClear_Click" style="margin-top:30px;" />
        </div>
    </div>
    <hr />
    <div class="row">
        <asp:Repeater ID="repRepetidor" runat="server">
            <ItemTemplate>
                <div class="col-lg-3 col-sm-6 col-md-4" style="margin-top: 20px">
                    <div class="card h-100">
                        <div class="card-body">
                            <h5 class="card-title"><%#Eval("Title") %></h5>
                            <hr />
                            <p class="card-text"><%#Eval("Description") %></p>

                            <hr />

                            <div class="row">
                                <div class="col-6">
                                    <h8 class="card-title" style="color: darkorange"><%#Eval("Category.Description") %></h8>
                                </div>
                                <div class="col-6" style="display: flex; justify-content: end;">
                                    <asp:LinkButton ID="btnModify" runat="server" CommandArgument='<%#Eval("Id")%>' CommandName="NoteId" OnClick="btnModify_Click">
                            <i class="bi bi-pencil" style="margin:2px;"></i>
                                    </asp:LinkButton>

                                    <asp:LinkButton ID="btnFile" runat="server" CommandArgument='<%#Eval("Id")%>' CommandName="NoteId" OnClick="btnFile_Click">
                            <i class="bi bi-bookmark-plus" style="margin:2px;"></i>
                                    </asp:LinkButton>

                                    <asp:LinkButton ID="btnDelete" runat="server" CommandArgument='<%#Eval("Id")%>' CommandName="NoteId" OnClientClick="return confirm('¿Estás seguro de que deseas eliminar este elemento?');" OnClick="btnDelete_Click">
                            <i class="bi bi-trash-fill" style="margin:2px;"></i>
                                    </asp:LinkButton>
                                </div>
                            </div>

                        </div>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</asp:Content>
