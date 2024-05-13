<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Archived.aspx.cs" Inherits="take_notes.Archived" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <h1 style="margin-top: 12px">Archived Notes</h1>
        <hr />
        <div>
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
                                        <div class="col-6" style="display:flex; justify-content:end;">
                                            <asp:LinkButton ID="btnUnfile" runat="server" CommandArgument='<%#Eval("Id")%>' CommandName="NoteId" OnClick="btnUnfile_Click">
                            <i class="bi bi-bookmark-dash"></i>
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
