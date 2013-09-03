using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.SqlClient;


public class Common_Message
{
    #region Private Fields

    private string _HeaderNotSaved = "Header record is not saved.";
    private string _AddLineItem = "Please add atleast one line item.";
    private string _ErrorToLineItem = "Record is not added in list.";
    private string _LineItemNotSaved = "Line item record is not saved.";
    private string _RecordSaved = "Record is saved successfully.";
    private string _RecordNotSaved = "Record is not saved.";
    private string _SelectValue = "Please select value for search.";
    private string _NoRecordFound = "No record found.";
    private string _TotalRecord = "Total Records: ";
    private string _FillPalletInf = "Please fill the Pallet Information.";
    private string _PackingCreated = "Packing list is already created for selected order no.";
    private string _RecordUpdated = "Record has been updated successfully.";
    private string _RecordNotUpdate = "Problem in updating record.Connection Error.";
    private string _RoleAllocated = "Either rolls are allocated or no matching found in inventory.";
    private string _RoleDeallocated = "Either rolls are deallocated or no matching found in inventory.";
    private string _SelectCustomer = "Please select customer first.";
    private string _RollsTransfered = "Either rolls are transfered or no matching found.";
    private string _CheckTransfer = "Transfer from and transfer to can not be same.";
    private string _SalesOrderClosed = "Either order is closed or no matching found.";
    private string _RollsAllocated = "Rolls are allocated to selected order no. Please deallocate it first.";
    private string _SelectInvoiceDetail = "Please select the invoice detail.";
    private string _RequiredQuantity = "Quantity cannot be greater than required quantity.";
    private string _MappingNotFoundForPrice = "Mapping not found for price from the selected criteria.Please map it first.";
    private string _SelectLineItem = "Please select the line item first.";
    private string _SelectLineFromLeftGrid = "Please select the rolls available.";
    private string _CheckSavedRecordInMRN = "Either all rolls are returned or no rolls are available for the selected invoice.";
    private string _rightsToModify = "You do not have any right to Modify its content";
    private string _rightsToWrite = "You do not have any right to add any data";
    private string _RoleRecovered = "Either rolls are recovered or no matching found in inventory.";
    private string _SelectProject = "Please select project first.";
    private string _AllPostings = "Either all postings are deselected or no matching found.";
    private string _SelectIssueReservation = "Please select issue reservation first.";
    private string _ConsigneeOfCustomer = "Please add the consignee of this selected customer.";
  
    private string _RecordDeleted = "Record has been deleted successfully.";

    private string _RecordDeleted1 = " Department Record has been deleted successfully.";

    private string _EmployyeIDdoesnotFound = "Invalid Employee Id.";


 
    #endregion

    #region Properties

    public string ConsigneeOfCustomer
    {
        get { return _ConsigneeOfCustomer; }
    }
    public string SelectIssueReservation
    {
        get { return _SelectIssueReservation; }
    }
    public string AllPostings
    {
        get { return _AllPostings; }
    }
    public string SelectProject
    {
        get { return _SelectProject; }
    }
    public string RightsToModify
    {
        get { return _rightsToModify; }
    }
    public string RightsToWrite
    {
        get { return _rightsToWrite; }
    }
    public string HeaderNotSaved
    {
        get { return _HeaderNotSaved; }
    }
    public string AddLineItem
    {
        get { return _AddLineItem; }
    }
    public string ErrorToLineItem
    {
        get { return _ErrorToLineItem; }
    }
    public string LineItemNotSaved
    {
        get { return _LineItemNotSaved; }
    }
    public string RecordSaved
    {
        get { return _RecordSaved; }
    }
    public string RecordNotSaved
    {
        get { return _RecordNotSaved; }
    }
    public string SelectValue
    {
        get { return _SelectValue; }
    }
    public string NoRecordFound
    {
        get { return _NoRecordFound; }
    }
    public string TotalRecord
    {
        get { return _TotalRecord; }
    }
    public string FillPalletInf
    {
        get { return _FillPalletInf; }
    }
    public string PackingCreated
    {
        get { return _PackingCreated; }
    }

    public string UpdatedRecord
    {
        get { return _RecordUpdated; }
    }
    public string RecordNotUpdated
    {
        get { return _RecordNotUpdate; }
    }
    public string RoleAllocated
    {
        get { return _RoleAllocated; }
    }
    public string SelectCustomer
    {
        get { return _SelectCustomer; }
    }
    public string RoleDeallocated
    {
        get { return _RoleDeallocated; }
    }
    public string RollsTransfered
    {
        get { return _RollsTransfered; }
    }

    public string CheckTransfer
    {
        get { return _CheckTransfer; }
    }
    public string SalesOrderClosed
    {
        get { return _SalesOrderClosed; }
    }
    public string RollsAllocated
    {
        get { return _RollsAllocated; }
    }
    public string SelectInvoiceDetail
    {
        get { return _SelectInvoiceDetail; }
    }

    public string RequiredQuantity
    {
        get { return _RequiredQuantity; }
    }
    public string MappingNotFoundForPrice
    {
        get { return _MappingNotFoundForPrice; }
    }
    public string SelectLineItem
    {
        get { return _SelectLineItem; }
    }
    public string SelectLineFromLeftGrid
    {
        get { return _SelectLineFromLeftGrid; }
    }
    public string CheckSavedRecordInMRN
    {
        get { return _CheckSavedRecordInMRN; }
    }
    public string RoleRecovered
    {
        get { return _RoleRecovered; }
    }


    public string DeletedRecord
    {
        get { return _RecordDeleted; }
    }
    public string DeletedRecord1
    {
        get { return _RecordDeleted1; }
    }
    #endregion

     public string EmployyeIDdoesnotFound
    {
        get { return _EmployyeIDdoesnotFound; }
    }
    


    #region Public Methods

    public Common_Message()
	{

    }

    #endregion
}