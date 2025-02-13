using System;
using System.Data;
using System.Data.SqlClient;

namespace HRSystemServer.DataLayer
{
    public enum SqlEntity
    {
        tbSiteRoleType,
        tbSite,
        tbCompany,
        tbBranch,
        tbAllSequences,
        tbEmployee,
        tbEmployeeType,
        tbExperience,
        tbRank,
        tbTraining, 
        tbConfrimation,
        tbPosting,
        tbQualification,
        tbAward,
        tbAwardType,
        tbPromotion,
        tbDisciplinary,
        tbEvaluation,
        tbDesignation,
        tbSecondment,
        tbDepartment,
        tbUnit,
        tbLeave,
        tbLeaveRecord,
        tbLongevity,
        tbSystemUser,
        tbPasswordChangeLog,
        tbControlMapping,

        tbSecurityDetail,
        tbSystemRoleType,
        tbSecurityProfile,
        tbPageMapping,
        tbArea,
        tbRegion,
        tbPageMappingDetail,
        tbObjectiveReview,
        tbRolePageMapping,
        tbResignation,
        tbPositionChange,
        //// PAYROLL ////
        tbBankCodes,
        tbAllowance,
        tbGrades,
        tbGradePoints,
        tbGradePointDetails,
        tbEmployeePayroll,
        tbPayRollDetails,
        //////// COMP

        tbJobDesc,
        tbCompetency,
        
        ////Stafff Leave Details Tables///
        tbStaffLeaveDeputation,
        tbStaffAttendance,
        tbStaffClassAssociate,
        tbStaff,
        tbStaffLeaves,
        tbStaffLeaveRecord,
        tbStaffAddress,
        tbLeaveApplication,
        tbLeaveType,
        tbEmpLogin,
        tbEmpAssessment,
        tbGroup,
        tbEmpObjective,
        tbRating,
        tbDocument,
        tbDocumentType,
        tbTableColumn,
        tbBatch,
        tbItemLocator,
        tbGL_DETAIL,
        tbItemTran,
        tbItem,
        tbSupplier,
        tbTransactions,
        tbTransactions1,
        tbTxn,
        tbItemsHistoryMonthly,
        tbOrderLevel,
        tbLocation,
        tbStatus,
        tbRequests,
        tbSecco,
        tbSeccoItem,
        tbRequestItem,
        tbProcessStatus,
        tbItemType,
        tbVisitor,
    }
    public enum SqlAction
    {
        Save,
        Insert,
        FetchWithParentSchoolAlbum,
        BulkInsert,
        InsertAdhoc,
        Update,
        Upsert,
        ExecuteNonquery,
        Delete,
        Clear,
        Fetch,
        SQLBulkInsert,
        FetchAll,
        FetchAllForBranch,
        FetchEmailAddressForSystemUser,
       
        FetchForUserRole,
        FetchForSystemUserProfile,
        FetchForNameInitial,
        
        FetchForSecurityProfile,
        FetchForRole,
        Rollback,
        FetchForSite,
        FetchForSchoolRoleType,
        UpdateMultiple,
        DeleteMultiple,
        FetchForEmail,
        FetchForDepartment,
        FetchForSystemUser,
        FetchForPageMapping,
        FetchControl,
        FetchForSiteRoleType,
        FetchForApplicationControlSecurity,
        FetchForBaseURL,
        FetchForLogin,
        FetchForLoginEmailAddress,
        FetchForEmailAddress,
        FetchForUnusedMaster,
        Clone,
        FetchForSearch,
        FetchForWhereCondition,
        Commit,
        FetchForPageSecurity,
        FetchForSystemRoleType,
        InsertUpdateMultiple,
        /** Menu ***/
        FetchForMenu,
        FetchForApplicationPageSecurity,
        FetchForSchoolAndStaff,
        FetchForCurrentDay,
        FetchForLeaveType,
        FetchForStaffAndDate,
        FetchForAcademicQualification,
        FetchForProfessionalQualification,
        FetchForStaff,
        FetchForPage,
        FetchColumnsForFilter,
        FetchForLevel,
        FetchForApprove,
        FetchForReversal,
        FetchForDepotApprove,
        FetchForDepotApproveDetails,
        FetchForDepartmentUnApproved,
        FetchForAdminUnApproved,
        FetchForRequestIDAndDepartment,
        FetchForApprovedList,
        FetchForCGReport,
        FetchLeaveBalance,
        /// Employee HR FetchForType///
        FetchForSchool,
        FetchForType,
        FetchForDetails,
        FetchForHome,
        FetchForGeneration,
        FetchForRegimentalNo,
        FetchForConfimrationReport,
        FetchForPendingConfimrationReport,
        FetchForEmployee,
        FetchForSequence,
        FetchForEmployeeAndStatus,
        FetchForReport,
        FetchForDesignationReport,
        FetchForYearlyEmployeeArchive,
        FetchForProcessEOY,
        FetchForLongevity,
        FetchForReportOld,
        FetchForReportServiceLength,
        FetchForHistoryReport,
        FetchForHistoryAnalysisReport,
        FetchForBranch,
        FetchForUnit,
        FetchForBranchActive,
        FetchForReportGrade,
        FetchForSummary,
        FetchForEmployeeList,
        FetchForEmployeeListHR,
        FetchForReinstate,
        FetchForGradePoints,
        FetchForCal,
        FetchForPayroll,
        FetchForPayrollRegister,
        FetchForReports,
        FetchForPaySlip,
        FetchForRank,
        FetchForStage,
        FetchForEmployeeFinal,

        // Document//
        FetchForProject,
        FetchForDocumentType,
        FetchForLatestDocumentType,
        DeleteDocument,
        FetchForItems,
        FetchForItemsByDepot,
        FetchForItemsConsumables,
        FetchForTransactionMode,
        FetchForItemCode,
        FetchForItemLocator,
        FetchForSeccoItem,
        FetchForLastItemCategoryID,
        FetchForGroupID,
        FetchForLastBatchID,
        FetchForBatchID,
        FetchSeqNo,
        FetchForBatchItemLocator,
        FetchForBatchItemLocatorTransactionListing,
        FetchForBatchPurchaseReversal,
        FetchForBatchItem,
        FetchForBatchItemSurplus,
        FetchForBatchLoss,
        FetchForBatchSurplus,
        FetchForItemCategoryID,
        FetchForID,
        FetchForSupplier,
        FetchForDates,
        FetchForBarchart,
        FetchForSaleschart,
        FetchForReOrderValues,
        MonthlyProcess,
        YearlyProcess,
        FetchForItemDetails,
        FetchForUserOrderLevel,
        FetchForSystemUserItemAndStatus,
        FetchForStoreUnApproved,
        FetchForStoreUnApprovedByDepot,
        FetchForStoreUnApprovedByUser,
        FetchForDepotTransfer,
        FetchForRequestReport,
        FetchForRequest,
        FetchForperiodic,
        FetchForperiodicSoldByBranch,
        FetchForApprovedNotIssued,
        FetchForItemsIssuedPeriodic,
        FetchForItemsSoldPeriodic,
        FetchForSoldPeriodicByItems,
        FetchForPurchasedPeriodicByItems,
        FetchForperiodicSold,
        FetchForReceivedPeriodByUser,
        FetchSoldForperiodicByUser,
        FetchForItemsPurchasedPeriodic,
        FetchForItemsPurchasedPeriodicbyBranch,
        FetchForDeptMonthlySoldReport,
        FetchForItemsIssuedPeriodicbyBranch,
        FetchForItemsReceivedPeriodic,
        FetchForIssuedPeriodicByItems,
        FetchForBranchID,
        FetchForItemsPurchasePeriodic,
        FetchForRequestItems,
        FetchForRequestItemsPrint,
        BackUP,
        FetchForRequestItemsReversal,
        FetchForDeptMonthlyReport,
        FetchForBalance,
        FetchForBalanceByDepot,
        FetchForBalanceByCategoryAndDepotGroup,
        FetchForBalanceByCategoryAndDepot,
        FetchForBalanceByCategoryChart,
        FetchForCardPeriodicByItems,
        FetchForCardPeriodicByItemsByAmount,
        FetchForCardPeriodicByItemsByQuantity,
        FetchForUnAuth,
        FetchForAuth,
        FetchForReceive,
        FetchForApproveDetails,
        FetchForItemsSoldPeriodicDetail,
        FetchForItemsPurchasedPeriodicDetail,
    }
    public interface IDataLayer
    {
        void Execute(DataLayerMessage aMessage);
        string SqlActionX(SqlAction aSqlAction);
        SqlEntity SqlEntity { get; }
        string SqlEntityX { get; }
        string ShortSqlEntityX { get; }
    }
}
