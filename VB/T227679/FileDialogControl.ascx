<%@ Control Language="vb" AutoEventWireup="true" CodeBehind="FileDialogControl.ascx.vb"
    Inherits="T227679.FileDialogControl" %>
<%@ Register Assembly="DevExpress.Web.v14.2, Version=14.2.9.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web" TagPrefix="dx" %>
<script type="text/javascript">    
    var <%=Me.ClientInstanceName%> = new ClientFileDialogControl('<%=Me.ClientInstanceName%>');
    <%=Me.ClientInstanceName%>.initializeControl = function() {
        this.popup = <%=popup.ClientID%>;
        this.fileManager = <%=fileManager.ClientID%>;
        this.txFileName = <%=txFileName.ClientID%>;
        this.buttonOk = <%=buttonOk.ClientID%>;        
        this.validationCallback = <%=validationCallback.ClientID%>
    };
</script>
<dx:ASPxCallback ID="validationCallback" runat="server" OnCallback="validationCallback_Callback">
</dx:ASPxCallback>
<dx:ASPxPopupControl ID="popup" runat="server" EnableClientSideAPI="true" Width="0px"
    Height="0px" CloseAction="CloseButton" Modal="True" PopupHorizontalAlign="WindowCenter"
    PopupVerticalAlign="WindowCenter">
    <ContentStyle>
        <Paddings Padding="0px" />
    </ContentStyle>
    <ContentCollection>
        <dx:PopupControlContentControl runat="server">
            <dx:ASPxFormLayout ID="flDialog" runat="server" ColCount="3">
                <Items>
                    <dx:LayoutItem ColSpan="3" ShowCaption="False">
                        <LayoutItemNestedControlCollection>
                            <dx:LayoutItemNestedControlContainer runat="server">
                                <dx:ASPxFileManager ID="fileManager" runat="server" Width="800px" Height="500px">
                                    <Settings RootFolder="~\ReportsStorage\" ThumbnailFolder="~\Thumb\" />
                                    <SettingsFileList View="Details">
                                    </SettingsFileList>
                                    <%-- File modificateions are not allowed. --%>
                                    <%--<SettingsEditing AllowCopy="True" AllowDelete="True" AllowDownload="True" AllowMove="True"
                                        AllowRename="True" />--%>
                                    <SettingsUpload Enabled="False">
                                    </SettingsUpload>
                                </dx:ASPxFileManager>
                            </dx:LayoutItemNestedControlContainer>
                        </LayoutItemNestedControlCollection>
                    </dx:LayoutItem>
                    <dx:LayoutItem Caption="File Name">
                        <LayoutItemNestedControlCollection>
                            <dx:LayoutItemNestedControlContainer runat="server">
                                <dx:ASPxTextBox ID="txFileName" runat="server" EnableClientSideAPI="true" Width="450px">
                                </dx:ASPxTextBox>
                            </dx:LayoutItemNestedControlContainer>
                        </LayoutItemNestedControlCollection>
                    </dx:LayoutItem>
                    <dx:EmptyLayoutItem ColSpan="2">
                    </dx:EmptyLayoutItem>
                    <dx:EmptyLayoutItem>
                    </dx:EmptyLayoutItem>
                    <dx:LayoutItem ShowCaption="False" HorizontalAlign="Right">
                        <LayoutItemNestedControlCollection>
                            <dx:LayoutItemNestedControlContainer runat="server">
                                <dx:ASPxButton ID="buttonOk" runat="server" EnableClientSideAPI="true" Width="100px"
                                    Text="OK" AutoPostBack="false">
                                </dx:ASPxButton>
                            </dx:LayoutItemNestedControlContainer>
                        </LayoutItemNestedControlCollection>
                    </dx:LayoutItem>
                    <dx:LayoutItem ShowCaption="False" HorizontalAlign="Right">
                        <LayoutItemNestedControlCollection>
                            <dx:LayoutItemNestedControlContainer runat="server">
                                <dx:ASPxButton ID="buttonCancel" runat="server" EnableClientSideAPI="true" Width="100px"
                                    Text="Cancel" AutoPostBack="false">
                                </dx:ASPxButton>
                            </dx:LayoutItemNestedControlContainer>
                        </LayoutItemNestedControlCollection>
                    </dx:LayoutItem>
                </Items>
            </dx:ASPxFormLayout>
        </dx:PopupControlContentControl>
    </ContentCollection>
</dx:ASPxPopupControl>